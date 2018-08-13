using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class winCheck : MonoBehaviour
{

    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text winText;
    [SerializeField] private Text lossText;
    [SerializeField] private GameObject lossPanel;
    bool waterIsFilled = false;
    [SerializeField] private AudioClip loss;
    [SerializeField] private AudioClip win;
    private AudioSource winAudio;

    private void Start()
    {
        winAudio = GetComponent<AudioSource>();
        winPanel.SetActive(false);
        lossPanel.SetActive(false);
    }

    IEnumerator waitForSound()
    {
        if (winAudio.isPlaying == false)
            winAudio.Play();
        yield return new WaitForSeconds(winAudio.clip.length);
        Destroy(gameObject);

    }
    void Update()
    {


        if (waterIsFilled == true)
        {
            //Do whatever we want for the game win
            Debug.Log("Game has been won for real");
            winPanel.SetActive(true);
            winText.text = "You won with a total of " + scoreTaker.totalScore + " score and made " + pouringManager.totalPours + " pour(s) total!";
            winAudio.clip = win;
            StartCoroutine(waitForSound());

        }
        else if (pouringManager.totalPours >= 5 && waterIsFilled == false)
        {
            Debug.Log("Game has been lost");
            lossPanel.SetActive(true);
            lossText.text = "You lost with a total of " + scoreTaker.totalScore + " score and made " + pouringManager.totalPours + " pour(s) total!";
            winAudio.clip = loss;

            StartCoroutine(waitForSound());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        waterIsFilled = false;
        GetComponent<LineRenderer>().startColor = new Color(1.0f, 0.0f, 0.0f);
        GetComponent<LineRenderer>().endColor = new Color(1.0f, 0.0f, 0.0f);

    }

    //Will not work if the player releases the pitcher too early, bug I can't fix right now
    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(wait());
        if (pouringManager.isPouring == false && collision.GetComponent<Collider2D>().tag == "DynamicParticle")
        {

            GetComponent<LineRenderer>().startColor = new Color(0.0f, 1.0f, 0.0f);
            GetComponent<LineRenderer>().endColor = new Color(0.0f, 1.0f, 0.0f);

        }
    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
       
        Debug.Log("Game should be won");
        waterIsFilled = true;

    }

}
