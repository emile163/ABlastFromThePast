using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goalType;
    public itemType it;
    public TypeDeMonstre mT;
    public Target target;
    public int requiredAmount;
    public int currentAmount=0;
    private bool completed;
    public string itemName;

    public bool IsReached()
    { 
        if (!completed && !this.goalType.Equals(GoalType.Explore))
        {
            if (currentAmount >= requiredAmount)
            {
                completed = true;
                return (true);
            }
            else return false;
        }
        else return true;
    }
    public int Atteint(Queteobjet quest )
    {
    if (quest.qG.IsReached())
    {
        return quest.indexQuete; 
    }else return -1;
    }
   

}



    public enum GoalType
 
    {
    Kill,
    Gathering,
    Explore,
    Give

    
    }


