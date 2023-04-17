using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int moveCount;
    public int maxScore;
    public int currentScore;

    public bool levelEnded = false;

    private BoardManager Board;

    private UIManager uiManager;
    // Start is called before the first frame update
    void Awake()
    {
        this.uiManager = FindObjectOfType<UIManager>();
        this.Board = FindObjectOfType<BoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moveCount <= 0){
            levelEnded = true;
        }

        if(levelEnded && Board.currentState == BoardManager.BoardState.move){
            endRound();
        }

    }

    public void moveMade(){
        this.moveCount--;
        uiManager.moveCountText.text = moveCount.ToString();
    }
    private void endRound(){
        Debug.Log("Level ended");
        /*
        if(currentScore > maxScore){
            DoCelebrityAnimation();
            GoHomeScreen();
        }
        else{
            DoLosingAnimation();
            GoHomeScreen();
        }
        */
    }
}
