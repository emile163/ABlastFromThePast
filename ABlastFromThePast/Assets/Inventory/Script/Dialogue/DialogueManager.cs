using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public GameObject dBox;
	public Text instruction;
	public Text dText;
	public Text name;
	public string Name;
	public bool dialogueActive;
	public Button questButton;

	public bool hasQuest;
	public bool given1timeQuest;
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
			if (hasQuest && !given1timeQuest)
			{
				given1timeQuest = true;
				questButton.gameObject.SetActive(true) ;
				
			}
		}
		else instruction.text = "Press space to continue";
	

	
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
}