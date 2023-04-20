using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayUIManager : MonoBehaviour
{

    public TMP_Text maxScoreText;
    public TMP_Text currentScoreText;
    public TMP_Text moveCountText;

   

    // Start is called before the first frame update
    void Start()
    {
        this.moveCountText.SetText(CrossSceneInfoManager.currentLevelMoveCount.ToString());
        this.maxScoreText.SetText(CrossSceneInfoManager.maxScores[CrossSceneInfoManager.currentLevel - 1].ToString()); 
        this.currentScoreText.SetText("0"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
