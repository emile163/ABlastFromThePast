using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObj : MonoBehaviour
{
    public enum QuestType {
        gather, give, explore, kill

    }
    public int questNumber;
    public QuestManager QM;

    public string startText;
    public string endText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
    {
        QM.ShowQuestText(startText);
    }
    public void EndQuest()
    {
        QM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
        QM.ShowQuestText(endText);
    }


}
