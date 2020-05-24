using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Queteobjet quete;
    //public Player player;
    public GameObject questWindow;
    public Text title;
    public Text description;
    public Text complétion;
    public Button recevoir;
    public List<Queteobjet> quetes;
    /// <summary>
    /// ///////////////////////////public item [] rewards;
    /// </summary>

    public void OpenQuestWindow()
    {
title.text = quete.title;
        description.text = quete.description;
        if (quete.qG.IsReached())
        {
            complétion.text = "Accepter les récompenses";
            recevoir.gameObject.SetActive(true);

        }



        questWindow.SetActive(true);
        
        
    }

    public void AccepterQuete()
    {
        questWindow.SetActive(false);
        quete.isActive = true;
        quetes.Add(quete);
    }
    public void EndQuest()
    {
        quete.isActive = false;
        quetes.Remove(quete);
            
    }

    public void gestionRec()
    {
        ///////////////truc qui se passent;
        EndQuest();
    }

}
