using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10.1f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int socerePerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;


    // State variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = currentScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currentScore += socerePerBlockDestroyed;
        scoreText.text = currentScore.ToString();


    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
