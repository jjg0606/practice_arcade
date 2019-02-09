using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.white;
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3.0f);
        while (img.color.a>0.0f)
        {
            img.color = new Color(1.0f, 1.0f, 1.0f, img.color.a - 0.02f);
            yield return new WaitForSeconds(0.05f);
        }
        
    }
}
