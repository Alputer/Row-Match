using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelsSceneName;
    public void goLevelsScene(){
        SceneManager.LoadScene(levelsSceneName);
    }
}
