using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTaker : MonoBehaviour
{

    BoxCollider2D scoreCollider;
    static public int totalScore = 0;
    [SerializeField] private Text scoreText;
    private void Start()
    {
        totalScore = 0;

    }
    void Update()
    {
        scoreText.text = "Current score is: " + totalScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "DynamicParticle")
            totalScore += 20 / pouringManager.totalPours;

    }




}
