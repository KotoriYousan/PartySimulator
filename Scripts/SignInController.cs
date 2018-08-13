using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignInController : MonoBehaviour {

    public Button SignButton;
    public InputField usernameField;

    // Use this for initialization
    void Start () {
        SignButton.gameObject.SetActive(true);
    //    usernameField.gameObject.SetActive(true);
        SignButton.onClick.AddListener(GameStart);
    }

    public void GameStart()
    {
    //    GameManager.instance.level = 0;
    //    Debug.Log(GameManager.instance.level);
    //    if ((usernameField.transform.Find("Text").gameObject.GetComponent<Text>().text) != "")
    //    {
    //        GameManager.instance.username = usernameField.transform.Find("Text").gameObject.GetComponent<Text>().text;
    //    }
        SceneManager.LoadScene(0);

        //    InvokeRepeating("CreateEnemy", 1f, 10f);
        //    InvokeRepeating("CreateEnemyLeft", 5f, 10f);
        //    InvokeRepeating("LetSilentSpeak", 6f, 1f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
