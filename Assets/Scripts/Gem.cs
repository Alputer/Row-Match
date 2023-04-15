using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    
    public Vector2Int pos;
    
    public BoardManager Board;

    // To detect swipe  
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;

    private bool mousePressed;
    private float swipeAngle;

    // Neighbor gem to be swapped
    private Gem neighborGem;
    void Start()
    {
        
    }

    void Update(){

        if(Vector2.Distance(transform.position, pos) > 0.1f)
        transform.position = Vector2.Lerp(transform.position, pos, Board.gemSpeed * Time.deltaTime);
        else
        transform.position = new Vector3(pos.x, pos.y, 0f);
        
        Board.allGems[pos.x, pos.y] = this;

        if(mousePressed && Input.GetMouseButtonUp(0)){
            mousePressed = false;
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            calculateAngle();
        }
    }

    // Update is called once per frame

    public void SetupGem(Vector2Int pos, BoardManager boardManager){
        this.pos = pos;
        this.Board = boardManager;
    }

    private void OnMouseDown(){
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePressed = true;
    }

    private void calculateAngle(){
        // In radian
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x);
        // In degree
        swipeAngle = swipeAngle * 180 / Mathf.PI;
        Debug.Log(swipeAngle);

        if(Vector2.Distance(firstTouchPosition, finalTouchPosition) > 0.5f){
            MovePieces();
        }
    }

    private void MovePieces(){
        if(swipeAngle <= 45 && swipeAngle >= -45 && pos.x < Board.width - 1){

            neighborGem = Board.allGems[pos.x + 1, pos.y];
            neighborGem.pos.x--;
            pos.x++;

        }

        else if(swipeAngle > 45 && swipeAngle < 135 && pos.y < Board.height - 1){

            neighborGem = Board.allGems[pos.x, pos.y + 1];
            neighborGem.pos.y--;
            pos.y++;

        }
        else if(swipeAngle < -45 && swipeAngle > -135 && pos.y > 0){

            neighborGem = Board.allGems[pos.x, pos.y - 1];
            neighborGem.pos.y++;
            pos.y--;

        }
        else if (swipeAngle >= 135 || swipeAngle <= -135 && pos.x > 0){

            neighborGem = Board.allGems[pos.x - 1, pos.y];
            neighborGem.pos.x++;
            pos.x--;

        }

        // If we somehow didn't satisfy any of the conditions above.
        if(neighborGem == null){
            Debug.Log("Swipe operation failed");
            return;
        }

        Board.allGems[pos.x, pos.y] = this;
        Board.allGems[neighborGem.pos.x, neighborGem.pos.y] = neighborGem;
        

    }
}
