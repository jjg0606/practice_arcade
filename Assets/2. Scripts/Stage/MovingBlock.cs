using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    RIGHT,LEFT,UP,DOWN
};

public class MovingBlock : MonoBehaviour
{

    public Direction firstDirection;
    public float movingSpeed;

    private Rigidbody2D rb2;
    private Vector2 movingVec;
    private void Start()
    {

        rb2 = GetComponent<Rigidbody2D>();
        switch (firstDirection)
        {
            case Direction.LEFT:
                movingVec = Vector2.left;
                break;
            case Direction.RIGHT:
                movingVec = Vector2.right;
                break;
            case Direction.UP:
                movingVec = Vector2.up;
                break;
            case Direction.DOWN:
                movingVec = Vector2.down;
                break;
        }
        rb2.velocity = movingVec * movingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "BEACON")
        {
            movingVec = -movingVec;
            rb2.velocity = movingVec * movingSpeed;
        }
    }
}
