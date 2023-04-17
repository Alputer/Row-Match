using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MatchFinder : MonoBehaviour
{

    private BoardManager board;

    // Line of the match and type of the gems 
    public List<(Gem.GemType type, int width)> currentMatches = new List<(Gem.GemType, int)>();
    
    void Awake()
    {
        this.board = FindObjectOfType<BoardManager>(); 
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

            }

        }
    }
}
