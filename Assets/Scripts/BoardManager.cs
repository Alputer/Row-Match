using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int width;
    public int height;

    public GameObject tileBackgroundPrefab;

    // Store the prototypes
    public Gem[] gems;

    // Stores the jems that are displayed in the game
    public Gem[,] allGems;

    public float gemSpeed;
   
    void Start(){

        allGems = new Gem[width, height];
        Setup();

    }

    private void Setup(){

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                Vector2 pos = new Vector2(x,y);
                GameObject backgroundTile = Instantiate(tileBackgroundPrefab, pos, Quaternion.identity);
                backgroundTile.transform.parent = transform; // So that tiles don't fill the whole screen in unity game object menu
                backgroundTile.name = $"BG Tile - {x}, {y}";

                Gem gemToUse = gems[Random.Range(0, gems.Length)];

                SpawnGem(new Vector2Int(x, y), gemToUse);
            }
        }
    }

    private void SpawnGem(Vector2Int pos, Gem gemToSpawn){
        Gem gem = Instantiate(gemToSpawn, new Vector3(pos.x, pos.y, 0f) , Quaternion.identity);
        gem.transform.parent = this.transform;
        gem.name = $"Gem - {pos.x},{pos.y}";
        allGems[pos.x, pos.y] = gem;

        gem.SetupGem(pos, this);
    }
    
}
