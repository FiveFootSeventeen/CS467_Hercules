using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {

    public float timeLeft = 300.0f;
    private int sanity;
    private double sanityExact;
    public bool stop;

    private float minutes;
    private float seconds;

    public TextMeshProUGUI TextPro;

    //public void StartTimer(float from)
    void Start()
    {
        if ((SceneManager.GetActiveScene().name == "Game.TwilightScene") || (SceneManager.GetActiveScene().name == "Game.PlasmaScene") || (SceneManager.GetActiveScene().name == "Game.VoidScene"))
        {
            //GameObject.Find("CountdownText").SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            stop = false;
            Update();
            StartCoroutine(updateCoroutine());
        }
    }

    void Update()
    {
        if (stop)
        {
            
            return;
        }

        timeLeft -= Time.deltaTime;
        sanityExact -= .35 * Time.deltaTime;
        sanity = Mathf.RoundToInt((float)sanityExact);
        Debug.Log(sanity);

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;
        if (seconds > 59) seconds = 59;
        if (minutes < 0)
        {
            stop = true;
            minutes = 0;
            seconds = 0;
        }
        
        //        fraction = (timeLeft * 100) % 100;
    }

    private IEnumerator updateCoroutine()
    {
        while (!stop)
        {
            TextPro.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(0.2f);
        }
    }
}