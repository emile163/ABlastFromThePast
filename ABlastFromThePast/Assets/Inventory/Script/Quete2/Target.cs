using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public BoxCollider2D bc2;
    private QuestGiver questGiver;
    private PNJDebut pnjDebut;
    private GameObject pnjFin;
    private bool cond = false, cond2 = false;
    private  Queteobjet  quete;
    private bool timer = true;
    private void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        pnjDebut = FindObjectOfType<PNJDebut>();
        pnjFin = GameObject.Find("target test end");
    }
    private void Update()
    {

        if (timer)
        {
            pnjFin.gameObject.SetActive(false);
            timer = false;
        }
        

        if (bc2.IsTouching(questGiver.player.GetComponent<Collider2D>()) && !cond  )
        {
            DialogueHolder dhold = pnjDebut.GetComponentInChildren<DialogueHolder>();
          if (questGiver.quetes[dhold.QuestIndex].isActive)
            {
                quete = questGiver.quetes[dhold.QuestIndex];
                questGiver.quetes[quete.indexQuete].questEnded = true;

                cond = true;                
                pnjDebut.GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
                pnjFin.gameObject.SetActive(true);
                
                dhold.canTalk = false;
                //questGiver.quetes[quete.indexQuete].questEnded = true;
                questGiver.OpenQuestWindow(dhold.QuestIndex);
                
            }   
        }
    }
}
