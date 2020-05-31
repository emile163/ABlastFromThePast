using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	private QuestGiver questGiver;
	public DialogueHolder dHolder ;
	public GameObject dBox;
	public Text instruction;
	public Text dText;
	public Text name;
	public string Name;
	public bool dialogueActive;
	public Button questButton;


	public bool hasQuest;
	
	public string[] dialogueLines;
	public int currentLine;

	void Start()
	{
		questGiver = FindObjectOfType<QuestGiver>();

	}

	/// <summary>
	/// Gère les dialogues qui sont en cours et leur avancement. 
	/// Recoit toutes ses infos du questGiver et de son dialogue Holder.
	/// </summary>
	void Update()
	{
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {

			
			currentLine++;
		}
		if (currentLine >= dialogueLines.Length)
        {
			dBox.SetActive(false);
		    dialogueActive = false;
			currentLine = 0;
		}
		dText.text = dialogueLines[currentLine];
		if (currentLine == dialogueLines.Length - 1 )
		{
			instruction.text = "Appuyez sur espace pour finir le dialogue";
			if (hasQuest )
			{
				
				questButton.gameObject.SetActive(true);
				
			}
		}
		else
		{
			instruction.text = "Press space to continue";
			questButton.gameObject.SetActive(false);
		}
		if (currentLine == dialogueLines.Length - 1  && questGiver.quetes[dHolder.QuestIndex].isActive)
		{
			questButton.gameObject.SetActive(true);

		}
		

	}

	/// <summary>
	/// Affiche la ligne de dialogue qui est en cours
	/// </summary>
	/// <param name="dialogue"></param> La ligne de dialogue
	public void ShowBox(string dialogue)
	{

		


		dText.text= dialogue;

		

		dialogueActive = true;
		dBox.SetActive(true);
		
    }

	/// <summary>
	/// Affiche la boîte de dialogue si elle n'est pas active.
	/// </summary>
	public void ShowDialogue()
    {
		dialogueActive = true;
		dBox.SetActive(true);
		name.text = Name;
    }

	/// <summary>
	/// Réinitialise et ferme le dialogue manager et ses composantes importantes après qu'une quête soit 
	/// acceptée.
	/// </summary>
	public void setCurrentLine0()
	{
		hasQuest = false;
		this.currentLine = 0;
		this.dialogueActive = false;
		dHolder.acceptQuest();
	}
	

}