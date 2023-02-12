using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool isGameOver = false;
    public GameObject panelGameOver;
    public Text meters;
    public Text pieces;

    Rigidbody2D myRigidBody2D;
    public float enemySpeed;
    public float force;
    Vector2 distanceToPlayer;
    Ball_Player player;
    public int lifeCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Ball_Player>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = transform.position - player.transform.position;

        if (distanceToPlayer.magnitude < 1)
        {
            myRigidBody2D.velocity = Vector2.up * enemySpeed * Time.deltaTime;
        }
        else if (distanceToPlayer.magnitude > 1 && distanceToPlayer.magnitude < 2)
        {
            myRigidBody2D.velocity = Vector2.up * (enemySpeed + 15f) * Time.deltaTime;
        }
        else
        {
            myRigidBody2D.velocity = Vector2.up * force * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            MoveToCheckPoint();
        }
    }

    void MoveToCheckPoint()
    {
        if(lifeCount > 1)
        {
            int checkpointActivated = FindObjectOfType<CheckpointManager>().checkpointActivated;
            player.transform.position = FindObjectOfType<CheckpointManager>().CheckPointTransform(checkpointActivated);
            transform.position = new Vector2(transform.position.x, player.transform.position.y - 10);
            lifeCount--;
        }
        else
        {
            isGameOver = true;
            OpenGameOverPanel();
        }

    }

    public void OpenGameOverPanel()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }

        if (isGameOver)
        {
            panelGameOver.SetActive(true);
            meters.text = "Meters: " + (int)FindObjectOfType<Ball_Player>().gameObject.transform.position.y;
            pieces.text = "Pieces: " + FindObjectOfType<Monedero>().monedas.ToString();

            //agregar las pieces al monedero pieces
            FindObjectOfType<Pieces>().ObtenerMonedas(FindObjectOfType<Monedero>().monedas);
            isGameOver = false;
        }
        else
        {
            return;
        }
        
    } 
}
