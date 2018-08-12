using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTaker : MonoBehaviour
{

    BoxCollider2D scoreCollider;
    static public int totalScore = 0; 
    static public int gotOut = 0;
    [SerializeField] private Text scoreText;
 
    void Update()
    {
        if (pouringManager.totalPours > 3)
        {
            //lock the object

            // make one last check

            //unless its filled lose
        }

        scoreText.text = "Current score is: " + totalScore;


        if (gotOut > 5)
        {
            //lose
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "DynamicParticle")
            totalScore += 20 / pouringManager.totalPours;

    }
   



}
