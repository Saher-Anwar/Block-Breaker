using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config parameters (tuning and settings before the game eg: health, audio, etc)
    [SerializeField] AudioClip BreakingSound;
    [SerializeField] GameObject BlockSparklesVFX;
    [SerializeField] Sprite[] HitSprites;
    [SerializeField] GameObject AddBall;
    GameObject Clone;
    float XVelocity;
    float YVelocity;
    public bool ExtraBallCreated = false;

    // cached references (references to game objects, components, etc)
    Level level;
    ExtraBall extraball;
    Ball ball;
    
    // state variables (keep track of variables)
    [SerializeField] int TimesHit;          // Debug purposes only
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void Update()
    {
        
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball = FindObjectOfType<Ball>();
        if (tag == "Breakable")
        {
            if (name == "Double Ball Block")
            {
                HandleHit();
                Debug.Log("You've hit the thing");
                Clone = (GameObject) Instantiate(AddBall, transform.position, transform.rotation);
                level.CountBalls();
                ExtraBallCreated = true;
                Debug.Log("Extra Ball became True");
                if (ball.HasStarted == true)
                {
                    XVelocity = ball.GetCurrentXVelocity();
                    YVelocity = ball.GetCurrentYVelocity();
                }

                Clone.GetComponent<Rigidbody2D>().velocity = new Vector2(XVelocity,YVelocity);

                //extraball = FindObjectOfType<ExtraBall>();
                //extraball.InstantiateObject();
            }
            HandleHit();
        }
    }

    private void HandleHit()
    {
        TimesHit++;
        int MaxHits = HitSprites.Length + 1;
        if (TimesHit >= MaxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int SpriteIndex = TimesHit - 1;
        if (HitSprites[SpriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[SpriteIndex];
        }
        else
        {
            Debug.Log("Block Sprite is missing from Array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySound();
        Destroy(gameObject);
        level.BlocksDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySound()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(BreakingSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(BlockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
