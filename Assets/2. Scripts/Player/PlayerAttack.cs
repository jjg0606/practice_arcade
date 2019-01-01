using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    public GameObject attackEffect;
    public AudioSource audiosource;
    public AudioClip attackSfx;
    

    private readonly int animTrAttack = Animator.StringToHash("TrAttack");
    private Animator anim;
    private BoxCollider2D boxcoll2d;
    private bool isAttackNow = false;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        boxcoll2d = GetComponents<BoxCollider2D>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(!isAttackNow)
                StartCoroutine(Attack());            
        }
    }

    IEnumerator Attack()
    {
        isAttackNow = true;
        anim.SetTrigger(animTrAttack);
        audiosource.PlayOneShot(attackSfx, 1.0f);
        yield return new WaitForSeconds(0.6f);
        isAttackNow = false;
    }


    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "ENEMY" && isAttackNow)
        {
            Vector2 direction=new Vector2();
            direction=coll.gameObject.transform.position-transform.position;
            coll.gameObject.GetComponent<EnemyDamaged>().DamageThis(damage,attackEffect,direction.normalized);
        }
    }



}
