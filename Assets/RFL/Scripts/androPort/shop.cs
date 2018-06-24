using UnityEngine;
using System.Collections;

public class shop : MonoBehaviour {


	public Texture[] idle;
	public float idleFrameRate = 8.0f;
	public Texture[] run;
	public float runFrameRate = 8.0f;
	public Texture[] jump;
	public float jumpFrameRate = 8.0f;
	public float frameRate = 8;


	private float counter = 0.0f;
	private int i = 0;
	private GUITexture rend;
	private bool isJumping = false;

	void Start () {
		//controller = GetComponent<CharacterController>();
		rend = GetComponent<GUITexture>();
	}

	void Update () {

		//float xVelocity = controller.velocity.x;
		//float yVelocity = controller.velocity.y;
		//if(xVelocity < 0){
		//	xVelocity *= -1;
		//	}
		//	if(xVelocity < 0.25f){
		//Do Idle
		//	if(controller.isGrounded){
		counter += Time.deltaTime*idleFrameRate;
		if(counter > i && i < idle.Length){

			rend.texture = idle[i];
			i += 1;
		}

		if(counter > idle.Length){
			counter = 0.0f;
			i = 0;
		}
		//	}
		//}else{
		//	if(controller.isGrounded){
		//		//Do Run
		//		counter += Time.deltaTime*runFrameRate;
		//		if(counter > i && i < run.Length){
		//			
		//			rend.sprite = run[i];
		//			i += 1;
		//		}
		//		if(counter > run.Length){
		//			
		//			counter = 0.0f;
		//			i = 0;
		//		}
		//	}
		//}
		//if(!controller.isGrounded){
		//	//Do Jump
		//	if(!isJumping && yVelocity > 0.5f){
		//		isJumping = true;
		//		counter = 0.0f;
		//		i = 0;
		//	}
		//	if(isJumping){
		//		counter += Time.deltaTime*jumpFrameRate;
		//		if(counter > i && i < jump.Length){
		//			rend.sprite = jump[i];
		//			i += 1;
		//		}
		//	}
		//}
		//if(controller.isGrounded){
		//	isJumping = false;
		//}
	}
}
