using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumible : MonoBehaviour
{
    public bool falling;
    public bool left;
    public GameObject[] plataformas = new GameObject[10]; 

    void Update()
    {
        if (falling)
        {
            if (left)
            {
                StartCoroutine(fallingPlatformsLeft());
                falling = false;
                StartCoroutine(ResetPlataformaLeft());
            }
            else
            {
                StartCoroutine(fallingPlatformsRight());
                falling = false;
                StartCoroutine(ResetPlataformaRight());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            falling = true;
        }
    }
    
    IEnumerator fallingPlatformsLeft()
    {
        for (int i = 0; i < plataformas.Length; i++)
        {
            yield return new WaitForSeconds(.30f);
            plataformas[i].SetActive(false);
            gameObject.GetComponent<Collider2D>().offset = new Vector2(
                gameObject.GetComponent<Collider2D>().offset.x + .075f,
                gameObject.GetComponent<Collider2D>().offset.y);
        }
    }

    IEnumerator fallingPlatformsRight()
    {
        for (int i = 0; i < plataformas.Length; i++)
        {
            yield return new WaitForSeconds(.30f);
            plataformas[9-i].SetActive(false);
            gameObject.GetComponent<Collider2D>().offset = new Vector2(
                gameObject.GetComponent<Collider2D>().offset.x - .075f,
                gameObject.GetComponent<Collider2D>().offset.y);
        }
    }

    IEnumerator ResetPlataformaLeft()
    {
        yield return new WaitForSeconds(3.3f);
        for (int i = 0; i < plataformas.Length; i++)
        {
            plataformas[i].SetActive(true);
            gameObject.GetComponent<Collider2D>().offset = new Vector2(
                gameObject.GetComponent<Collider2D>().offset.x - .075f,
                gameObject.GetComponent<Collider2D>().offset.y);
        }
    }

    IEnumerator ResetPlataformaRight()
    {
        yield return new WaitForSeconds(3.3f);
        for (int i = 0; i < plataformas.Length; i++)
        {
            plataformas[i].SetActive(true);
            gameObject.GetComponent<Collider2D>().offset = new Vector2(
                gameObject.GetComponent<Collider2D>().offset.x + .075f,
                gameObject.GetComponent<Collider2D>().offset.y);
        }
    }
}
