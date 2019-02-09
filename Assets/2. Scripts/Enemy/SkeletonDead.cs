using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonDead : MonoBehaviour
{
    public EnemyDamaged edamaged;
    private AudioSource Audio;
    public AudioClip victory;
    public Image img;
    private bool isplayed=false;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(edamaged.curHP==0&&!isplayed)
        {
            isplayed = true;
            StartCoroutine(Victory());
            Audio.PlayOneShot(victory, 1.0f);
        }
    }

    IEnumerator Victory()
    {
        
        yield return new WaitForSeconds(5.0f);
        while (img.color.a < 1.0f)
        {
            img.color = new Color(1.0f, 1.0f, 1.0f, img.color.a + 0.02f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(5.0f);
        Application.Quit(0);
    }
}
