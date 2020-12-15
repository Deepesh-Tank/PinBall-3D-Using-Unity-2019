using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission
{
    public int missionId;
    public string description;
    [Space]
    public bool active;
    public bool permanentActive;
    public bool missionComplete;
    [Space]
    public bool restartOnNextBall;
    public bool stopOnBallEnd;
    public bool resetOnComplete;
    public bool canTriggerMultiBall;
    [Space] 
    public float timeToComplete;
    [Space]
    public int score;
    public int amountToComplete;
    public int currentAmount;

    public void ResetMission()
    {
        if (resetOnComplete)
        {
            active = false;
            missionComplete = false;
            currentAmount = 0;
        }
    }
    public void DeactivateMission()
    {
        if(permanentActive)
        {
            active = true;
        }
        else
        {
            active = false;
        }
        
        currentAmount = 0;
    }
    public void UpdateMission()
    {
        if(active&&!missionComplete)
        {
            currentAmount++;
            //CHECK IF MISSION IS COMPLETE
            CheckMissionComplete();
        }
    }
    void CheckMissionComplete()
    {
        if(currentAmount >= amountToComplete)
        {
            missionComplete = true;
            active = false;
            if(timeToComplete>0)
            {
                //STOP THE TIMER > MISSION MANAGER
                MissionManager.instance.StopTimer();
            }
            if(canTriggerMultiBall)
            {
                GameManager.instance.StartMultiBall();
            }

            ScoreManager.instance.AddScore(score);

            ResetMission();
            Debug.Log("Mission Complete");
        }
        
    } 
    public bool GetMissionActive()
    {
        return active;
    }
}
