using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monedero : MonoBehaviour
{
    public int monedas;
    public Text monedasTxt;

    private void Start()
    {
    }

    public void SumarMonedas(int cantidad)
    {
        Pieces.instance.ObtenerMonedas(cantidad);
        monedas += cantidad;
        monedasTxt.text = "" + monedas;
    }
}
