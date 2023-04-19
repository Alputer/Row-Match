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

    public MatchFinder matchFinder;

    public LevelManager levelManager;

    public enum BoardState {wait, move};

    public BoardState currentState = BoardState.move;
   
   void Awake(){
    this.matchFinder = FindObjectOfType<MatchFinder>();
    this.levelManager = FindObjectOfType<LevelManager>();
   }
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

                Gem gemToUse = gems[Random.Range(0, gems.Length - 1)];

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

    private void replaceMatchedGemAt(Vector2Int pos){
        //Double check
        if(this.allGems[pos.x, pos.y] != null && this.allGems[pos.x, pos.y].isMatched){
            Destroy(this.allGems[pos.x, pos.y].gameObject);
            SpawnGem(new Vector2Int(pos.x, pos.y), gems[gems.Length - 1]);
            allGems[pos.x, pos.y].isMatched = true;
        }
    }

    public void replaceMatches(){
        for(int i=0;i<matchFinder.currentMatches.Count;i++){
                
                for(int j=0;j<this.width;j++){

                replaceMatchedGemAt(new Vector2Int(j, matchFinder.currentMatches[i].width));
    
                }
                this.levelManager.matchFound(matchFinder.currentMatches[i].type);

        }
        matchFinder.currentMatches.Clear();
    }
    
}
