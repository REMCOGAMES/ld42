using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCheck : MonoBehaviour
{

    BoxCollider2D winCheckCollider;
    BoxCollider2D scoreCheckCollider;
    bool waterIsFilled = false;
  

    // Update is called once per frame
    void Update()
    {
        if (waterIsFilled == true)
        {
            //Do whatever we want for the game win
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        waterIsFilled = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(pouringManager.isPouring == false)
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
        waterIsFilled = true;
        Debug.Log("Game should be won");
    }

}
