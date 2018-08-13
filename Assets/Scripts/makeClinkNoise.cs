using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeClinkNoise : MonoBehaviour
{
    
    bool hitCup = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.collider.tag == "pitcher")
            {
                if (GetComponent<AudioSource>().isPlaying == false)
                    GetComponent<AudioSource>().Play();
            }
        

    }

}
