using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCountController : MonoBehaviour {

    public Text ResultText;

	// Use this for initialization
	void Awake () {
		ResultText.text = "YOU FINISHED CHATTING WITH " + GameManager.instance.countDefeat + " PEOPLE BEFORE LOSING YOUR SPACE.  NICE TRY!";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
