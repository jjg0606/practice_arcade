using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    public Direction direction;
    public float speed=1.0f;
    private Vector2 movingVec;
    private Rigidbody2D rb2;
    // Start is called before the first frame update
    void Start()
    {
        switch(direction)
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

        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = movingVec*speed;
        if (movingVec.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "BEACON")
        {
            movingVec = -movingVec;
            rb2.velocity = movingVec*speed;
            if(movingVec.x<0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
    }
}
