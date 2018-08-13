using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeClinkNoise : MonoBehaviour
{

    [SerializeField] private Collider2D cupCollider;
    bool hitCup = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitCup == false)
        {
            if (collision.collider == cupCollider)
            {
                if (GetComponent<AudioSource>().isPlaying == false)
                    GetComponent<AudioSource>().Play();
            }
        }

    }

}
