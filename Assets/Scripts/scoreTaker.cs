using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTaker : MonoBehaviour
{

    BoxCollider2D scoreCollider;
    int totalScore = 0;
     int totalPours = 0;
   static public int gotOut = 0;
    // Use this for initialization
    void Start()
    {
        totalPours = pouringManager.totalPours;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPours > 3)
        {
            //lock the object
            // make one last check
            //unless its filled lose
        }

        if (gotOut > 5)
        {
            //lose
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        totalScore += 20 / totalPours;
    }




    private void OnCollisionExit2D(Collision2D collision)
    {
        //if we want just one getting out
        //as soon as it gets in here just lose
        
        //if too many get out then lose
       
        totalScore -= 20 / totalPours;
        Debug.Log(gotOut);
    }


}
