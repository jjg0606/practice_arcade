using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerDamaged : MonoBehaviour
{
    public AudioClip damaged;
    public AudioClip dead;
    private AudioSource audio;
    private PlayerMove playermove;
    private Animator anim;
    private readonly int animInvincible = Animator.StringToHash("isInvincible");
    private readonly int animIsDead = Animator.StringToHash("isDead");
    private readonly int animNewStart = Animator.StringToHash("newStart");
    private PlayerState state;

    public delegate void ReflectHP(int hpleft);
    public delegate void deleDead();
    public event ReflectHP drefHP;
    public event deleDead edead;
    public int maxhp = 6;
    public int prohp
    {
        get
        {
            return currhp;
        }
        set
        {
            currhp = value;
            drefHP(currhp);
            if(currhp==0)
            {
                PlayerDead();
            }
        }
    }

    private int currhp;
    private bool isInvincible = false;


        

    // Start is called before the first frame update
    void Start()
    {
        prohp = maxhp;
        audio = GetComponent<AudioSource>();
        playermove = GetComponent<PlayerMove>();
        anim = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
    }

    public void PlayerDead()
    {
        anim.SetTrigger(animIsDead);
        state.isLiving = false;
        audio.PlayOneShot(dead, 1.0f);
        edead();
    }

    public void DamageThis(int damage,Vector2 direction)
    {
        if(!isInvincible&&state.isLiving)
        {
            prohp -= damage;
            isInvincible = true;
            audio.PlayOneShot(damaged, 0.7f);
            anim.SetBool(animInvincible, true);
            StartCoroutine(Invincible(direction));
        }
    }

    IEnumerator Invincible(Vector2 direction)
    {
        playermove.plusCalivec(direction);
        yield return new WaitForSeconds(0.2f);
        playermove.plusCalivec(-direction);
        yield return new WaitForSeconds(0.4f);
        yield return isInvincible = false;
        anim.SetBool(animInvincible, false);
    }
}
