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

    public GameObject celebrationCanvas;

    public GameObject levelsContainer;


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

        if(CrossSceneInfoManager.shouldCelebrate){
            StartCoroutine(celebrate());
        }
        
        if(!CrossSceneInfoManager.isFirstLoad){
            openLevelsPopup();
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
        Debug.Log($"Level Num: {buttonIndex + 1}");
        if(!CrossSceneInfoManager.isLocked[buttonIndex]){
            CrossSceneInfoManager.setupLevelVariables(buttonIndex + 1); 
            SceneManager.LoadScene(levelsSceneName);
        }
    }

    private IEnumerator celebrate(){
            mainCanvas.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            celebrationCanvas.SetActive(true);
            yield return new WaitForSeconds(4.5f);
            celebrationCanvas.SetActive(false);
            popupCanvas.SetActive(true);
    }
}
