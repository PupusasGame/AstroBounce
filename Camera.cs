using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject pausaPanel;
    public Text metros;
    public Text vidas;
    public Slider sliderMetros;
    public bool paused;
    public Transform target;
    public float smoothSpeed;
    public Vector3 offsetPosition;

    private void Update()
    {
        paused = false;
        metros.text = ((int)target.transform.position.y).ToString() + "M";
        vidas.text = FindObjectOfType<Enemy>().lifeCount + "/3";
        sliderMetros.value = (int)target.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, target.transform.position.y + 1f, transform.position.z);
        Vector3 wantedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = wantedPosition;
    }

    public void PauseBallGame()
    {
        paused = true;
        pausaPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeBallGame()
    {
        paused = false;
        Time.timeScale = 1;
        pausaPanel.SetActive(false);
    }

    public void Reinicio()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadBallGameScene(string sceneName)
    {
        if(GameManager.gameManager != null)
        {
            GameManager.gameManager.totalPieces += FindObjectOfType<Monedero>().monedas;
            GameManager.gameManager.SaveData();//Guardando!---!
            GameManager.gameManager.GameOver();
            GameManager.gameManager.CallAd();
        }
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
