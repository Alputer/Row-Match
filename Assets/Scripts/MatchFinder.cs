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

            for(int j=0;j<board.width - 4;j++){
                if(board.allGems[j, i] != null && board.allGems[j + 1, i] != null && board.allGems[j + 2, i] != null && board.allGems[j + 3, i] != null && board.allGems[j + 4, i]){
                    if(board.allGems[j, i].type == board.allGems[j + 1, i].type && board.allGems[j, i].type == board.allGems[j + 2, i].type && board.allGems[j, i].type == board.allGems[j + 3, i].type && board.allGems[j, i].type == board.allGems[j + 4, i].type){
                        board.allGems[j, i].isMatched = true;
                        board.allGems[j + 1, i].isMatched = true;
                        board.allGems[j + 2, i].isMatched = true;
                        board.allGems[j + 3, i].isMatched = true;
                        board.allGems[j + 4, i].isMatched = true;
                        currentMatches.Add(board.allGems[j, i]);
                        currentMatches.Add(board.allGems[j + 1, i]);
                        currentMatches.Add(board.allGems[j + 2, i]);
                        currentMatches.Add(board.allGems[j + 3, i]);
                        currentMatches.Add(board.allGems[j + 4, i]);
                    }
                }

            }
        }
    }
}
