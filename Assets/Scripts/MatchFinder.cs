using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MatchFinder : MonoBehaviour
{

    private BoardManager board;

    public List<Gem> currentMatches = new List<Gem>();
    
    void Awake()
    {
        this.board = FindObjectOfType<BoardManager>(); 
    }

    public void findAllMatches(){
        for(int i=0;i<board.height;i++){
            Gem.GemType candidateGemType = board.allGems[0, i].type;
            bool isRowMatch = true; 
            for(int j=1;j<board.width;j++){

                if(board.allGems[j,i].type != candidateGemType){
                    isRowMatch = false;
                    break;
                }

            }

            if(isRowMatch){

                for(int j=0;j<board.width;j++){
                    board.allGems[j, i].isMatched = true;
                    currentMatches.Add(board.allGems[j, i]);
                }

            }

        }
    }
}
