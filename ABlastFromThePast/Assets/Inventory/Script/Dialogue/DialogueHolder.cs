using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public bool isInside;
    public bool SpaceUp;
    public string Name;
    private DialogueManager dMan;

    public string[] dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        {
          
            {
                isInside = true;

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                SpaceUp = false;
            }
            else SpaceUp = true;
        }

        if (other.gameObject.name == "Player"|| other.gameObject.name == "DontDestroyOnLoad")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // dMan.ShowBox(dialogue);
                if (!dMan.dialogueActive)
                {
                    dMan.Name = Name;
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
                // Il faut ensuite ici rendre le pnj incapable de bouger tout comme le joueur
              
            }
        }
        
    }
        

}
