using UnityEngine;


public class Ball : MonoBehaviour
{
    // configuration parameters 
    [SerializeField] Paddle Paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] BallSounds;
    [SerializeField] float RandomFactor;

    // state
    Vector2 PaddleToBallVector;
    public bool HasStarted = false;

    // Cached   
    AudioSource MyAudioSource;
    Rigidbody2D MyRigidBody2D;
    Level level;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBalls();
        PaddleToBallVector = transform.position - Paddle1.transform.position;
        MyAudioSource = GetComponent<AudioSource>();
        MyRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!HasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MyRigidBody2D.velocity = new Vector2(xPush,yPush);
            HasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 PaddlePos = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
        transform.position = PaddlePos + PaddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 VelocityTweak = new Vector2(Random.Range(0f, RandomFactor),Random.Range(0f,RandomFactor));

        if (HasStarted == true)
        {
            AudioClip Clip = BallSounds[UnityEngine.Random.Range(0, BallSounds.Length)];
            MyAudioSource.PlayOneShot(Clip);
            MyRigidBody2D.velocity += VelocityTweak;
        }

        if (collision.gameObject.tag == "Trigger")
        {
            DestroyBall();
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
        level.BallDestroyed();
    }

    public float GetCurrentXVelocity()
    {
       return MyRigidBody2D.velocity.x;
    }

    public float GetCurrentYVelocity()
    {
       return MyRigidBody2D.velocity.y;
    }
}
