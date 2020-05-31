using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  La classe Target sert de vérification et d'objectif au quêtes d'exploration. 
/// 
/// </summary>
public class Target : MonoBehaviour
{
    public BoxCollider2D bc2;
    private QuestGiver questGiver;
    private PNJDebut pnjDebut;
    private GameObject pnjFin;
    private bool cond = false, cond2 = false;
    private  Queteobjet  quete;
    private bool timer = true;
    /// <summary>
    /// Dans le start, la classe va trouver le questGiver ainsi que les deux pnj qui sont nécéssaires à la bonne
    /// réalisation de la quete.
    /// </summary>
    private void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        pnjDebut = FindObjectOfType<PNJDebut>();
    }
    /// <summary>
    /// dans l'update, la classe Target vérifie si son box collider est en contact avec le joueur pour le récompenser
    /// et pour s'assurer de n'avoir complété la quête qu'une seule fois. Elle va rendre le pnj inutile inactif
    /// sans toutefois affecter son dialogue holder qui est nécessaire au bon fonctionnement du programme.
    /// </summary>
    private void Update()
    {

        if (timer)
        {
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
                
                dhold.canTalk = false;
                questGiver.OpenQuestWindow(dhold.QuestIndex);
                
            }   
        }
    }
}
