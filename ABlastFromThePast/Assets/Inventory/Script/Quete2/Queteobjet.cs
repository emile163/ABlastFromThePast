using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Queteobjet 
{
    public string title;
    public string description;
    public int indexQuete;
    public bool isActive;
    public Item[] rewards;
    public QuestGoal qG;
}
