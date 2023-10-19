using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public float slow = 10f;
    public GameObject deathPopUp;
    private int score;

    private void Start()
    {
        score = 0;
    }

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slow;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slow;

        yield return new WaitForSeconds(1f/ slow);
        Time.timeScale = 0;
        deathPopUp.SetActive(true);
        deathPopUp.GetComponent<GameOverUI>().SetValues(score, slow);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") 
        {

            score++;
        }
    }
}
