using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public static Pieces instance;
    private int _Pieces;
    public int piecesNumberUI;

    public int myPieces
    {
        get { return _Pieces; }
        set { _Pieces = value; }
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        myPieces = GameManager.gameManager.totalPieces;
        piecesNumberUI = myPieces;
    }

    public void ObtenerMonedas(int pieces)
    {
        myPieces += pieces;
        piecesNumberUI += pieces;
    }

    public void Comprar(int pago)
    {
        GameManager.gameManager.totalPieces -= pago;
        myPieces = GameManager.gameManager.totalPieces;
        piecesNumberUI = myPieces;
    }
}
