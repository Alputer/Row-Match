using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MatchFinder : MonoBehaviour
{

    private BoardManager board;

    // Line of the match and type of the gems 
    public List<(Gem.GemType type, int width)> currentMatches = new List<(Gem.GemType, int)>();

    private List<int> matchedRows = new List<int>();
    
    void Awake()
    {
        this.board = FindObjectOfType<BoardManager>(); 

    }

    void Start(){
        this.matchedRows.Add(-1);
        this.matchedRows.Add(board.height);
    }

    public void findAllMatches(){
        for(int i=0;i<board.height;i++){
            Gem currentGem = board.allGems[0, i];
            
            // Already checked.
            if(currentGem.isMatched)
                continue;

            bool isRowMatch = true; 
            for(int j=1;j<board.width;j++){

                if(board.allGems[j,i].type != currentGem.type){
                    isRowMatch = false;
                    break;
                }

            }

            if(isRowMatch){

                for(int j=0;j<board.width;j++){
                    board.allGems[j, i].isMatched = true;
                }
                currentMatches.Add((currentGem.type, currentGem.pos.y));
                matchedRows.Add(currentGem.pos.y);
                matchedRows.Sort();
            }

        }
    }

    public bool isTherePossibleMatch(){            

        bool result = false;

        for(int i=1;i<matchedRows.Count;i++){
            int currentMatchedRow = matchedRows[i];
            int previousMatchedRow = matchedRows[i-1];
            List<int> numOfGems = new List<int>(){0,0,0,0};
            

            for(int j = previousMatchedRow + 1; j < currentMatchedRow;j++){
                for(int k = 0; k < board.width; k++){
                    
                    switch (board.allGems[k, j].type)
                    {

                        case Gem.GemType.red:
                        numOfGems[0]++;
                        break;

                        case Gem.GemType.green:
                        numOfGems[1]++;
                        break;

                        case Gem.GemType.blue:
                        numOfGems[2]++;
                        break;

                        case Gem.GemType.yellow:
                        numOfGems[3]++;
                        break; 

                        default:
                        Debug.Log("Gem Type doesn't match any of the options, something went wrong.");
                        break; 
                                              
                    }
                }
            }


            if(numOfGems[0] >= board.width || numOfGems[1] >= board.width || numOfGems[2] >= board.width || numOfGems[3] >= board.width){
                result = true;
                break;
            }
        }

        return result;
    }

}
