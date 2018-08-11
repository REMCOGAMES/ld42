using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTaker : MonoBehaviour
{

    BoxCollider2D scoreCollider;
    int totalScore = 0;
    int totalPours = 0;
    int gotOut = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(totalPours > 3)
        //lose


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        totalScore += 20 / totalPours;
    }




    private void OnCollisionExit2D(Collision2D collision)
    {
        gotOut += 1;
        //if too many get out then lose
        //        if(gotOut > 5)

        //if gets in here lose        
        totalScore -= 20 / totalPours;
    }


}
