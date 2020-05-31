using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    private QuestGiver questGiver;
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
        dMan = FindObjectOfType<DialogueManager>();
    }

/// <summary>
/// Regarde si le player rempli les conditions pour parler au dialogue holder.
/// </summary>
void Update()
    {
        Edown = Input.GetKeyDown(KeyCode.E);
        checkDistance(questGiver.player);
        
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
                        if (!questGiver.quetes[QuestIndex].questEnded)
                        {
                            dMan.dialogueLines = dialogueLines;

                        }
                        else
                        {
                            dMan.dialogueLines = dialogueFinQuete;
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
    
    /// <summary>
    /// Fonction qui se déclenche seulement dans le cas de deux collider2d qui se superposent.
    /// Cette fonction sert de backup dans le cas où la fonction dans l'update ne fonctionne pas.
    /// Elle permet de déclencher le dialogue du dialogue holder dans le dialogue manager
    /// </summary>
    /// <param name="other"></param> Le collider qui est entré en contact avec le collider 2d du dialogue holder.
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

            {
                if (Edown && canTalk)
                {
                    if (!dMan.dialogueActive)
                    {
                        if (!oneTimeQuest)
                        {

                        }
                        dMan.hasQuest = hasQuest;
                        dMan.dHolder = this;
                        dMan.Name = Name;
                        if (!questGiver.quetes[QuestIndex].questEnded)
                        {
                            dMan.dialogueLines = dialogueLines;

                        }
                        else
                        {
                            dMan.dialogueLines = dialogueFinQuete;
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
            }
        }
    
    /// <summary>
    /// Change l'état du dialogue holder dans le cas où une quete est acceptée.
    /// i.e. : le joueur ne peu pas accepter deux fois la même quete.
    /// </summary>
    public void acceptQuest()
    {
        hasQuest = false;
        oneTimeQuest = true;
       
    }

    /// <summary>
    /// Change les lignes de dialogues du pnj apres que la quete soit finie
    /// </summary>
    public void setDialFinDeQuete()
    {
        dialogueLines = dialogueFinQuete;
    }
    
    /// <summary>
    /// Calcule la distance entre le dialogue holder et le player pour déterminer s'il est dans la zone
    /// pour déclencher le dialogue.
    /// </summary>
    /// <param name="player"></param> Le joueur
    /// <returns></returns> Retourne si le joueur est dans la zone.
    private bool checkDistance(PlayerControllerclem player)
    {
        if ((player.transform.position - transform.position).magnitude < .5f)
        {
            return true;

        }
        return false ;
    }
}
