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

    /// <summary>
    /// fonction qui permet de déterminer si le but de la quête est compléter sauf dans le cas
    /// d'une quête d'exploration
    /// </summary>
    /// <returns></returns> Retourne si la quête est complétée.
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

    

}


    /// <summary>
    /// Enum qui permet de déterminer quel est le type de la quete
    /// </summary>
    public enum GoalType
 
    {
    Kill,
    Gathering,
    Explore,
    Give

    
    }


