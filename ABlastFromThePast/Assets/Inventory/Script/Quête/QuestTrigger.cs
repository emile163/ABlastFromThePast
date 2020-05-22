using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public GameObject Player;

    private QuestManager QM;
    public int questNumber;

    public bool startQuest;
    public bool endQuest;
    // Start is called before the first frame update
    void Start()
    {
        QM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void triggerQuest()
    {
       
        
            if ( !QM.questCompleted[questNumber])
            {
            


                if (!QM.quests[questNumber].active){
                    QM.setActive(questNumber);
                    QM.quests[questNumber].StartQuest();
                }
            }
            if (QM.quests[questNumber].currentAmount>= QM.quests[questNumber].goalAmount && QM.quests[questNumber].active)
            {
                QM.setActive(questNumber);
                QM.quests[questNumber].EndQuest();
                QM.questCompleted[questNumber] = true;
            } else if (QM.quests[questNumber].objExplo.gameObject == Player.transform)
        {
            QM.setActive(questNumber);
            QM.quests[questNumber].EndQuest();
            QM.questCompleted[questNumber] = true;
        }
        }


    }




