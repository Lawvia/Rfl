using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour {

	private CanvasGroup fadeGroup;
	private float fadeInSpeed = 0.33f;

	public RectTransform menuContainer;
	private Vector3 desiredMenuPosition;

	// Use this for initialization
	private void Start () {
		fadeGroup = FindObjectOfType<CanvasGroup> ();

		fadeGroup.alpha = 1;
	}

	private void Update(){
		fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
	
		menuContainer.anchoredPosition = Vector3.Lerp (menuContainer.anchoredPosition, desiredMenuPosition, 0.1f);
	}

	private void NavigateTo(int menuIndex){
		switch (menuIndex) {
		default:
		case 0:
			desiredMenuPosition = Vector3.zero;
			break;

		case 1:
			desiredMenuPosition = Vector3.left * 1280;
			break;

		case 2:
			desiredMenuPosition = Vector3.right * 1280;
			break;

		case 3:
			desiredMenuPosition = Vector3.down * 800;
			break;
		}
	}

	public void OnPlayClick(){

	}

	public void OnShopClick(){
		NavigateTo (2);
	}

	public void OnScoreClick(){
		NavigateTo (3);
	}

	public void OnOptionClick(){
		NavigateTo (1);
	}

	public void OnBackClick(){
		NavigateTo (0);
	}

	public void OnExitClick(){

	}
}
