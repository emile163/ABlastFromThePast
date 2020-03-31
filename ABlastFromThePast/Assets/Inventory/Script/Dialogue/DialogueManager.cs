using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public GameObject dBox;
	public Text dText;
	public Text name;
	public string Name;
	public bool dialogueActive;

	public string[] dialogueLines;
	public int currentLine;

	void Start()
	{


	}

	void Update()
	{
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {



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