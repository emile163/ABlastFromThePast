using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
      
    public QuestObj [] quests;
    public bool[] questCompleted;

    public DialogueManager dMan;

    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ShowQuestText(string questText, int questNumber)
    {
        if (questCompleted[questNumber])
        {
            dMan.dialogueLines = new string[1];
            dMan.dialogueLines[0] = questText;
            dMan.currentLine = 0;
            dMan.Name = "";
            dMan.ShowDialogue();
        }
    }

    public void setActive(int questNumber)
    {
        quests[questNumber].active = !quests[questNumber].active;
    }

}
