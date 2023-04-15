using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int width;
    public int height;

    public GameObject tileBackgroundPrefab;
   
    void Start(){

        Setup();

    }

    private void Setup(){
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                Vector2 pos = new Vector2(x,y);
                GameObject backgroundTile = Instantiate(tileBackgroundPrefab, pos, Quaternion.identity);
                backgroundTile.transform.parent = transform; // So that tiles don't fill the whole screen in unity game object menu
                backgroundTile.name = $"BG Tile - {x+1}, {y+1}";
            }
        }
    }
    
}
