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

    private bool levelEndedTriggered = false;

    public AudioSource mainAudio;

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

        if(levelEnded && !levelEndedTriggered && Board.currentState == BoardManager.BoardState.move){
           levelEndedTriggered = true;
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
            this.currentScore += 100 * Board.width;
            break;

        case Gem.GemType.green:
            this.currentScore += 150 * Board.width;
            break;

        case Gem.GemType.blue:
            this.currentScore += 200 * Board.width;
            break;

        case Gem.GemType.yellow:
            this.currentScore += 250 * Board.width;
            break;

        default:
            Debug.Log("Gem Type doesn't match any of the options, something went wrong.");
            break;
    }

    }
    public void endRound(){

        CrossSceneInfoManager.isFirstLoad = false;    

        this.mainAudio.gameObject.SetActive(false); 
        
        if(CrossSceneInfoManager.currentLevel != 10 && this.currentScore > 0){
        CrossSceneInfoManager.isLocked[CrossSceneInfoManager.currentLevel] = false;
        }

        if(currentScore > maxScore){
            
            CrossSceneInfoManager.maxScores[CrossSceneInfoManager.currentLevel - 1] = currentScore;
            CrossSceneInfoManager.shouldCelebrate = true;
            StartCoroutine(returnMainScreen());
        }
        else{
            
            CrossSceneInfoManager.shouldCelebrate = false;
            StartCoroutine(returnMainScreen());
            
        }
    }

    public IEnumerator returnMainScreen(){

        if(!CrossSceneInfoManager.shouldCelebrate){

        yield return new WaitForSeconds(1.2f);
        SFXManager.instance.playGameEndLosingSound();
        yield return new WaitForSeconds(1.9f);
        }

        else{

        yield return new WaitForSeconds(2f);

        }

        SceneManager.LoadScene(mainSceneName);
    }
}
