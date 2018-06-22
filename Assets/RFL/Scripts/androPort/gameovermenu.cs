using UnityEngine;
using System.Collections;

public class gameovermenu : MonoBehaviour {

	//this is a menu that just holds functions that are called by the mouseButton script attached to retry and menu guiText (child objects)
	
	void doRetry () {
		string getLvlName = Application.loadedLevelName;
		Application.LoadLevel(getLvlName);
	}
	
	void doMenu () {
		Application.LoadLevel("menu-cs");
	}
}
