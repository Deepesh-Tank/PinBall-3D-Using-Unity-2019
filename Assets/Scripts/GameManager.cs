using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int startBallAmount = 3;
    int currentBallAmount;
    int activeBallsOnPlayfield;
    // SPAwn ball

    public GameObject ballPrefab;
    public Transform spawnPoint;
    public Transform multiSpawnPoint;

    //TARGET
    public TargetSet targetSet1;
     
    bool gameStarted;



    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //currentBallAmount = startBallAmount;
        ResetGame();
        
    }
    public void ResetGame()
    {
        currentBallAmount = startBallAmount;
        UIManager.instance.UpdateBallText(currentBallAmount);
        UIManager.instance.ShowGameOverPanel(false);
        ScoreManager.instance.ResetScore();
        MissionManager.instance.ResetAllMissions();
        CreateNewBall();
    }
    public void CreateNewBall()
    {
        if(activeBallsOnPlayfield==0 && currentBallAmount>0)
        {
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            targetSet1.ResetAllTargets();
            UpdateBallsOnPlayfield(+1);
            currentBallAmount--;
            UIManager.instance.UpdateBallText(currentBallAmount);
           
        }
        else
        {
            //LOST GAME FUCNTION
            Debug.Log("Game Over");
            UIManager.instance.ShowGameOverPanel(true);
        }
        

    }
    public void StartMultiBall()
    {
        StartCoroutine(Mutliball());
    }
    public void UpdateBallsOnPlayfield(int amount)
    {
        activeBallsOnPlayfield += amount;
    }
    IEnumerator Mutliball()
    {
        int amount = 3;
        while(amount>0)
        {
            Instantiate(ballPrefab, multiSpawnPoint.position, Quaternion.identity);
            amount--;
            UpdateBallsOnPlayfield(+1);
            yield return new WaitForSeconds(1f);
        }
        
    }

}
