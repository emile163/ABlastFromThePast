using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// La classe QuestGiver est la classe qui est gestionnaire des quetes, de leur bien fonctionnement et de leur finition.
/// Elle se compose de tout ce qui pourrait lui etre nécéssaire: un accès â l'inventaire, au joueur, à une liste contenant toutes 
/// les quêtes et l'affichage graphique lié à ces données
/// </summary>
public class QuestGiver : MonoBehaviour
{
    public DialogueHolder[] dhold;
    public int[] dholdNumber = new int[7];
    private static Inventory inv;
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
    static bool unefois = true;
   
    /**/
    /// <summary>
    /// Donne à la classe accès à des objets de facon private.
    /// </summary>
    private void Start()
    {
        if(unefois == true)
		{
            inv = FindObjectOfType<Inventory>();
            unefois = false;
        }
        dhold = FindObjectsOfType<DialogueHolder>();
        
    }
   
  /// <summary>
  /// Ouvre la fenetre de quête à partir d'un bouton lié au gestionnaire de dialogue.
  /// Cette fenêtre gère quelles actions vont être possibles selon le pnj auquel on parle
  /// et selon la complétion de la quête.
  /// </summary>
    public void OpenQuestWindow()
    {
        setIndex() ;
        
        {
            initialiseQuestWindow();
            quete = quetes[identifierQuete(-1)];



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

    /// <summary>
    /// initialise et réinitialise les composantes graphiques textuelles (et les boutons) liées à la fenêtre de 
    /// quête.
    /// </summary>
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

    /// <summary>
    /// Ouvre la fenetre de quête à partir d'un bouton lié au gestionnaire de dialogue.
    /// Cette fenêtre gère quelles actions vont être possibles selon le pnj auquel on parle
    /// et selon la complétion de la quête. Gère les exceptions nécessaires à la complétion des quêtes d'exploration.
    ///int i ---> l'index de la quête pour laquelle il y a exception.
    /// 
    /// </summary>
    public void OpenQuestWindow(int i)
    {
        initialiseQuestWindow();
        {

            quete = quetes[i];



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

    /// <summary>
    /// Est la fonction appelée et active la quête demandée
    /// </summary>
    public void AccepterQuete()
    {

        questWindow.SetActive(false);
        quete = quetes[identifierQuete(-1)];
        quete.isActive = true;

        
        player.listeQuete.Add(quete);

        if (quete.desactiveObjet != null)
        {
            quete.active.SetActive(!quete.active.activeSelf); /////////////////////////ici CLEMENT

        }



    }

    /// <summary>
    /// Permet de terminer une quête précise
    /// </summary>
    public void EndQuest()
    {
        
        quete = quetes[identifierQuete(-1)];
        quete.questEnded = true;
        dhold[quete.indexQuete].setDialFinDeQuete();
        quete.isActive = false;
        player.listeQuete.Remove(quete);

        if (quete.active != null && quete.desactiveObjet != null)
        {
            quete.desactiveObjet.SetActive(!quete.desactiveObjet.activeSelf);

        }
    }

    /// <summary>
    /// Donne les récompenses au joueur lorsqu'une quête est complétée. Cette version gère les exceptions 
    /// qui arrivent lorsque on ne passe pas par OpenQuestWindow sans paramètre.
    /// </summary>
    /// <param name="i"></param> i est l'index de la quête qui va donner des récompenses
    public void gestionRec(int i) {

        foreach (Item j in quetes[identifierQuete(i)].rewards)
        {
            inv.AddItem(j);
        }

        EndQuest(i);

    }

    /// <summary>
    /// Permet de terminer une quête précise.Cette version gère les exceptions 
    /// qui arrivent lorsque on ne passe pas par OpenQuestWindow sans paramètre.
    /// </summary>
    /// <param name="i"></param> i est l'index de la quête qui va donner des récompenses
    public void EndQuest(int i)
    {
        quete = quetes[identifierQuete(i)];

        quete.questEnded = true;
        dhold[quete.indexQuete].setDialFinDeQuete();
        quete.isActive = false;

    }


    /// <summary>
    /// Donne les récompenses au joueur lorsqu'une quête est complétée
    /// </summary>
    public void gestionRec()
    {
        foreach (Item i in quetes[identifierQuete(-1)].rewards) {
            inv.AddItem(i);
        }
      

        EndQuest();
    }

    /// <summary>
    /// Permet d'identifier les quêtes sans besoin d'informations supplémentaires comme le pnj qui le tiens,
    /// son index, etc.
    /// </summary>
    /// <param name="indexProb"></param> paramêtre introduit dans le cas où le résultat est déja connu
    /// si ce résultat est déjà connu, on passe l'index et le retourne. S'il est inconnu, on passe -1 et recoit
    /// l'index recherché
    /// <returns></returns>
    public int identifierQuete(int indexProb)
    {
        if (indexProb == -1)
        {
            float valMin, valTemp;
            int indexTrouve = 0;
            valMin = (dhold[0].transform.position - player.transform.position).magnitude;
            foreach (DialogueHolder i in dhold)
            {

                valTemp = (i.transform.position - player.transform.position).magnitude;
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

    /// <summary>
    /// Fonction qui permet de donner les items qui sont requis dans le cadre d'une quête de type 'Give'
    /// Cette fonction gère tout ce qui est reliée à cette fonction comme l'identification de ressource,
    /// l'analyse de l'inventaire et le retrait de ressource dans le cas de besoin.
    /// </summary>
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
                    if (inv.GetListItem()[iQ].itemName.Equals(quetes[iden].qG.itemName))
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

    /// <summary>
    /// Analyse l'inventaire à la recherche de l'index où item de Quest (iQ) est présent
    /// (ou s'il est présent) 
    /// </summary>
    /// <returns></returns> le return est l'index de la position de l'item. Si le programme ne le trouve pas
    /// il retourne -1 pour que le give ne continue pas plus loin.
    public int hasItem()
    {
        int iQ;
        iQ = identifierQuete(-1);

        if (!(inv.GetListItem().Count == 0))
        {
            foreach (Item i in inv.GetListItem())
            {

                if ((quetes[iQ].qG.it).Equals(i.iT))
                {
                    iQ = inv.GetListItem().IndexOf(i);
                    return iQ;
                }

            }
        }
        return -1;
    }

    /// <summary>
    /// Comme les ressources dans ce jeu sont un enfant des items, la fonction regarde si 
    /// l'objet convoité dans l'inventaire est une ressource. La différence se fait du au fait que les
    /// ressources peuvent être stack, tandis que les objets normaux non.
    /// </summary>
    /// <param name="iQ"></param> le paramètre est l'index auquel se trouve l'item à analyser dans 
    /// l'inventaire.
    /// <returns></returns> on retourne un int dans le but de 'switch' sur si l'objet est une ressource
    public int isRessource(int iQ)
    {
        int z;
 
              return  z=(inv.GetListItem()[iQ] is RessourceItem ? 1 : 0);

     
    }

    /// <summary>
    /// Vérofocation que l'item correspond bel et bien à l'item requis dans la quête
    /// </summary>
    /// <param name="iden"></param> Numéro d'indentification de la quête; son index
    /// <param name="iQ"></param> numéro d'index de l'item dans l'inventaire.
    /// <returns></returns>
    public bool isGoodRessource(int iden, int iQ)
    {
        if (inv.GetItemSlots()[iQ].Item.iT.Equals(quetes[iden].qG.it))
            return true;
        else return false;

    }

    /// <summary>
    /// Trie les dialogue holder obtenus grâce à la fonction dans le start
    /// permet d'aligner les quetes (leurs index) et les pnj (leurs index)
    /// </summary>
    public void setIndex()
    { DialogueHolder dhold2;
         DialogueHolder temp = dhold[0];
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