using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goalType;
    public itemType it;
    public MonsterType mT;
    public Target target;
    public int requiredAmount;
    public int currentAmount;
public bool IsReached()
{
        return (currentAmount >= requiredAmount);
}

}


public enum GoalType
{
    Kill,
    Gathering
}
