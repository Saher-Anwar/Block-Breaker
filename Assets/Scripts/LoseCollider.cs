using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // cached references (references to game objects, components, etc)
    Ball ball;
    Level level;
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        level = FindObjectOfType<Level>();
    }

    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (level.GetNumberOfBalls() == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
