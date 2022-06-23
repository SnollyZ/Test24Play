using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]private GameObject tryAgainButton;
    [SerializeField]private GameObject tapToPlay;

    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(WaitTouch());
    }

    private IEnumerator WaitTouch()
    {
        bool gameNotStarted = true;
        while(gameNotStarted)
        {
            if (Input.touchCount > 0) 
            {
                gameNotStarted = false;
                StratGame();
            }
            yield return null;
        }
        yield break;
    }

    private void StratGame()
    {
        tapToPlay.SetActive(false);
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        tryAgainButton.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
