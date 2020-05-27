using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private PlayerControllerclem player;
    public bool given1timeQuest;
    public bool hasQuest;
    public bool isInside;
    public bool SpaceUp;
    public string Name;
    private DialogueManager dMan;
    private bool Edown;
    public bool DiaPasÉgalHolder;
    private bool oneTimeQuest ;
    public string []dialogueFinQuete;
    public string[] dialogueLines;
    public int QuestIndex;

    // Start is called before the first frame update
    void Start()

    {
        player = FindObjectOfType<PlayerControllerclem>();
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Edown = Input.GetKeyDown(KeyCode.E);
        if (dMan.hasQuest != hasQuest)
            DiaPasÉgalHolder = true;
        else DiaPasÉgalHolder = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {

        {

            {
                isInside = true;

            }
            if (Edown)
            {
                SpaceUp = false;
            }
            else SpaceUp = true;
        }

        //    if (other.gameObject.name == "Player")//|| other.gameObject.name == "DontDestroyOnLoad")
        {
            if (Edown)
            {
                // dMan.ShowBox(dialogue);
                if (!dMan.dialogueActive)
                {
                    if (!oneTimeQuest)
                    {
                        dMan.hasQuest = hasQuest;
                    }
                    dMan.dHolder = this;
                    dMan.Name = Name;
                    dMan.dialogueLines = dialogueLines;
                    if (hasQuest)
                    {
                        try
                        {
                            if (player.listeQuete[QuestIndex].qG.IsReached())
                            {
                                setDialFinDeQuete();
                            }
                        }
                        catch (ArgumentOutOfRangeException e)
                        {

                        }
                    }

                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                    hasQuest = dMan.hasQuest;

                    if (dMan.hasQuest != hasQuest)
                    {
                        hasQuest = dMan.hasQuest;
                    }

                }
                // Il faut ensuite ici rendre le pnj incapable de bouger tout comme le joueur

            }
        }

    }
    public void acceptQuest()
    {
        hasQuest = false;
        oneTimeQuest = true;
       
    }
    public void setDialFinDeQuete()
    {
        dialogueLines = dialogueFinQuete;
    }
}
