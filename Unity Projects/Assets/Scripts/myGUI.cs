using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {

	void OnGUI()
	{
		GUI.Box (new Rect(5, 5, 200, 50), "Score: " +Player.score + "  Lives: " + Player.playerlives);
	
	}
}
