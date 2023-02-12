using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralPlatforms : MonoBehaviour
{
    public float speed;
    public GameObject pointA;
    public GameObject pointB;
    public Sprite[] plataformasSprites = new Sprite[9];
    public GameObject[] plataformas = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverPlataforma(0);
        MoverPlataforma(1);
        MoverPlataforma(2);
        MoverPlataforma(3);
        MoverPlataforma(4);
        MoverPlataforma(5);
        MoverPlataforma(6);
        MoverPlataforma(7);
    }

    void MoverPlataforma(int i)
    {
        plataformas[i].transform.position -= new Vector3(0, speed * Time.deltaTime);
        var distance = plataformas[i].transform.position - pointB.transform.position;
        if (distance.magnitude < 1.5f)
        {
            plataformas[i].transform.position = new Vector3(plataformas[i].transform.position.x, pointA.transform.position.y, plataformas[i].transform.position.z);
            plataformas[i].gameObject.GetComponent<SpriteRenderer>().sprite = plataformasSprites[Random.Range(0, 9)];
        }
    }
}
