using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portales : MonoBehaviour
{
    public Transform portalA;
    public Transform portalB;
    public Rigidbody2D ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distanceToPortalA = ball.gameObject.transform.position - portalA.transform.position;
        Vector2 distanceToPortalB = ball.gameObject.transform.position - portalB.transform.position;

        //Debug.Log("Distancia portalA" + distanceToPortalA.magnitude);
        //Debug.Log("Distancia portalA" + distanceToPortalB.magnitude);

        if (distanceToPortalA.magnitude < 0.1f)
        {
            ball.transform.position = portalB.position;
            //ball.AddForce(Vector2.left, ForceMode2D.Impulse);
        }
        
    }
}
