using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	private PlayerControllerclem player;
	public DialogueHolder dHolder ;
	public GameObject dBox;
	public Text instruction;
	public Text dText;
	public Text name;
	public string Name;
	public bool dialogueActive;
	public Button questButton;

	public bool hasQuest;
	public QuestObj Quest;

	public string[] dialogueLines;
	public int currentLine;

	void Start()
	{


	}

	void Update()
	{
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {

			//if (hasQuest && !Quest.isActive())

			//	dBox.SetActive(false);
			//  dialogueActive = false;
			currentLine++;
		}
		if (currentLine >= dialogueLines.Length)
        {
			dBox.SetActive(false);
		    dialogueActive = false;
			currentLine = 0;
		}
		dText.text = dialogueLines[currentLine];
		if (currentLine == dialogueLines.Length - 1)
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
		try
		{
			if ((player = FindObjectOfType<PlayerControllerclem>()).listeQuete[0].qG.IsReached())
			{
				questButton.gameObject.SetActive(true);


			}
		}catch (ArgumentOutOfRangeException e) { }

	}
	public void ShowBox(string dialogue)
	{

		


		dText.text= dialogue;

		

		dialogueActive = true;
		dBox.SetActive(true);
		
    }
	public void ShowDialogue()
    {
		dialogueActive = true;
		dBox.SetActive(true);
		name.text = Name;
    }
	public void setCurrentLine0()
	{
		hasQuest = false;
		this.currentLine = 0;
		this.dialogueActive = false;
		dHolder.acceptQuest();
	}


}