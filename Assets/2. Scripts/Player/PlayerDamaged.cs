using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerDamaged : MonoBehaviour
{
    public AudioClip damaged;
    private AudioSource audio;
    private PlayerMove playermove;

    public delegate void ReflectHP(int hpleft);
    public event ReflectHP drefHP;
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
    }

    public void DamageThis(int damage,Vector2 direction)
    {
        if(!isInvincible)
        {
            prohp -= damage;
            isInvincible = true;
            audio.PlayOneShot(damaged, 0.7f);
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
    }
}
