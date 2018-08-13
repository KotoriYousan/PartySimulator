using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int level = 0;

    public GameObject bluegirl;
    public GameObject greengirl;
    public GameObject pinkgirl;
    public GameObject suitman;
    public GameObject swanman;
    public GameObject bluegirlL;
    public GameObject greengirlL;
    public GameObject pinkgirlL;
    public GameObject suitmanL;
    public GameObject swanmanL;

    public Text ResultText;

 //   public Button SignButton;
 //   public string username = "BENJAMINE";

    private List<EnemyController> enemies;
    private List<EnemyLeftController> leftEnemies;
    private int createEnemyFlag = 0;
    private float currentTime;

    public int countDefeat = 0;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);

        enemies = new List<EnemyController>();
        leftEnemies = new List<EnemyLeftController>();

        

        InitGame();
    }


    private void Start()
    {
       
            InvokeRepeating("CreateEnemy", 1f, 10f);
            InvokeRepeating("CreateEnemyLeft", 5f, 10f);
            InvokeRepeating("LetSilentSpeak", 6f, 1f);
        
    }

    void InitGame()
    {
        enemies.Clear();
        //       CreateEnemy();
 //       SignButton.gameObject.SetActive(true);
  //      SignButton.onClick.AddListener(GameStart);
    }
/*
    public void GameStart()
    {
        level = 0;
        Debug.Log(level);
        SceneManager.LoadScene(0);
    }*/

    public void GameOver()
    {
        SceneManager.LoadScene(1);
        level = 1;
        this.CancelInvoke();
    //    ResultText = GameObject.Find("ResultText").GetComponent<Text>();
    //    ResultText.text = "YOU FINISHED CHATTING WITH "+ countDefeat +" PEOPLE BEFORE LOSING YOUR SPACE.NICE TRY!";
    }

    public void LetSilentSpeak()
    {
        if (NoActiveRight() && enemies.Count != 0)
        {
            //NextEnemyRight();
            FindClosestEnemyRight().GetComponent<EnemyController>().Speak();
            Debug.Log("let someone silent speak!");
        }
        if (NoActiveLeft() && leftEnemies.Count != 0)
        {
            FindClosestEnemyLeft().GetComponent<EnemyLeftController>().Speak();
            Debug.Log("let someone to the left silent speak!");
        }
    }
    

    public bool NoActiveRight()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i].isActive == 1)
            {
                return false;
            }
        }
        return true;
    }

    public bool NoActiveLeft()
    {
        for (int i = 0; i < leftEnemies.Count; i++)
        {
            if (leftEnemies[i].isActive == 1)
            {
                return false;
            }
        }
        return true;
    }

    public void AddEnemyToList(EnemyController script)
    {
        enemies.Add(script);
    }

    public void AddLeftEnemyToList(EnemyLeftController script)
    {
        leftEnemies.Add(script);
    }

    public void RemoveEnemyFromList(EnemyController script)
    {
        enemies.Remove(script);
    }

    public void RemoveLeftEnemyFromList(EnemyLeftController script)
    {
        leftEnemies.Remove(script);
    }

    public void CreateEnemy()
    {
        if (level == 0)
        {
            GameObject[] prefabs = { bluegirl, greengirl, pinkgirl, suitman, swanman };

            GameObject newEnemy = Instantiate(prefabs[Random.Range(0, 5)]);
            newEnemy.name = "enemy" + enemies.Count;
            if (enemies.Count == 1)
            {
                enemies[0].Speak();
            }
            Debug.Log(enemies.Count);
        }
    }

    public void CreateEnemyLeft()
    {
        if (level == 0)
        {
            GameObject[] prefabs = { bluegirlL, greengirlL, pinkgirlL, suitmanL, swanmanL };

            GameObject newEnemy = Instantiate(prefabs[Random.Range(0, 5)]);
            newEnemy.name = "enemyLeft" + enemies.Count;
            if (leftEnemies.Count == 1)
            {
                leftEnemies[0].Speak();
            }
            Debug.Log(leftEnemies.Count);
        }
    }

    public GameObject FindClosestEnemyRight()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = Mathf.Infinity;
        GameObject res = null;
        for(int i=0;i<enemies.Length;i++)
        {
            float diff = enemies[i].transform.position.x;
            if(diff < distance)
            {
                distance = diff;
                res = enemies[i];
            }
        }
        return res;
    }

    public GameObject FindClosestEnemyLeft()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyLeft");
        float distance = 0 - Mathf.Infinity;
        GameObject res = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            float diff = enemies[i].transform.position.x;
            if (diff > distance)
            {
                distance = diff;
                res = enemies[i];
            }
        }
        return res;
    }

    public void NextEnemyRight()
    {
        //    Destroy(FindClosestEnemyRight());
        //    FindClosestEnemyRight().GetComponent<EnemyController>().textCanvas.gameObject.SetActive(true);
        //    Debug.Log("speaking:" + FindClosestEnemyRight().GetComponent<EnemyController>().name);
        if (enemies.Count != 0)
        {
            FindClosestEnemyRight().GetComponent<EnemyController>().Speak();
    //        FindClosestEnemyRight().GetComponent<EnemyController>().textCanvas.gameObject.SetActive(true);
    //        Debug.Log("speaking:" + FindClosestEnemyRight().GetComponent<EnemyController>().name);
        }
        else
        {
         //      createEnemyFlag = 0;
            CreateEnemy();
            Debug.Log("no more enemies");
        }
    }

    public void NextEnemyLeft()
    {
        if (leftEnemies.Count != 0)
        {
            FindClosestEnemyLeft().GetComponent<EnemyLeftController>().Speak();
        }
        else
        {
            CreateEnemyLeft();
            Debug.Log("no more left enemies");
        }
    }
}
