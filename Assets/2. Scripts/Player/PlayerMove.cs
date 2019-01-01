using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float speedInAir;

    private readonly int animIsJump = Animator.StringToHash("IsJump");
    private readonly int animIsMoving = Animator.StringToHash("IsMoving");

    private Vector2 speedInGround=new Vector2();
    private Transform tr;
    private Rigidbody2D rigidb;
    private Rigidbody2D movingBlock;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxis("Horizontal");

        { //보고있는 축에따라 바라보는 방향을 결정함
            if(axis <0)
            {
                tr.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (axis > 0)
            {
                tr.rotation = Quaternion.Euler(0, 0, 0);
            }
        } //보고있는 축에따라 바라보는 방향을 결정함

        if (rigidb.velocity.y ==0.0f) // 지면에 있을 때
        {
            speedInGround.Set(axis * speed, rigidb.velocity.y);
            if (movingBlock != null)
            {
                speedInGround += movingBlock.velocity;
            }
            rigidb.velocity = speedInGround;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidb.AddForce(new Vector2(0, 400));
                anim.SetTrigger(animIsJump);
            }
        }
        else // 공중에 있을 때
        {
            
            if (Input.GetKeyDown(KeyCode.Space)) // 공중에서 점프
            {
                rigidb.AddForce(new Vector2(0, 200));
                anim.SetTrigger(animIsJump);
            }
            rigidb.velocity = new Vector2((speedInGround.x + axis * speedInAir), rigidb.velocity.y);

        }

        { // 움직이는 모션과 정지한 모션을 할당해줌
            if (Mathf.Abs(axis) != 0)
            {
                anim.SetBool(animIsMoving, true);
            }
            else
            {
                anim.SetBool(animIsMoving, false);
            }
        }  // 움직이는 모션과 정지한 모션을 할당해줌


    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "MOVINGBLOCK")
        {
            movingBlock = coll.transform.GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        movingBlock = null;
    }
}
