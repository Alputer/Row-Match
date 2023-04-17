using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int moveCount;
    public int maxScore;
    public int currentScore;

    public float displayScore;

    public float scoreSpeed;

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

        if(currentScore - displayScore > 0.2f)
        this.displayScore = Mathf.Lerp(displayScore, currentScore, scoreSpeed * Time.deltaTime);
        else
        this.displayScore = currentScore;
        uiManager.currentScoreText.text = displayScore.ToString("0");

    }

    public void moveMade(){

        this.moveCount--;
        uiManager.moveCountText.text = moveCount.ToString();

    }

    public void matchFound(Gem.GemType type){

        switch (type)

    {
        case Gem.GemType.red:
            this.currentScore += 100;
            break;

        case Gem.GemType.green:
            this.currentScore += 150;
            break;

        case Gem.GemType.blue:
            this.currentScore += 200;
            break;

        case Gem.GemType.yellow:
            this.currentScore += 250;
            break;

        default:
            Debug.Log("Gem Type doesn't match any of the options, something went wrong.");
            break;
    }

    }
    private void endRound(){
        Debug.Log("Level ended");
        /*
        if(currentScore > maxScore){
            UpdateMaxScore();
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
