using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    public int moveCount;
    public int maxScore;
    public int currentScore;

    public float displayScore;

    public float scoreSpeed;

    public bool levelEnded = false;

    public GameObject celebrationCanvas;

    private BoardManager Board;

    private GamePlayUIManager uiManager;

    private const string mainSceneName = "MainScene";
    // Start is called before the first frame update
    void Awake()
    {
        this.uiManager = FindObjectOfType<GamePlayUIManager>();
        this.Board = FindObjectOfType<BoardManager>();
    }

    void Start(){

        this.moveCount = CrossSceneInfoManager.currentLevelMoveCount;
        this.maxScore  = CrossSceneInfoManager.maxScores[CrossSceneInfoManager.currentLevel - 1];
        this.currentScore = 0;
        this.displayScore = 0;

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
    public void endRound(){

        Debug.Log("Level ended");

        CrossSceneInfoManager.isFirstLoad = false;

        Debug.Log($"CrossSceneInfoManager.isFirstLoad: {CrossSceneInfoManager.isFirstLoad}");
        
        
        if(CrossSceneInfoManager.currentLevel != 10){
        CrossSceneInfoManager.isLocked[CrossSceneInfoManager.currentLevel] = false;
        }

        if(currentScore > maxScore){
            CrossSceneInfoManager.maxScores[CrossSceneInfoManager.currentLevel - 1] = currentScore;
            CrossSceneInfoManager.shouldCelebrate = true;
            StartCoroutine(returnMainScreen(1.2f));
        }
        else{
            
            CrossSceneInfoManager.shouldCelebrate = false;
            StartCoroutine(returnMainScreen(1.2f));
            
        }
    }

    public IEnumerator returnMainScreen(float seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(mainSceneName);
    }
}
