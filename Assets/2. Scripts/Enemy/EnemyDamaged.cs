using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public float initialHP;
    public AudioClip beingHit;
    public float curHP;
    private AudioSource audiosource;
    private Rigidbody2D rigb;
    private bool isInvincible = false;
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
            
            isInvincible = true;
            StartCoroutine(Invincible(direction));
        }
        
    }
    // Update is called once per frame
    
    

    IEnumerator Invincible(Vector2 direction)
    {
        Vector2 po = transform.position;
        for(int i =0;i<4;i++)
        {
            rigb.MovePosition(Vector2.Lerp(po, po + new Vector2(direction.x, 0.0f), 0.25f * i));
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.4f);

        isInvincible = false;
    }
}
