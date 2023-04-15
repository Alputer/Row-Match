using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    [HideInInspector]
    public Vector2Int pos;
    [HideInInspector]
    public BoardManager BoardManager;
    void Start()
    {
        
    }

    // Update is called once per frame

    public void SetupGem(Vector2Int pos, BoardManager boardManager){
        this.pos = pos;
        this.BoardManager = boardManager;
    }
}
