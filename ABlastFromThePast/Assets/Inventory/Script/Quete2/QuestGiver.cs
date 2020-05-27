using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    private DialogueHolder[] dhold;
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
    /// <summary>

    /// </summary>

    private void Start()
    {
        dhold = FindObjectsOfType<DialogueHolder>();
        inv = FindObjectOfType<Inventory>();
    }


    public void OpenQuestWindow()
    {
           //if (dhold[identifierQuete()].QuestIndex < quetes.Count)
        {

            quete = quetes[identifierQuete()];
          

      //      Debug.Log(dhold.QuestIndex.ToString());

            title.text = quete.title;
            description.text = quete.description;
            if (quete.qG.IsReached() && quete.isActive)
            {
                complétion.text = "Accepter les récompenses";
                recevoir.gameObject.SetActive(true);
                acepterQuete.gameObject.SetActive(false);

            }
            else recevoir.gameObject.SetActive(false);



            questWindow.SetActive(true);

        }
    }

    public void AccepterQuete()
    {
        questWindow.SetActive(false);
        quete.isActive = true;


        if (quete.qG.goalType.Equals(GoalType.Gathering))
        {
            //quete.qG.requiredAmount = invCheckGatherQuest(quete, quete.qG.it, quete.qG.requiredAmount);
        }
        player.listeQuete.Add(quete);
        



    }
    public void EndQuest()
    {
        quete = player.listeQuete[identifierQuete()];
                    
        Debug.Log("suofsijfoejipsf");
        quete.isActive = false;
        
        player.listeQuete.Remove(quete);

    }

    public void gestionRec()
    {
        foreach (Item i in player.listeQuete[quete.indexQuete].rewards) {
            inv.AddItem(i);
        }


        EndQuest();
    }

    public int identifierQuete()
    {
        float valMin, valTemp;
        int indexTrouve=0;
        Debug.Log(dhold.Length.ToString());
        valMin = (dhold[0].transform.position - player.transform.position).magnitude;
        Debug.Log(valMin);
        foreach (DialogueHolder i in dhold)
        {
            Debug.Log(indexTrouve + (indexTrouve>=1).ToString());
            
            valTemp = (i.transform.position - player.transform.position).magnitude;
Debug.Log("INDEX PNJ :" + i.QuestIndex + "...... DISTANCE: " + valTemp);
           if (valTemp <= valMin)
            {
                
                valMin = valTemp;
                indexTrouve = i.QuestIndex;
                Debug.Log(indexTrouve);
            }
        }
        return indexTrouve;

    }

    public int invCheckGatherQuest(Queteobjet quete, itemType iT, int requiredAmount)
    {
        Debug.Log("fag");
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



}
