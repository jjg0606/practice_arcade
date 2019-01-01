using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    RIGHT,LEFT
};

public class MovingBlock : MonoBehaviour
{
    public float leftThreshold;
    public float rightThreshold;
    [SerializeField]
    Direction firstDirection;
    public float movingSpeed;

    private Transform tr;
    private Rigidbody2D rb2;
    private void Start()
    {
        tr = GetComponent<Transform>();
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(Mathf.Pow(-1, (int)firstDirection) * movingSpeed, 0);
    }

    private void Update()
    {
        if(tr.position.x >rightThreshold)
        {
            rb2.velocity = new Vector2(-movingSpeed,0);
        }
        else if(tr.position.x < leftThreshold)
        {
            rb2.velocity = new Vector2(movingSpeed, 0);
        }   
    }
}
