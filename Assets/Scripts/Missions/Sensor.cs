using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool isStarter; //trigget to start missioin
    public bool isCounter;// count running missions
    public int triggerId;//mission ifd tp trigger
    public bool showGizmos;
    void OnTriggerEnter(Collider col)
    {
        bool startedAlready = MissionManager.instance.CheckIfMissionStarted(triggerId);
        if(isStarter)
        {
            MissionManager.instance.StartMission(triggerId);
        }
        if(isCounter && startedAlready)
        {
            MissionManager.instance.UpdateMission(triggerId);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("bumped");
        bool startedAlready = MissionManager.instance.CheckIfMissionStarted(triggerId);
        if (isStarter)
        {
            MissionManager.instance.StartMission(triggerId);
        }
        if(isCounter && startedAlready)
        {
            MissionManager.instance.UpdateMission(triggerId);
        }
    }
    void OnDrawGizmos()
    {
        if(showGizmos)
        {
            Gizmos.color = new Color32(0, 0, 125, 125);
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }
        
    }
}
