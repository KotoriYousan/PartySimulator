using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public Text text;
    public Button btnYes;
    public Button btnNo;
    public float speed = 2;
    public GameObject mark;
    public GameObject bubble;
    public Canvas textCanvas;

    public int scriptNo;
    private int nextsentence = 0;

    public int isActive = 0;

    //   public Canvas renderCanvas;
    //public GameObject distanceText;
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
    },
        new string[,]{
            {"HEY FRIENT, LONG TIME NO SEE!","HEY WHAT'S UP","1","HOW'S EVERYTHING GOING?","1" },//0
            {"TO TELL YOU A SECRET, I AM LOOKING FOR SOME TREASURE THESE DAYS.","OH COOL","2","WHAT DOES THAT MEAN?","3" },//1
            {"RIGHT? AND I BELIEVE THAT I CAN BECOME A MILLIONAIRE SOON.","WHY DO YOU SAY SO?","4","YOU FOUND THE TREASURE?","5" },//2
            {"TREASURE--GOLD, DIAMOND, AND ANYTHING YOU CAN THINK OF--","YOU MUST BE KIDDING ME.","6","WHAT A DAY DREAM.","7" },//3
            {"BECAUSE I HAVE GOT AN EVIDENCE OF THE PLACE OF THE TREASURE YESTERDAY.","YOU GOT A MAP?","8","WHAT IS IT?","9" },//4
            {"SHHH, NOT YET, BUT I WILL SOON.","WHAT A DAY DREAM.","7","BY WHAT, A MAP?","8" },//5
            {"NO WAY. I TOLD YOU BECAUSE WE ARE FRIENDS,FRIENDS NEVER LIE TO EACH OTHER.","BEST FRIEND EVER--","10","I KNOW, I BELIEVE YOU","11" },//6
            {"IT'S YOUR LOSS NOT TO BELIEVE ME. SEE YOU LATER.","lATER","NULL","BYE","NULL" },//7
            {"BINGO! I FOUND AN ANCIENT MAP FROM MY GRANDPA'S OLD HOUSE.","SO COOL..","NULL","WISH YOU GOOD LUCK THEN","13" },//8
            {"YOU WON'T BELIEVE YOUR EARS. I FOUND AN ANCIENT MAP FROM MY GRANDPA'S OLD HOUSE!","THAT'S AMAZING","12","MAYBE HE IS A MYSTERIOUS KING","14" },//9
            {"I GOTTA GO NOW, MY BEST FRIEND, SEE YOU TOMOTTOW.","LATER","NULL","BYEBYE","NULL" },//10
            {"THAT'S WHY I ALWAYS KNOW THAT YOU ARE MY BEST FRIEND.","MY PLEASURE","NULL","WISH YOU GOOG LUCK THEN","13" },//11
            {"SURE IT IS. WANT SOME DRINK?","SURE.","NULL","OF COURSE","NULL" },//12
            {"THANKS. I NEED IT. GOTTA GO.","SEE YOU","NULL","GOODBYE","NULL" } ,//13
            {"BELIEVE IT OR NOT, I WAS THINGING SO TOO.","THAT'S FUNNY","NULL","HAHA, AND YOU A PRINCE.","15" },//14
            {"AND THE HONORED PRINCE IS INVITING YOU TO VISIT HIS HOUSE THIS EVENING. WOULD YOU COME?","SURE","NULL","OF COURSE","NULL" }//15
        }


    };
    


    private void Awake()
    {
        GameManager.instance.AddEnemyToList(this);

     //   scripts.Add(words1);

        textCanvas.gameObject.SetActive(false);
        bubble.SetActive(false);

        mark.SetActive(true);
    }

    // Use this for initialization
    void Start () {

        btnYes.onClick.AddListener(LoadNextSentence1);
        btnNo.onClick.AddListener(LoadNextSentence2);
    }
	
	// Update is called once per frame
	void Update () {
        
        
        
    }


    public void Speak()
    {
       
        mark.SetActive(false);
        bubble.SetActive(true);
        textCanvas.gameObject.SetActive(true);
        isActive = 1;
        //    text.text = words[Random.Range(0, words.Length)];

        scriptNo = Random.Range(0, scripts.Count);

      //  Debug.Log(scripts[scriptNo][0, 0] + scripts[scriptNo][0, 1]);

        text.text = scripts[scriptNo][0,0];
        btnYes.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][0,1];
        btnNo.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][0,3];



    //    Debug.Log(gameObject.name);
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

            transform.position = transform.position - new Vector3(speed, 0, 0);

            nextsentence = int.Parse(scripts[scriptNo][nextsentence, 2]);
            text.text = scripts[scriptNo][nextsentence, 0];
            btnYes.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 1];
            btnNo.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 3];
        }

    //    Speak();
    }

    void LoadNextSentence2()
    {

        if (scripts[scriptNo][nextsentence, 4] == "NULL")
        {
            DestroyEnemy();
        }
        else
        {

            transform.position = transform.position - new Vector3(speed, 0, 0);

            nextsentence = int.Parse(scripts[scriptNo][nextsentence, 4]);
            text.text = scripts[scriptNo][nextsentence, 0];
            btnYes.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 1];
            btnNo.transform.Find("Text").gameObject.GetComponent<Text>().text = scripts[scriptNo][nextsentence, 3];
        }

        //    Speak();
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        GameManager.instance.countDefeat++;
        GameManager.instance.RemoveEnemyFromList(this);
    //    GameManager.instance.nextRightFlag = 1;
        GameManager.instance.NextEnemyRight();
        
    }
}
