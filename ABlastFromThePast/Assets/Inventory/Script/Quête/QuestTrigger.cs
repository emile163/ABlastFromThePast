﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if ( !QM.questCompleted[questNumber])
            {
                if (startQuest && !QM.quests[questNumber].gameObject.activeSelf){
                    QM.quests[questNumber].gameObject.SetActive(true);
                    QM.quests[questNumber].StartQuest();
                }
            }
            if (endQuest && QM.quests[questNumber].gameObject.activeSelf)
            {
                QM.quests[questNumber].gameObject.SetActive(false);
                QM.quests[questNumber].EndQuest();
                QM.questCompleted[questNumber] = true;
            }
        }


    }



}
