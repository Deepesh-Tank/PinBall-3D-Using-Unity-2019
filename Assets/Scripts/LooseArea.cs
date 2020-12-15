using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseArea : MonoBehaviour
{
     void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        MissionManager.instance.ResetAllMissions();
        GameManager.instance.UpdateBallsOnPlayfield(-1);
        GameManager.instance.CreateNewBall();
    }
}
