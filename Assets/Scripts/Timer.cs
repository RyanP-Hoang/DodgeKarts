using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timer;
    public float seconds, minutes;
    private bool working;

    private void Start()
    {
        minutes = 0;
        seconds = 0;
        timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    // Update is called once per frame
    void Update()
    {
        if (!working)
        {
            StartCoroutine(TimeUpdater());
        }

    }

    IEnumerator TimeUpdater()
    {
        working = true;
  
        seconds++;
        if (seconds >= 60)
        {
            seconds -= 60;
            minutes++;
        }
        timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        yield return new WaitForSeconds(1);

        working = false;
    }

}
