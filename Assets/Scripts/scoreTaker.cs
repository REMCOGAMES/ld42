using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreGathere : MonoBehaviour {

    BoxCollider2D scoreCollider;
    int totalScore = 0;
    int totalPours = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        totalScore += 20 / totalPours;
    }




    private void OnCollisionExit2D(Collision2D collision)
    {
        totalScore -= 20 / totalPours;
    }


}
