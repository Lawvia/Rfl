using UnityEngine;
using System.Collections;

public class playercontrols : MonoBehaviour {
	

	//how fast the player walks
	public float speed = 14.0f;
	//how high the player can jump
	public float jumpHeight = 8.0f;
	//at what point the level resets if the player falls in a hole
	public float fallLimit = -10.0f;
	//how fast the player recovers from being pushed back
	public float recoverySpeed = 1.5f;
	//jump sound
	public AudioClip jumpSound;
	
	public GameObject standing;
	public GameObject sliding;
	
	//we use a raycast hit to check how far the player is away from the ground and ceiling
	private RaycastHit2D hitDown;
	private RaycastHit2D hitUp;
	//using this to ensure the jump sound doesn't play more than once at a time.
	private float jumpCounter = 0.0f;
	//we use this statement to allow jumping to happen or not.
	private bool isGrounded = false;
	//here we get the camera to reference its position.
	private GameObject cam;
	//here we get the flash so we can tell it to do something if we die
	private GameObject flash;
	//we use this to save the original speed when starting the game.
	private float origSpeed = 0.0f;
	//we use this to check to see if we're standing or not
	private bool isStanding = true;
	//access the animator for running
	private playeranimator anim;
	//get the box collider attached to player
	private BoxCollider2D boxCol;
	private bool isDead = false;
	private float soundCounter = 0.0f;
	private float gravity = 0.0f;
	private Vector3 speedVector;
	
	void Start () {
		boxCol = GetComponent<BoxCollider2D>();
		anim = standing.GetComponent<playeranimator>();
		//we make sure the sliding animation for the character is deactivated
		sliding.SetActive(false);
		//we find the flash object
		flash = GameObject.Find("flash");
		//we find the main camera and pair it to cam
		cam = GameObject.Find("Main Camera");
		//we send a message to the camera with our speed.
		cam.SendMessage("receiveSpeed", speed);
		//we set the origspeed to speed so we can keep track of it while playing
		origSpeed = speed;
	}
	
	void Update () {
		
		soundCounter += Time.deltaTime;
		
		hitDown = Physics2D.Raycast(transform.position, -Vector2.up);
		
		if(hitDown.distance < transform.localScale.y+0.15){
			gravity = -0.5f;
			if(!isGrounded){
				isGrounded = true;
				anim.setGrounded(true);
			}
		}else{
			if(isGrounded){
				isGrounded = false;
				anim.setGrounded(false);
			}
		}
		
		//if the player gets behind the camera too much, we add a bit of speed so he recovers.
		if(cam.transform.position.x > transform.position.x + 1 && isStanding == true){
			//we add recovery speed to origspeed and make that the new speed
			speed = origSpeed + recoverySpeed;
		}
		
		//NEW LINE FOR FASTER SLIDING RECOVERY
		if(cam.transform.position.x > transform.position.x + 1 && isStanding == false){
			//we add recovery speed to origspeed and make that the new speed
			speed = origSpeed + recoverySpeed;
		}
		
		//if the player gets too far ahead he'll slow down instead of speed up
		if(cam.transform.position.x < transform.position.x - 1 && speed == origSpeed){
			speed = origSpeed - recoverySpeed;
		}
		
		//if the player is back to the middle, we make the speed normal again.
		if(cam.transform.position.x > transform.position.x - 1 && cam.transform.position.x < transform.position.x + 1 && speed != origSpeed){
			speed = origSpeed;
		}
		//here we apply the speed to the character
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y);
		
		hitUp = Physics2D.Raycast (transform.position, Vector2.up);
		
		#if UNITY_WEBPLAYER || UNITY_STANDALONE
		//Keyboard Controls for web versions (Same as Standalone because they both deal with keyboard)
		//if the player presses w or space, and the player is standing and can jump, we allow him to jump.
		if(Input.GetKey("w") || Input.GetKey("space")){
			gravity = GetComponent<Rigidbody2D>().velocity.y;
			if(isStanding == true && jumpCounter < 0.15f){
				//we add speed to the jump
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
				if(soundCounter > 0.25f){
					GetComponent<AudioSource>().PlayOneShot(jumpSound);
					soundCounter = 0.0f;
				}
				jumpCounter = 0.15f;
			}
			//if the player is not pressing jump with w or space, we add velocity down. this helps make variable jump heights depending on how long the player holds the button.
		}else{
			gravity -= 64*Time.deltaTime;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,gravity);
		}
		
		if(isGrounded){
			jumpCounter = 0.0f;
		}else{
			jumpCounter += Time.deltaTime;
		}
		
		if(Input.GetKey("s")){
			if(isStanding){
				//this turns off isstanding so we can check it while the player is sliding
				doSlide();
			}
		}
		//if the player lets go of s, we get him to stand back up with the same functions as above
		if(Input.GetKeyUp("s")){
			doStand();
		}
		if(!Input.GetKey("s")){
			//if the player is in a sliding area, we force him to stay down
			if(hitUp.distance < 0.4f && isStanding == true && hitUp.collider.isTrigger == false){
				doSlide();
			}
			//if the player is not in a sliding area but is still down and not touching the screen, we force him back up.
			if(hitUp.distance > 0.4f && isStanding == false){
				doStand();
			}
		}
		
		#endif
		
		#if UNITY_IOS || UNITY_ANDROID
		//iOS Controls (same as Android because they both deal with screen touches)
		//if the touch count on the screen is higher than 0, then we allow stuff to happen to control the player.
		if(isGrounded){
			jumpCounter = 0.0f;
		}else{
			jumpCounter += Time.deltaTime;
		}
		if(Input.touchCount > 0){
			for(var touch1 : Touch in Input.touches) {
				//if the touch is on the top half of the screen, we do jump stuff
				if(touch1.position.y > Screen.height/2){
					gravity = rigidbody2D.velocity.y;
					//if the player can jump and is standing, then we do the jump
					if(isStanding == true && jumpCounter < 0.15f){
						//we add speed to the jump
						rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jumpHeight);
						if(soundCounter > 0.25f){
							audio.PlayOneShot(jumpSound);
							soundCounter = 0.0f;
						}
						jumpCounter = 0.15f;
						isGrounded = false;
					}
				}
				//if the touch position is on the bottom half of the screen, we do slide stuff
				if(touch1.position.y < Screen.height/2){
					gravity -= 64*Time.deltaTime;
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,gravity);
					doSlide();
				}else{
					//if its not on the bottom half, we make him stand.
					doStand();
				}
			}
		}else{
			//if the touch count is 0, we add velocity down for the variable jump height, depending on how long the player holds jump
			gravity -= 64*Time.deltaTime;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,gravity);
			//now we check the raycast up to see if the player is in a sliding area or not
			if(hitUp.distance < 0.4f && isStanding == true && hitUp.collider.isTrigger == false){
				doSlide();
			}
			//if the player is not in a sliding area but is still down and not touching the screen, we force him back up.
			if(hitUp.distance > 0.4f && isStanding == false){
				doStand();
			}
		}
		#endif
		
		//here we check to see if the player fell or when too far to the left
		if(transform.position.y < fallLimit || transform.position.x < cam.transform.position.x - 13){
			if(!isDead){
				isDead = true;
								if (GameObject.Find ("score").GetComponent<score> ().theScore >= 300) {
										doPindah ();

								} else {

										doDeath ();
								}
			}
		}
	}
	
	void doStand () {
		isStanding = true;
		standing.SetActive(true);
		sliding.SetActive(false);
		boxCol.size = new Vector2(0.75f,2.0f);
		boxCol.offset = new Vector2(0,0);
	}
	
	void doSlide () {
		isStanding = false;
		sliding.SetActive(true);
		standing.SetActive(false);
		boxCol.size = new Vector2(0.75f,0.9f);
		boxCol.offset = new Vector2(0,-0.55f);
	}
	
	void doDeath () {
		isDead = true;
		//we check to see if flash is there, then we send him a message that its a game over.
		if(flash != null){
			//here we send the message
			flash.SendMessage("gameOverFlash", SendMessageOptions.DontRequireReceiver);
		}
		//and destroy the player
		Destroy(gameObject);
	}

		void doPindah(){
				isDead = true;
				Application.LoadLevel ("scene2");
			
		}
}
