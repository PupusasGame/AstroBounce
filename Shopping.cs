using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour
{
    //Para Activar o Desactivar cajas
    public Sprite cajaActiva;
    public Sprite cajaInactiva;
    public Image[] cajasImage = new Image[9];
    public Image[] candados = new Image[9];
    public Image[] ballImages = new Image[9];
    public Sprite[] ballSprites = new Sprite[9];
    public int indexCajaActiva;

    //Desbloquear Balls
    public int[] ballPrices = new int[9];
    public bool[] ballUnlock = new bool[9];

    public Text monedasText;
    // Start is called before the first frame update
    void Start()
    {
        monedasText.text = GameManager.gameManager.totalPieces.ToString();
        for (int i = 0; i < cajasImage.Length; i++)
        {
            //bucle para saber cual está desbloqueada
            if (GameManager.gameManager.ballUnlock[i])
            {
                Desbloquear(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cambia la imagen del panel activo
    public void CambiarImagenPanelActivo(int panel)
    {
        for (int i = 0; i < cajasImage.Length; i++)
        {
            if(i == panel)
            {
                indexCajaActiva = panel;
                cajasImage[panel].sprite = cajaActiva;
                if (ballUnlock[indexCajaActiva])
                {
                    //Asignamos valor del sprite al gamemanager
                    GameManager.gameManager.playersprite = indexCajaActiva;
                    GameManager.gameManager.SaveData();
                }
            }
            else
            {
                cajasImage[i].sprite = cajaInactiva;
            }
        }
    }

    //Desbloquear ball
    public void DesbloquearBall()
    {
        //Si tenemos el suficiente dinero
        if(GameManager.gameManager.totalPieces >= ballPrices[indexCajaActiva])
        {
            //Si la ball no está desbloqueada
            if (!ballUnlock[indexCajaActiva])
            {
                //Desbloquearla
                GameManager.gameManager.ballUnlock[indexCajaActiva] = true;
                GameManager.gameManager.playersprite = indexCajaActiva;
                Desbloquear(indexCajaActiva);
                FindObjectOfType<Pieces>().Comprar(ballPrices[indexCajaActiva]);
                monedasText.text = GameManager.gameManager.totalPieces.ToString();
                GameManager.gameManager.playersprite = indexCajaActiva;
                GameManager.gameManager.SaveData();
            }
            else
            {
                return;
            }    
        }
        else
        {
            //Si no nos alcanza la plata no hacemos nada
            return;
        }
    }

    public void Desbloquear(int cajanumber)
    {
        ballUnlock[cajanumber] = true;
        candados[cajanumber].sprite = null;
        candados[cajanumber].color = new Color(0, 0, 0, 0);
        ballImages[cajanumber].sprite = ballSprites[cajanumber];
    }
}
