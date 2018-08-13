using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButtonSounds : MonoBehaviour {


   public void playButtonSound()
    {
        GetComponent<AudioSource>().Play();
    }
     
}
