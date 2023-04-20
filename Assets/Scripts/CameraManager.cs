using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    

    private int width;
    private int height;
    void Start(){
        this.width = CrossSceneInfoManager.currentLevelGridWidth;
        this.height = CrossSceneInfoManager.currentLevelGridHeight;
        Camera.main.orthographicSize = Mathf.Max(width,height); 
        this.transform.position = new Vector3( (float)width / 2f - 0.5f, (float)height / 2f + height / 5f, -10f);
    }
}
