using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public bool checkpointActivated = false;
    public int checkpointNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<CheckpointManager>().ActivateCheckPoint(checkpointNumber);
            if(checkpointActivated && this.checkpointNumber == 5)
            {
                if (SceneManager.GetActiveScene().name == "level_01")
                {
                    GameManager.gameManager.nivelUnlock[0] = true;
                }
                else if (SceneManager.GetActiveScene().name == "level_02")
                {
                    GameManager.gameManager.nivelUnlock[1] = true;
                }
            }
        }
    }
}
