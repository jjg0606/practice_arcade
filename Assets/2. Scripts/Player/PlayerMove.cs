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
    private AudioSource audiosource;
    public AudioClip jumpSFX;
    private Vector2 movingcali;
    private bool bCanjump = true;

    public int jumpMaximum = 1;
    private int jumpCurrent = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();
        movingcali = Vector2.zero;
    }

    public void plusCalivec(Vector2 cali)
    {
        movingcali += cali;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float axis = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");

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
            jumpCurrent = 0;
            if (movingBlock != null)
            {
                speedInGround += movingBlock.velocity;
            }
            rigidb.velocity = speedInGround;
            if (jump > 0 && bCanjump) // 점프
            {
                audiosource.PlayOneShot(jumpSFX, 1.0f);
                rigidb.AddForce(new Vector2(0, 400));
                anim.SetTrigger(animIsJump);
                bCanjump = false;
                StartCoroutine(JumpCooling(0.5f));
            }
        }
        else // 공중에 있을 때
        {
            
            if (jump>0&& bCanjump && jumpCurrent < jumpMaximum) // 공중에서 점프
            {
                audiosource.PlayOneShot(jumpSFX, 1.0f);
                rigidb.AddForce(new Vector2(0, 200));
                anim.SetTrigger(animIsJump);
                bCanjump = false;
                StartCoroutine(JumpCooling(0.5f));
                jumpCurrent++;
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

        rigidb.velocity += movingcali;
    }

    IEnumerator JumpCooling(float waitsecond)
    {
        yield return new WaitForSeconds(waitsecond);
        bCanjump = true;
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
