using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {


    public int leftCollide = 0;
    public int rightCollide = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("right collide");
            rightCollide = 1;

            if(leftCollide == 1)
            {
                Debug.Log("game over");
                GameManager.instance.GameOver();
            }

        }
        if (collision.gameObject.tag == "EnemyLeft")
        {
            Debug.Log("left collide");
            leftCollide = 1;

            if(rightCollide == 1)
            {
                Debug.Log("game over");
                GameManager.instance.GameOver();
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("right exit");
            rightCollide = 0;
        }
        if (collision.gameObject.tag == "EnemyLeft")
        {
            Debug.Log("left exit");
            leftCollide = 0;
        }
    }

}
