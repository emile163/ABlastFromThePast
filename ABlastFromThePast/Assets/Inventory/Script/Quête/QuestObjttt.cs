using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestObj 
{
    public int currentAmount;
    public int goalAmount;
    public QuestType questType;
    public MonsterType objKill;
    public RessourceType objCollecte;
    public Target objExplo;

    public int questNumber;
    public QuestManager QM;

    public string startText;
    public string endText;
    public bool active;
    // Start is called before the first frame update
    
    public void StartQuest()
    {
        QM.ShowQuestText(startText, questNumber);
    }
    public void EndQuest()
    {
        QM.questCompleted[questNumber] = true;
        //notifier que la quete est finie
        QM.ShowQuestText(endText, questNumber);
    }

    public bool isActive()
    {
        return active; 
    }




}
public enum QuestType {
        gather, give, explore, kill

    }