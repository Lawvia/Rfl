using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {


	public GameObject skin1;
	public GameObject skin2;
	public GameObject skin3;
	public GameObject skin4;
	public GameObject skin5;
	public GameObject skin6;
	public GameObject skin8;
	public GameObject skin10;
	public GameObject skin12;
	public GameObject skin13;

	// Use this for initialization
	void Start () {
		
		spawnRunner ();
	}

	void spawnRunner(){

		if (PlayerPrefs.GetInt("skin") == 1) {
			GameObject go = (GameObject)Instantiate (skin1);
		} else if (PlayerPrefs.GetInt("skin") == 2) {
			GameObject go = (GameObject)Instantiate (skin2);
		} else if (PlayerPrefs.GetInt("skin") == 3) {
			GameObject go = (GameObject)Instantiate (skin3);
		} else if (PlayerPrefs.GetInt("skin") == 4) {
			GameObject go = (GameObject)Instantiate (skin4);
		} else if (PlayerPrefs.GetInt("skin") == 5) {
			GameObject go = (GameObject)Instantiate (skin5);
		} else if (PlayerPrefs.GetInt("skin") == 6) {
			GameObject go = (GameObject)Instantiate (skin6);
		} else if (PlayerPrefs.GetInt("skin") == 8) {
			GameObject go = (GameObject)Instantiate (skin8);
		} else if (PlayerPrefs.GetInt("skin") == 10) {
			GameObject go = (GameObject)Instantiate (skin10);
		} else if (PlayerPrefs.GetInt("skin") == 12) {
			GameObject go = (GameObject)Instantiate (skin12);
		} else if (PlayerPrefs.GetInt("skin") == 13) {
			GameObject go = (GameObject)Instantiate (skin13);
		} 
		else {
			GameObject go = (GameObject)Instantiate (skin1);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
