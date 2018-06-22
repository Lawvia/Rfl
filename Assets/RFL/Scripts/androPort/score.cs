﻿using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	//we have a sound when game over happens so we just play it from the score since it manages when the score stops and such.
	public AudioClip gameOverSound;
	
	//private variables we use to keep track of score
	public int theScore = 0;
	private float scoreCounter = 0.0f;
	//we check to see if the player is null or not so we use it
	private GameObject player;
	
	private bool checkPlayer = true;
	private int multiplyer = 1;
	
	void Start () {
		//we find the player and apply it to the variable player
		player = GameObject.Find("Player");
	}
	
	void Update () {
		//if the player is not null, keep track of score
		if(player != null){
			//here we add score based on time, multiplyed by the multiplyer amount
			scoreCounter += (10*Time.deltaTime)*multiplyer;
			//then we round the score so it has no decibel amounts
			theScore = Mathf.RoundToInt(scoreCounter);
			
			//if the player has a multiplyer, we show it with an X
			if(multiplyer > 1){
				GetComponent<GUIText>().text = "SCORE: " + theScore.ToString() + " X" + multiplyer.ToString();
				//if the player doesn't have a multiplyer or lost it, we don't show the X and the multiplyer
			}else{
				GetComponent<GUIText>().text = "SCORE: " + theScore.ToString();
			}
			//if the player is null (he got deleted in playercontrols.js) we do the gameover stuff from here.
		}else{
			if(checkPlayer == true){
				//turn check player off because we only want to do gameover stuff once
				checkPlayer = false;
				//play the gameover sound
				GetComponent<AudioSource>().PlayOneShot(gameOverSound);
				//change the score so to normal so no multiplyer counter is there if the player had one
				GetComponent<GUIText>().text = "SCORE: " + theScore.ToString();
				//now we check to see if the score was higher than the last high score
				if(theScore > PlayerPrefs.GetFloat("highscore")){
					//if it is, we set the highscore playerpref to what the score was this round
					PlayerPrefs.SetFloat("highscore", theScore);
					//now we find the highscore guitext and send it a message to update the score to what it is now.
					var highScore = GameObject.Find("GUI/gameover/highscore");
					highScore.SendMessage("updateScore", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
	
	//if the player picks up a pickup, we get a message to add one.
	void addMultiplyer () {
		multiplyer += 1;
	}
	
	//if the player misses a pickup, we reset it to one.
	void lostMultiplyer () {
		multiplyer = 1;
	}
}
