using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            FindObjectOfType<Monedero>().SumarMonedas(1);
            StartCoroutine(DeleteCoin());
        }
    }

    IEnumerator DeleteCoin()
    {
        yield return new WaitForSeconds(.10f);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
