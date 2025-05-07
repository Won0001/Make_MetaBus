using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    public Button homeButton;

    // Start is called before the first frame update
    void Start()
    {
        if(restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if(scoreText == null)
        {
            Debug.LogError("score text is null");
        }

        restartText.gameObject.SetActive(true);

        homeButton.gameObject.SetActive(false);

        homeButton.onClick.AddListener(OnHomeButtonClick);

        StartCoroutine(WaitForClickToStart());
    }

    private System.Collections.IEnumerator WaitForClickToStart()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.StartGame();
                restartText.gameObject.SetActive(false);
                homeButton.gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
