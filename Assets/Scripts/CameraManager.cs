using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    

    public int width;
    public int height;

    public float scale;
    void Start(){
        
        Camera.main.orthographicSize = Mathf.Max(width,height); 
        this.transform.position = new Vector3( (float)width / 2f - 0.5f, (float)height / 2f - 0.5f, -10f);

        
    }
}
