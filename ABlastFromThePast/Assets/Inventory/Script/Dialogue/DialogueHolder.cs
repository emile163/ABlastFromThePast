using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private QuestGiver questGiver;
 //   private PlayerControllerclem player;
    public bool canTalk = true;
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
    private int distance;
    

    // Start is called before the first frame update
    void Start()

    {
        questGiver = FindObjectOfType<QuestGiver>();
       // player = FindObjectOfType<PlayerControllerclem>();
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Edown = Input.GetKeyDown(KeyCode.E);
        checkDistance(questGiver.player);
        ;
        {
            if (Input.GetKeyDown(KeyCode.E) && checkDistance(questGiver.player))
            {
                if (canTalk)
                {
                    if (!dMan.dialogueActive)
                    {

                        dMan.hasQuest = hasQuest;
                        dMan.dHolder = this;
                        dMan.Name = Name;
                        if (!questGiver.quetes[QuestIndex].questEnded)/////////////////////////////////////POTENTIEL PROBLEME ICI
                        {
                            dMan.dialogueLines = dialogueLines;

                        }
                        else
                        {
                            dMan.dialogueLines = dialogueFinQuete;
                            Debug.Log("NUMÉRO DU CHANGEMENT DE DIALOGUE" + QuestIndex);
                        }
                        dMan.currentLine = 0;
                        dMan.ShowDialogue();
                        hasQuest = dMan.hasQuest;

                        if (dMan.hasQuest != hasQuest)
                        {
                            hasQuest = dMan.hasQuest;
                        }
                    }

                }
                else Edown = false;



            }
        }
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
                if (Edown && canTalk)
                {
                    // dMan.ShowBox(dialogue);
                    if (!dMan.dialogueActive)
                    {
                        if (!oneTimeQuest)
                        {

                        }
                        dMan.hasQuest = hasQuest;
                        dMan.dHolder = this;
                        dMan.Name = Name;
                        if (!questGiver.quetes[QuestIndex].questEnded)/////////////////////////////////////POTENTIEL PROBLEME ICI
                        {
                            dMan.dialogueLines = dialogueLines;

                        }
                        else
                        {
                            dMan.dialogueLines = dialogueFinQuete;
                            Debug.Log("NUMÉRO DU CHANGEMENT DE DIALOGUE" + QuestIndex);
                        } //if (hasQuest)
                          //  {
                          //      try
                          //      {
                          //          if (questGiver.player.listeQuete[QuestIndex].qG.IsReached())
                          //          {
                          //              setDialFinDeQuete();
                          //          }
                          //      }
                          //      catch (ArgumentOutOfRangeException e)
                          //      {

                        //      }
                        //  }

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
        Debug.Log("Qui a set le dialfinal"+this.QuestIndex);
    }
    public string sout(DialogueHolder [] dhold)
    {
        string truc="";
        foreach (DialogueHolder i in dhold)
       truc= truc+ i.QuestIndex.ToString();
        return truc;
    }

    private bool checkDistance(PlayerControllerclem player)
    {
        if ((player.transform.position - transform.position).magnitude < .5f)
        {
            return true;

        }


        return false ;
    }
}
