using UnityEngine;
using System.Collections;

public class flasher : MonoBehaviour {

	//we hold the gameover text because we'll receive a message from score to do a gameover flash
	public GameObject gameOverText;
	
	//private variables that we keep track of based on what happens in the game
	private bool gameOver = false;
	private bool isMenu = false;
	private float alpha = 0.5f;
	private GameObject player;
	
	void Start () {
		//we find the player and apply it to the variable player
		player = GameObject.Find("Player");
		//if the player is null from the start, we're assuming that the flash is in the menu scene, or at least not in the actual gameplay scene
		if(player == null){
			isMenu = true;
		}
		//we make sure the alpha of the guiTexture is set right. 0.5 is actually %100 opacity.
		GetComponent<GUITexture>().color = new Vector4(1,1,1,alpha);
	}
	
	void Update () {
		//if ismenu is not true, then we do stuff for the game scene
		if(isMenu != true){
			//if its not a gameover and the alpha color is greater than 0, we subtract alpha to make it fade out
			if(alpha > 0 && gameOver == false){
				alpha -= Time.deltaTime/2;
			}
			//if gameover is true, then we limit the alpha to 0.35 to give it a faded look when theres a game over
			if(alpha > 0.35 && gameOver == true){
				alpha -= Time.deltaTime/2;
			}
			//if the alpha is less than or equal to 0 and the guitexture is enabled, we turn it off
			if(alpha <= 0 && GetComponent<GUITexture>().enabled == true && gameOver == false){
				GetComponent<GUITexture>().enabled = false;
			}
			//if the alpha is greater than 0 and the guitexture is disabled, we turn it back on.
			if(alpha > 0 && GetComponent<GUITexture>().enabled == false && gameOver == false){
				GetComponent<GUITexture>().enabled = true;
			}
		}else{
			//if it is the menu, we just do this and thats it.
			if(alpha > 0.25){
				alpha -= Time.deltaTime/2;
			}
		}
		GetComponent<GUITexture>().color = new Vector4(1,1,1,alpha);
		//end of function update
	}
	
	//if we receive a message from score, we do stuff
	void gameOverFlash () {
		//we reset the alpha so it flashes again
		alpha = 0.5f;
		GetComponent<GUITexture>().color = new Vector4(1,1,1,alpha);
		//make sure the guitexture is turned on
		GetComponent<GUITexture>().enabled = true;
		//set game over to true
		gameOver = true;
		//move it to a different depth in the gui layer
		transform.position = new Vector3(0.5f,0.5f,0);
		//and turn on the game over text/menu
		gameOverText.SetActive(true);
	}
}
