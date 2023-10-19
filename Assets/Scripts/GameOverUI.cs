using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public Timer scoreTime;

    public TextMeshProUGUI timeScore;
    public TextMeshProUGUI dodgeScore;
    public TextMeshProUGUI scoreText;

    private float slow;


    private void Start()
    {
        gameObject.SetActive(false);
    }



    public void SetValues(int dodgedAmount, float slowSpeed)
    {
        int score = (int)(scoreTime.minutes * 100 * 60 + scoreTime.seconds * 100 + dodgedAmount * 2000); 
        slow = slowSpeed;

        timeScore.text = string.Format("{0:00} : {1:00}", scoreTime.minutes, scoreTime.seconds);
        dodgeScore.text = dodgedAmount.ToString();
        scoreText.text = score.ToString();

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slow;

        SceneManager.LoadScene("SampleScene");
    }



}
