using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform connected;
    public AudioClip portalsfx;
    private AudioSource audio;
    private Transform trPlayer;
    private static bool bPortalAvail=true;
    // Update is called once per frame
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //transform.Rotate(0, 0, 1000*Time.deltaTime);
        if(trPlayer!=null&&Input.GetAxisRaw("Vertical")>0&&bPortalAvail)
        {
            trPlayer.position = connected.position;
            bPortalAvail = false;
            audio.PlayOneShot(portalsfx, 1.0f);
            StartCoroutine(PortalCoolTime());
        }
    }

    IEnumerator PortalCoolTime()
    {
        yield return new WaitForSeconds(2.0f);
        bPortalAvail = true;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.transform.tag=="PLAYER")
        {
            trPlayer = coll.transform;
        }        
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.tag == "PLAYER")
        {
            trPlayer = null;
        }
    }

}
