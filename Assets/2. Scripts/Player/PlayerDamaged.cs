using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerDamaged : MonoBehaviour
{
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


        

    // Start is called before the first frame update
    void Start()
    {
        prohp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
