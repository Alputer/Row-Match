using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public static class CrossSceneInfoManager
{
    public static List<int> maxScores  = new List<int>{0,0,0,0,0,0,0,0,0,0};
    public static List<bool> isLocked = new List<bool>{false,true,true,true,true,true,true,true,true,true};

    public static int currentLevel = 0;

    public static int currentLevelGridWidth = 0;

    public static int currentLevelGridHeight = 0;

    public static int currentLevelMoveCount = 0;

    public static bool shouldCelebrate = false;


    public static int[] currentLevelItems;  // 0 -> red 1 -> green 2 -> blue 3 -> yellow

    // public static int currentGrid


    // This is by no means the best practice while parsing the files. Could be handled with regular expressions. 
    public static void setupLevelVariables(int levelNum){
            string levelPath = $"./Assets/Levels/RM_A{levelNum}";
            List<string> fileLines = File.ReadAllLines(levelPath).ToList();
            CrossSceneInfoManager.currentLevel = levelNum;
            CrossSceneInfoManager.currentLevelGridWidth  =  fileLines[1][12] - '0';
            CrossSceneInfoManager.currentLevelGridHeight =  fileLines[2][13] - '0';
            CrossSceneInfoManager.currentLevelMoveCount  =  int.Parse(fileLines[3].Substring(12));

            // 0 -> red 1 -> green 2 -> blue 3 -> yellow
            string[] utilArr   = fileLines[4].Substring(6).Split(",");
            CrossSceneInfoManager.currentLevelItems = new int[currentLevelGridWidth * currentLevelGridHeight];
            for(int i=0;i<currentLevelGridWidth * currentLevelGridHeight;i++){
                    
                    switch (utilArr[i])
                    {
                            case "r":
                            CrossSceneInfoManager.currentLevelItems[i] = 0;
                            break;

                            case "g":
                            CrossSceneInfoManager.currentLevelItems[i] = 1;
                            break;

                            case "b":
                            CrossSceneInfoManager.currentLevelItems[i] = 2;
                            break;

                            case "y":
                            CrossSceneInfoManager.currentLevelItems[i] = 3;
                            break;

                            default:
                            Debug.Log("Gem Type doesn't match any of the options, something went wrong while reading input");
                            break;
                    }
                    
                
            }
            
    }

}
