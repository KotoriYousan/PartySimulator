using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLeftController : MonoBehaviour
{

    public Text text;
    public Button btnYes;
    public Button btnNo;
    public float speed;
    public GameObject mark;
    public GameObject bubble;
    public Canvas textCanvas;

    public int scriptNo;
    private int nextsentence = 0;

    public int isActive = 0;
    

    private string[] words = {"I'M GLAD TO MEET YOU!",
                              "HOW IS EVERYTHING GOING?",
                              "WOULD YOU PLEASE BUY ME A DRINK?"};

    private List<string[,]> scripts = new List<string[,]> {
        new string[,] {
        {"HELLO, "+"BEN" +", I'M SO GLAD TO SEE YOU!", "ME TOO", "1", "(NOD NOD)", "2"},//0
        { "DID YOU SEE THE NEW MOVIE COMING OUT YESTERDAY?", "YES, I LIKED IT.", "6", "NOT YET", "3" },//1
        { "I SAW YOU AT THE CINEMA YESTERDAY.","YEAH WATCHING THE NEW MOVIE WITH PAUL.","9","THAT'S NOT ME","10" },//2
        {"YOU SHOULD WATCH IT! IT'S A FABULOUS WORK I AM LOOKING FORWARD TO A LOT.", "LET'S WATCH IT TOGETHER TONIGHT.", "4", "OK I WILL", "5"},//3
        {"SURE! SEE YOU LATER.","LET'S MEET UP AT 6 THEN.","7","BYE","NULL"},//4
        {"REMEMBER TO WATCH IT!! I GOTTA GO.","SEE YOU","NULL","BYE","NULL"},//5
        {"OH GREAT! I LOVE IT A LOT TOO.","WHAT'S YOUR FAVORITE PART THEN?","8","(SHAKE HANDS)","NULL"},//6
        {"OK THEN.","SEE YOU.","NULL","BYE","NULL"},//7
        {"THE MAIN ACTRESS ACTUALLY.","THAT'S IT.","NULL","HAHA","NULL"},//8
        {"WHY? THAT MOVIE WAS BORING...","PAUL LOVES THE ACTRESS","11","I DIDN'T KNOW","NULL"},//9
        {"OH I'M SO SORRY...","THAT'S OK","NULL","NOTHING","NULL"},//10
        {"HAHAHAHA I SEE. SHE IS A GREAT ACTRESS ISN'T SHE.","ACTUALLY","NULL","RIGHT","NULL"}//11
    }


    };


    private void Awake()
    {
        GameManager.instance.AddLeftEnemyToList(this);

        textCanvas.gameObject.SetActive(false);
        bubble.SetActive(false);

        mark.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {

        btnYes.onClick.AddListener(LoadNextSentence1);
        btnNo.onClick.AddListener(LoadNextSentence2);
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void Speak()
    {

        mark.SetActive(false);
        bubble.SetActive(true);
        textCanvas.gameObject.SetActive(true);
        isActive = 1;
        //    text.text = words[Random.Range(0, words.Length)];

        text.text = scripts[scriptNo][0, 0];
        btnYes.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][0, 1];
        btnNo.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][0, 3];

        //  Debug.Log(gameObject.name);
        Debug.Log(text.text);
    }

    void LoadNextSentence1()
    {
        if (scripts[scriptNo][nextsentence, 2] == "NULL")
        {
            DestroyEnemy();
        }
        else
        {
            transform.position = transform.position + new Vector3(speed, 0, 0);
            nextsentence = int.Parse(scripts[scriptNo][nextsentence, 2]);
            text.text = scripts[scriptNo][nextsentence, 0];
            btnYes.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 1];
            btnNo.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 3];
        }
    }

    void LoadNextSentence2()
    {
        if (scripts[scriptNo][nextsentence, 4] == "NULL")
        {
            DestroyEnemy();
        }
        else
        {
            transform.position = transform.position + new Vector3(speed, 0, 0);
            nextsentence = int.Parse(scripts[scriptNo][nextsentence, 4]);
            text.text = scripts[scriptNo][nextsentence, 0];
            btnYes.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 1];
            btnNo.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 3];
        }

    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        GameManager.instance.countDefeat++;
        GameManager.instance.RemoveLeftEnemyFromList(this);
        //    GameManager.instance.nextRightFlag = 1;
        GameManager.instance.NextEnemyLeft();

    }
}
