using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainSceneUIManager : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject popupCanvas;

    public Button mainMenuButton;
    public List<Button> levelButtons;
    private const string levelsSceneName = "GamePlay";

    void Awake(){
        levelButtons = Resources.FindObjectsOfTypeAll<Button>().ToList();
        levelButtons.RemoveAll(s => s.transform.parent == null || s.transform.parent.parent == null || s.transform.parent.parent.name != "LevelsContainer");

        for(int i=0;i<levelButtons.Count;i++){


            int tempVal = i;

            if(levelButtons[tempVal].transform.parent.name[6] == '0'){
                levelButtons[i].onClick.AddListener(() => OnButtonClicked(9));
                continue;
            }

            int currIndex = (int) levelButtons[tempVal].transform.parent.name[5] - 49;
            levelButtons[i].onClick.AddListener(() => OnButtonClicked(currIndex));
        }

    }

    void Start(){     
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
        if(!CrossSceneInfoManager.isLocked[buttonIndex])
            SceneManager.LoadScene(levelsSceneName);
    }
}
