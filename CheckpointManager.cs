using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Transform[] checkpoints = new Transform[6];
    public int checkpointActivated;

    public void ActivateCheckPoint(int checkpointToActivate)
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if(i == checkpointToActivate)
            {
                checkpoints[i].gameObject.GetComponent<CheckPoint>().checkpointActivated = true;
                checkpoints[i].gameObject.GetComponent<AudioSource>().Play();
                checkpointActivated = i;
            }
            else
            {
                checkpoints[i].gameObject.GetComponent<CheckPoint>().checkpointActivated = false;
            }
        }
    }
    
    public Vector2 CheckPointTransform (int checkpoint)
    {
        return checkpoints[checkpoint].transform.position;
    }
}
