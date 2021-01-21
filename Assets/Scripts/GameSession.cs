using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config parameters
    [Range(0.1f,10f)] [SerializeField] float GameSpeed = 1f;
    [SerializeField] int PointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI ScoreText;

    // state variables
    [SerializeField] int CurrentScore = 0;
    
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ScoreText.text = CurrentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameSpeed;
    }
    public void AddToScore()
    {
        CurrentScore += PointsPerBlockDestroyed;
        ScoreText.text = CurrentScore.ToString();
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
   
}
