using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HS : MonoBehaviour
{
    public GameManager gm;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Asteroid"))
        {
            StartCoroutine(Death());
        }
        else if (col.CompareTag("UFO"))
        {
            StartCoroutine(Death());
        }
    }

    public IEnumerator Death()
    {
        gm.CanPlay = false;

        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
        gm.ShowResult();
    }

}