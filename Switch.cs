using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Transform energyFlow;
    public bool isON = false;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isON)
        {
            energyFlow.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            energyFlow.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag.Equals("Player"))
            {

                GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, .5f);

            if (isON)
                {
                energyFlow.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                }
                else
                {
                energyFlow.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            isON = !isON;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        }

    }
    
}
