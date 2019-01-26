using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("damaged");
        coll.gameObject.GetComponent<PlayerDamaged>().prohp-=damage;
    }
}
