using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float clampMinValue = 0.5f;
    [SerializeField] float clampMaxValue = 15.5f;

    //cached references
    Ball ball;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetPosX(), clampMinValue, clampMaxValue);
        transform.position = paddlePosition;
    }

    private float GetPosX()
    {
        var isEnabled = gameSession.IsAutoPilotEnabled();
        if (isEnabled)
        {
            return ball.transform.position.x;
        } else
        {
            return (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        }
    }
}
