using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	public int skin;

	//This script receives messages from the GUITexts for Play and Quit that are children of this object
	
	void startRunner () {
		Application.LoadLevel("runner-game-cs");
	}
		void level2 () {
				Application.LoadLevel("scene2");
		}
		void level3 () {
				Application.LoadLevel("scene3");
		}

	void GoMenu () {
		Application.LoadLevel("menu-cs");
	}

	void GoShop () {
		Application.LoadLevel("shop");
	}

	void skin1(){
		PlayerPrefs.SetInt ("skin", 1);
		Application.LoadLevel("menu-cs");
	}

	void skin2(){
		PlayerPrefs.SetInt ("skin", 2);
		Application.LoadLevel("menu-cs");
	}

	void skin3(){
		PlayerPrefs.SetInt ("skin", 3);
		Application.LoadLevel("menu-cs");
	}

	void skin4(){
		PlayerPrefs.SetInt ("skin", 4);
		Application.LoadLevel("menu-cs");
	}

	void skin5(){
		PlayerPrefs.SetInt ("skin", 5);
		Application.LoadLevel("menu-cs");
	}

	void skin6(){
		PlayerPrefs.SetInt ("skin", 6);
		Application.LoadLevel("menu-cs");
	}

	void skin8(){
		PlayerPrefs.SetInt ("skin", 8);
		Application.LoadLevel("menu-cs");
	}

	void skin13(){
		PlayerPrefs.SetInt ("skin", 13);
		Application.LoadLevel("menu-cs");
	}

	void skin12(){
		PlayerPrefs.SetInt ("skin", 12);
		Application.LoadLevel("menu-cs");
	}

	void skin10(){
		PlayerPrefs.SetInt ("skin", 10);
		Application.LoadLevel("menu-cs");
	}

	void LevelSelect(){
	
		Application.LoadLevel("Level");
	}

	void shop1(){
		Application.LoadLevel("shop");
	}

	void shop2(){

		Application.LoadLevel ("shop2");
	}

	void startFlyer () {
		Application.LoadLevel("flyer-game-cs");
	}
	
	void quitGame () {
		Application.Quit ();
	}
}
