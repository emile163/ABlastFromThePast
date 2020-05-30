using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public DialogueHolder[] dhold;
    public int[] dholdNumber = new int[7];
    private Inventory inv;
    public Queteobjet quete;
    public PlayerControllerclem player;
    public GameObject questWindow;
    public Text title;
    public Text description;
    public Text complétion;
    public Button recevoir;
    public List<Queteobjet> quetes;
    public Button acepterQuete;
    public Button giveThings;
    private List<Item> itemSlots;
    /// <summary>

    /// </summary>

    private void Start()
    {
        dhold = FindObjectsOfType<DialogueHolder>();
        inv = FindObjectOfType<Inventory>();
        itemSlots = inv.GetListItem();
    }
   
    public List<Queteobjet> GiveQuests()
	{
        return quetes;
    }

    public void OpenQuestWindow()
    {
        setIndex() ;
        
        //if (dhold[identifierQuete()].QuestIndex < quetes.Count)
        {
            initialiseQuestWindow();
            quete = quetes[identifierQuete(-1)];


            //      //debug.Log(dhold.QuestIndex.ToString());

            title.text = quete.title;
            description.text = quete.description;

            if (quete.qG.IsReached() && quete.isActive && quete.qG.goalType != GoalType.Explore)
            {

                complétion.text = "Accepter les récompenses";
                recevoir.gameObject.SetActive(true);
                acepterQuete.gameObject.SetActive(false);
                complétion.gameObject.SetActive(false);

            }else if (!(quete.qG.goalType== GoalType.Explore && quete.isActive))
            {
                 if (!quete.isActive)
                acepterQuete.gameObject.SetActive(true);
                recevoir.gameObject.SetActive(false);
                complétion.gameObject.SetActive(false);
                Debug.Log("hey");

            }
            if (quete.questEnded && quete.isActive )
            {

                complétion.text = "Accepter les récompenses";
                recevoir.gameObject.SetActive(true);
                acepterQuete.gameObject.SetActive(false);
                complétion.gameObject.SetActive(false);

            }
            
            if (quete.qG.goalType.Equals(GoalType.Give) && quete.isActive && !quete.questEnded)
            {
                giveThings.gameObject.SetActive(true);
                recevoir.gameObject.SetActive(false);
                complétion.text = "Vous avez encore " + quete.qG.requiredAmount + " " + quete.qG.itemName + "à remettre";

            }


            questWindow.SetActive(true);

        }
    }
    private void initialiseQuestWindow()
    {
        questWindow.SetActive(false);
        acepterQuete.gameObject.SetActive(false);
        recevoir.gameObject.SetActive(false);
        giveThings.gameObject.SetActive(false) ;
        title.text = "";
        description.text = "";
        complétion.text = "";
    }
    public void OpenQuestWindow(int i)
    {
        initialiseQuestWindow();
        //if (dhold[identifierQuete()].QuestIndex < quetes.Count)
        {

            quete = quetes[i];


            //      //debug.Log(dhold.QuestIndex.ToString());

            title.text = quete.title;
            description.text = quete.description;

            if (quete.qG.IsReached() && quete.isActive)
            {
                complétion.text = "Accepter les récompenses";
                recevoir.gameObject.SetActive(true);
                acepterQuete.gameObject.SetActive(false);

            }
            else recevoir.gameObject.SetActive(false);
            if (!(quete.qG.goalType != GoalType.Explore && quete.isActive))
            {
                acepterQuete.gameObject.SetActive(true);
                recevoir.gameObject.SetActive(false);
            }
            if (quete.questEnded && quete.isActive)
            {
                complétion.text = "Accepter les récompenses";
                recevoir.gameObject.SetActive(true);
                acepterQuete.gameObject.SetActive(false);
                giveThings.gameObject.SetActive(false);

                if (quete.qG.goalType == GoalType.Explore && quete.isActive && quete.questEnded)
                {
                    //  recevoir.gameObject.SetActive(true);

                    acepterQuete.gameObject.SetActive(false);
                    giveThings.gameObject.SetActive(false);
                    gestionRec(i);
                }
            } if (quete.isActive && quete.qG.goalType == GoalType.Explore && !quete.questEnded)
            {
                recevoir.gameObject.SetActive(false);
                acepterQuete.gameObject.SetActive(false);
                giveThings.gameObject.SetActive(false);
            }



            questWindow.SetActive(true);
            quete = null;
        }
    }
    public void AccepterQuete()
    {
        //debug.Log("nombre de dhold" + dhold.Length + " index de la quete" + quete.indexQuete + "index du DHOLD" + dhold[quete.indexQuete].QuestIndex); ;

        questWindow.SetActive(false);
        quete = quetes[identifierQuete(-1)];
        quete.isActive = true;
        //debug.Log(quete.indexQuete.ToString() + "NUMERO QUETE ACCEPTÉ ensuite numéro du dhold"+ dhold);

        if (quete.qG.goalType.Equals(GoalType.Gathering))
        {
            //quete.qG.requiredAmount = invCheckGatherQuest(quete, quete.qG.it, quete.qG.requiredAmount);
        }
        player.listeQuete.Add(quete);




    }
    public void EndQuest()
    {
        
        quete = quetes[identifierQuete(-1)];
        quete.questEnded = true;
        //debug.Log("nombre de dhold" + dhold.Length + " index de la quete" + quete.indexQuete + "index du DHOLD" + dhold[quete.indexQuete].QuestIndex); ;
        dhold[quete.indexQuete].setDialFinDeQuete();
        quete.isActive = false;
        player.listeQuete.Remove(quete);

    }
    public void gestionRec(int i) {

        foreach (Item j in quetes[identifierQuete(i)].rewards)
        {
            inv.AddItem(j);
        }

        EndQuest(i);

    }
    public void EndQuest(int i)
    {
        quete = quetes[identifierQuete(i)];

        quete.questEnded = true;
        //debug.Log("nombre de dhold" + dhold.Length + " index de la quete" + quete.indexQuete + "index du DHOLD" + dhold[quete.indexQuete].QuestIndex); ;
        dhold[quete.indexQuete].setDialFinDeQuete();
        quete.isActive = false;
        //player.listeQuete.Remove(quete);

    }


    public void gestionRec()
    {
        foreach (Item i in quetes[identifierQuete(-1)].rewards) {
            inv.AddItem(i);
        }
       /* if(quete.qG.goalType == goalType.Gathering)
		{
			for (int i = 0; i < itemSlots.Length; i++)
			{
                if(itemSlots[i].)
			}
		}*/

        EndQuest();
    }

    public int identifierQuete(int indexProb)
    {
        if (indexProb == -1)
        {
            float valMin, valTemp;
            int indexTrouve = 0;
            //debug.Log("Longueur du dhold[] "+dhold.Length.ToString());
            valMin = (dhold[0].transform.position - player.transform.position).magnitude;
            foreach (DialogueHolder i in dhold)
            {

                valTemp = (i.transform.position - player.transform.position).magnitude;
                //debug.Log("INDEX PNJ :" + i.QuestIndex + "...... ID duDHOLD ASSOCIÉ: " +i.QuestIndex );///////////////////
                if (valTemp <= valMin)
                {

                    valMin = valTemp;
                    indexTrouve = i.QuestIndex;
                }
            }
            return indexTrouve;
        } else
        {
            return indexProb;
        }
    }

    public int invCheckGatherQuest(Queteobjet quete, itemType iT, int requiredAmount)
    {
        ////debug.Log("fag");
        int block = 0;
        List<Item> itemList = inv.GetListItem();

        foreach (ItemSlot i in inv.GetItemSlots())
        {


            if (i._item.iT.Equals(quete.qG.it))
            {
                if (block == 0)
                {
                    quete.qG.currentAmount = i.nombreDeRessource;
                    block++;
                }
                
                requiredAmount = i.nombreDeRessource + requiredAmount;

            }
        }
        return requiredAmount;
    }

    public void giveObject()
    {
        int iQ = -1;
        if ((iQ = hasItem()) != -1)
        {
            int isRC = isRessource(iQ);
            
            int iden = identifierQuete(-1);
            switch (isRC)
            {
                
                case 1:
                    if (isGoodRessource(iden,iQ))
                    {
                        int nombre_item = inv.GetItemSlots()[iQ].nombreDeRessource;
                        int current_Amount = inv.GetItemSlots()[iQ].nombreDeRessource;
                        int req_item = quetes[iden].qG.requiredAmount;
                        if (nombre_item + 1 >= req_item)
                        {
                            inv.GetItemSlots()[iQ].nombreDeRessource = nombre_item - req_item;
                            //f (nombreDeRessource)
                            inv.GetItemSlots()[iQ].DeleteItem();
                            quetes[iden].qG.requiredAmount = 0;
                            quetes[iden].qG.currentAmount = nombre_item - req_item - 1;
                            quetes[iden].qG.IsReached();
                            quetes[iden].questEnded = true;

                            OpenQuestWindow(iden);
                        }
                        else
                        {
                            inv.GetItemSlots()[iQ].nombreDeRessource = nombre_item - current_Amount;
                            quetes[iden].qG.requiredAmount -= current_Amount;
                            quetes[iden].qG.currentAmount -= current_Amount;
                            complétion.text = "Il vous reste " + req_item + " " + inv.GetListItem()[iQ].itemName + " à donner.";
                        }
                    }
            break;
                case 0:
                    if (inv.GetListItem()[iQ].itemName.Equals(quetes[iQ].qG.itemName))
            {
                inv.RemoveItem(inv.GetListItem()[iQ]);
                quetes[iden].questEnded = true;
                OpenQuestWindow(iden);
            }

            break;
                default: OpenQuestWindow();
                    break;
        }
            }else complétion.text = "Malheureusement vous n'avez pas ce que nous vous demandons";
            
            }

    public int hasItem()
    {
        int iQ;
        iQ = identifierQuete(-1);

        if (!(inv.GetListItem().Count == 0))
        {
            foreach (Item i in inv.GetListItem())
            {

                if ((quetes[iQ].qG.goalType).Equals(GoalType.Give))
                {
                    iQ = inv.GetListItem().IndexOf(i);
                    return iQ;
                }

            }
        }
        return -1;
    }
    public int isRessource(int iQ)
    {
        int z;
 
              return  z=(inv.GetListItem()[iQ] is RessourceItem ? 1 : 0);

     
    }
    public bool isGoodRessource(int iden, int iQ)
    {
        if (inv.GetItemSlots()[iQ].Item.iT.Equals(quetes[iden].qG.it))
            return true;
        else return false;

    }
    public void setIndex()
    { DialogueHolder dhold2;
         DialogueHolder temp = dhold[0];
        int indextemp = 0;
        for (int i = 0; i < dhold.Length; i++)
        {
            for (int j = 0; j < dhold.Length; j++)
            {
                if (quetes[i].indexQuete == dhold[j].QuestIndex)
                {
                    temp = dhold[i];
                    dhold[quetes[i].indexQuete] = dhold[j];
                    dhold[j] = temp;
                }

            }
        }
            

        


    }
   
}