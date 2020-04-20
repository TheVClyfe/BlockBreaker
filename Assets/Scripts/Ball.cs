using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 0f;
    [SerializeField] float yPush = 8f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //state 
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource audioSource;
    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        //this is used to calculate the offset, basically. And this maintains the initial state relationship between paddle and ball.
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        //0 is left click
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody2D.velocity = new Vector2(xPush, yPush);            
        }        
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomFactor), 
            Random.Range(0, randomFactor)
            );

        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            rigidBody2D.velocity += velocityTweak;
        }        
    }
}
