 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Serialize for debuggin
    [SerializeField] int BreakableBlocks;
    [SerializeField] int NumberOfBalls;

    // cached reference
    SceneLoader Sceneloader;

    private void Start()
    {
        Sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        BreakableBlocks++;
    }

    public void BlocksDestroyed()
    {
        BreakableBlocks--;
        if (BreakableBlocks <= 0)
        {
            Sceneloader.LoadNextScene();
        }
    }

    public void CountBalls()
    {
        NumberOfBalls++;
    }

    public void BallDestroyed()
    {
        NumberOfBalls--;
    }

    public int GetNumberOfBalls()
    {
        return NumberOfBalls;
    }
}
