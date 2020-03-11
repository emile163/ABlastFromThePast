using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfficherTexte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
 public GameObject Target;
<<<<<<< Updated upstream
  public GameObject TextBox;
    public Vector3 distancePNJ_P;   
   
    // Update is called once per frame
    void Update()
    {
        distancePNJ_P = Target.transform.position- this.transform.position;
        if (distancePNJ_P.magnitude< 1)
        {
            (TextBox).SetActive(true) ;
        }
        else
        {
            (TextBox).SetActive(false);
        }
=======
    public DialogueTrigger
        dialogueTrigger;
    private bool isInside = false;
  //public GameObject TextBox;
    public Vector3 distancePNJ_P;

    // Update is called once per frame
    void Update()
    {
        distancePNJ_P = Target.transform.position - this.transform.position;
        if (Input.GetKeyDown(KeyCode.E)){
            if (distancePNJ_P.magnitude < 1 && !isInside)
            {
                
                dialogueTrigger.TriggerDialogue();
                isInside = true;
            }
            
        }else if  (distancePNJ_P.magnitude > 1)
            {
                isInside = false;

            FindObjectOfType<DialogueManager>().EndDialogue() ;
            
            }
      //  else isInside = false; 
>>>>>>> Stashed changes
    }


}
