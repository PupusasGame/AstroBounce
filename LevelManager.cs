using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public string[] levels = new string[0];
    public GameObject[] buttons = new GameObject[3];


    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "main")
        {
            DesbloquearNivel(GameManager.gameManager.nivelUnlock[0], 0);
            DesbloquearNivel(GameManager.gameManager.nivelUnlock[1], 1);
            DesbloquearNivel(GameManager.gameManager.nivelUnlock[2], 2);
        }
        
    }

    public void LoadSceneNumber(int indexLevel)
    {
        SceneManager.LoadScene(levels[indexLevel]);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void DesbloquearNivel(bool nivel, int button)
    {
        switch (nivel)
        {
            case true:
                buttons[button].GetComponent<Button>().enabled = true;
                buttons[button].transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                break;
        }
    }
}
