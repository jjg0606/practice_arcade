using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class youdied : MonoBehaviour
{
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("PLAYER").GetComponent<PlayerDamaged>().edead+=triggerDead;
        img = GetComponent<Image>();
    }

    void triggerDead()
    {
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(0.5f);
        while (img.color.a < 1.0f)
        {
            img.color = new Color(1.0f, 1.0f, 1.0f, img.color.a + 0.02f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(5.0f);
        Application.Quit(0);
    }
}
