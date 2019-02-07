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

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "PLAYER")
        {
            Vector2 direction = new Vector2();
            direction.x = coll.gameObject.transform.position.x - transform.position.x;
            coll.gameObject.GetComponent<PlayerDamaged>().DamageThis(damage, direction.normalized * 8);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

    }
}
