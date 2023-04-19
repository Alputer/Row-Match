using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneInfoManager
{
    public static List<int> maxScores { get; set; } = new List<int>{0,0,0,0,0,0,0,0,0,0};
    public static List<bool> isLocked { get; set; } = new List<bool>{false,true,true,true,true,true,true,true,true,true};

}
