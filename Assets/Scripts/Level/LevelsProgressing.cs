using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelsProgressing 
{
    public List<Progress> Levels = new List<Progress>();
}

[System.Serializable]
public class Progress
{
    public int MaxScore;
    public int starsCount;
    public bool isOpened;
}
