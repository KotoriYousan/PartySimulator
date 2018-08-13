using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour {

    public Button StartButton;

    public void LoadByIndex()
    {
        SceneManager.LoadScene(3);//sign scene
    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log("You have clicked the button!");
        StartButton.onClick.AddListener(LoadByIndex);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
