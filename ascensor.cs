using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensor : MonoBehaviour
{
    public Transform suelo;
    public float speed;
    public bool activaded;
    float stopTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activaded)
        {
            stopTime -= Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if(stopTime <= 0)
        {
            activaded = false;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            stopTime = 1.5f;
            suelo.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            activaded = true;
        }
    }
}
