using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    bool timeBasedMissionActive;
    void Awake()
    {
        instance = this;
    }
    public List<Mission> missionList = new List<Mission>();
    public void StartMission(int ID)
    {
        foreach(Mission mission in missionList)
        {
            if(mission.missionId == ID)
            {
                //TIME BASED MISSION
                if(!mission.missionComplete && !mission.active && (mission.timeToComplete>0) && !timeBasedMissionActive)
                {
                    mission.active = true;
                    timeBasedMissionActive = true;
                    //STRAT TIMER
                    StartCoroutine(Timer(mission.timeToComplete, ID));

                }
                //NOT TIME BASE MISSION
                else if(!mission.missionComplete && !mission.active && mission.timeToComplete <= 0)
                {
                    mission.active = true;
                }
            }
        }
    }

    IEnumerator Timer(float t, int ID)
    {
        float tempTime = t;
        while(timeBasedMissionActive && tempTime >0)
        {
            yield return new WaitForSeconds(1f);
            tempTime -= 1;
            Debug.Log(tempTime);
        }
        //DEACTIVATE
        timeBasedMissionActive = false;
        DeactivateMission(ID);
    }
    
    void DeactivateMission(int ID)
    {
        missionList.Find(m => m.missionId == ID).DeactivateMission();
        if(timeBasedMissionActive)
        {
            timeBasedMissionActive = false;
        }
        Debug.Log("Mission has been ended");
    }
    public void UpdateMission(int ID)
    {
        missionList.Find(m => m.missionId == ID).UpdateMission();
    }
    public void StopTimer()
    {
        timeBasedMissionActive = false;
    }
    public bool CheckIfMissionStarted(int ID)
    {
        return missionList.Find(m => m.missionId == ID).GetMissionActive();

    }

    public void ResetAllMissions()
    {
        foreach (Mission mission in missionList)
        {
            if(mission.active)
            {
                mission.DeactivateMission();

            }
        }
        timeBasedMissionActive = false;
    }
}
