using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    // config parameters (tuning and settings before the game eg: health, audio, etc)
    [SerializeField] float RandomFactor;

    // cached references (references to game objects, components, etc)
    Ball ball;

    // state variables (keep track of variables)
    Rigidbody2D MyRigidBody2D;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            Destroy(gameObject);
            FindObjectOfType<Level>().BallDestroyed();
            Debug.Log("Extra ball destroyed");
        }

            Debug.Log("Changing Velocity");
            Vector2 VelocityTweak = new Vector2(Random.Range(0f, RandomFactor), Random.Range(0f, RandomFactor));
            MyRigidBody2D.velocity += VelocityTweak;
    }

    public void InstantiateObject()
    {
        //MyRigidBody.velocity = new Vector2(ball.GetCurrentXVelocity(), ball.GetCurrentYVelocity());
        //Debug.Log("I'm being called!");
        MyRigidBody2D.velocity = new Vector2(4f, 5f);
        Debug.Log("I am being called!");
    }
}
