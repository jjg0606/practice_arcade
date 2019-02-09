using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public float initialHP;
    public AudioClip beingHit;
    public AudioClip beingDead;
    public float curHP;
    private AudioSource audiosource;
    private Rigidbody2D rigb;
    public bool isInvincible = false;
    public bool isStatic;
    // Start is called before the first frame update
    void Start()
    {
        curHP = initialHP;
        rigb = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
    }

    public void DamageThis(float damage, GameObject damageEffect,Vector2 direction)
    {
        if(!isInvincible)
        {
            curHP -= damage;
            Instantiate(damageEffect, this.transform.position, Quaternion.Euler(0,0,0),this.transform);
            audiosource.PlayOneShot(beingHit, 1.0f);
            if(curHP<=0)
            {
                audiosource.PlayOneShot(beingDead, 1.0f);
                StartCoroutine(IGointToDead());
            }
            isInvincible = true;
            StartCoroutine(Invincible(direction));
        }
        
    }
    // Update is called once per frame

    IEnumerator IGointToDead()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }

    IEnumerator Invincible(Vector2 direction)
    {
        Vector2 po = transform.position;
        for(int i =0;i<4;i++)
        {
            if(rigb.isKinematic&&!isStatic)
            {
                rigb.MovePosition(Vector2.Lerp(po, po + new Vector2(direction.x, 0.0f), 0.25f * i));
            }            
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.4f);

        yield return isInvincible = false;
    }
}
