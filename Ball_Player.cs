using UnityEngine;

public class Ball_Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;
    public Sprite[] mySprites = new Sprite[5];
    public int metros = 0; 
    bool enSuelo;
    bool flipped = false;

    bool readyTofire = false;
    float timeToFire = .5f;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = mySprites[GameManager.gameManager.playersprite];
    }

    void Update()
    {
        //Si está en el suelo
        if (enSuelo)
        {
            if (Input.GetMouseButtonDown(0) /*|| Input.touchCount > 0*/) //Salto
            {
                //Touch touch = Input.GetTouch(0);
                //if (touch.phase == TouchPhase.Began)
                rigidbody2d.AddForce(Vector2.up * 105f, ForceMode2D.Impulse);
                GetComponent<AudioSource>().Play();
            }
        }
        

        //movimiento pelota
        if (flipped)
        {
            //rigidbody2d.AddForce(Vector2.right, ForceMode2D.Impulse);
            rigidbody2d.velocity += new Vector2(1 * 1.55f * Time.deltaTime, 0);
            spriteRenderer.flipX = false;
        }
        else
        {
            //rigidbody2d.AddForce(Vector2.left, ForceMode2D.Impulse);
            rigidbody2d.velocity += new Vector2(1 * -1.55f * Time.deltaTime, 0);
            spriteRenderer.flipX = true;
        }

        if (readyTofire)
        {
            timeToFire -= Time.deltaTime;
            if (timeToFire < 0)
            {
                rigidbody2d.velocity = new Vector2(0, 1 * Time.deltaTime * 500);
                readyTofire = false;
            }
        }
        else
        {
            timeToFire = .5f;
        }
    }

    //Al tener contacto con
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Goal"))
        {
            FindObjectOfType<Enemy>().isGameOver = true;
            FindObjectOfType<Enemy>().OpenGameOverPanel();
        }

        if(collision.gameObject.tag.Equals("fire"))
        {
            readyTofire = true;
        }

        if (collision.gameObject.tag == "suelo")
        {
            enSuelo = true;
        }

        //si toca la pared
        if (collision.gameObject.tag == "pared_izq")
        {
            flipped = true;
        }

        if (collision.gameObject.tag == "pared_der")
        {
            flipped = false;
        }
        
        if(collision.gameObject.tag == "pared_soporte_izq")
        {
            flipped = true;
            rigidbody2d.AddForce(Vector2.right, ForceMode2D.Impulse);
            rigidbody2d.velocity += new Vector2(1 * 1.55f * Time.deltaTime, 20f * Time.deltaTime);
        }

        if (collision.gameObject.tag == "pared_soporte_der")
        {
            flipped = false;
            rigidbody2d.AddForce(Vector2.left, ForceMode2D.Impulse);
            rigidbody2d.velocity += new Vector2(1 * -1.55f * Time.deltaTime, 20f * Time.deltaTime);
        }
    }

    //Salta la plataforma con tag suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            enSuelo = false;
        }
    }

    public void ChangeMySprite(int mySpriteSelection)
    {
        spriteRenderer.sprite = mySprites[mySpriteSelection];
    }
}
