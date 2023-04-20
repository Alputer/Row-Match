using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;


public class MainSceneUIManager : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject popupCanvas;


    public Button mainMenuButton;
    public List<Button> levelButtons;

    public Sprite lockedLevelButtonImage;

    public Sprite unlockedLevelButtonImage;
    private const string levelsSceneName = "GamePlay";

    void Awake(){
        levelButtons = Resources.FindObjectsOfTypeAll<Button>().ToList();
        levelButtons.RemoveAll(s => s.transform.parent == null || s.transform.parent.parent == null || s.transform.parent.parent.name != "LevelsContainer");

        for(int i=0;i<levelButtons.Count;i++){

            int siblingIndex = (int) levelButtons[i].transform.parent.transform.GetSiblingIndex();
            levelButtons[i].onClick.AddListener(() => OnButtonClicked(siblingIndex));

            if(CrossSceneInfoManager.isLocked[siblingIndex]){
            levelButtons[i].GetComponent<Image>().sprite = lockedLevelButtonImage;
            }
            else{
                levelButtons[i].GetComponent<Image>().sprite = unlockedLevelButtonImage;
            }
            
        }

    }

    void Start(){
        
        for(int i=0;i<levelButtons.Count;i++){
            TMP_Text scoreObject = levelButtons[i].transform.parent.Find("Score Text").GetComponent<TMP_Text>();
            levelButtons[i].transform.parent.Find("Score Text").GetComponent<TMP_Text>();
            int siblingIndex = levelButtons[i].transform.parent.transform.GetSiblingIndex(); // Index of the button in Game object tree

            if(CrossSceneInfoManager.isLocked[siblingIndex]){
                scoreObject.SetText("Locked Level");
            }  
            else{
                scoreObject.SetText($"Highest Score: {CrossSceneInfoManager.maxScores[siblingIndex]}");
            }

        }

        
    }

    public void openLevelsPopup(){

        mainCanvas.SetActive(false);
        popupCanvas.SetActive(true);

    }

    public void closeLevelsPopup(){

        popupCanvas.SetActive(false);
        mainCanvas.SetActive(true);

    }
    private void OnButtonClicked(int buttonIndex){
        Debug.Log(buttonIndex);
        if(!CrossSceneInfoManager.isLocked[buttonIndex]){
            CrossSceneInfoManager.setupLevelVariables(buttonIndex + 1); 
            SceneManager.LoadScene(levelsSceneName);
        }
    }
}
