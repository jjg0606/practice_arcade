using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [Header("HPbar foreground")]
    public Image[] ihp;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("PLAYER").GetComponent<PlayerDamaged>().drefHP += ReflectHP;
        //PlayerDamaged.drefHP += this.ReflectHP;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReflectHP(int Hpleft)
    {
        int hpleft = Hpleft;
        for(int i=0;i<ihp.Length;i++)
        {
            if(hpleft>2)
            {
                ihp[i].fillAmount = 1.0f;
                hpleft -= 2;
            }
            else 
            {
                ihp[i].fillAmount = hpleft*0.5f;
                hpleft = 0;
            }
        }
    }
}
