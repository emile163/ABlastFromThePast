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
  public GameObject TextBox;
    public GameObject Text;
    public Vector3 distancePNJ_P;
    bool isActive = false;
    // Update is called once per frame
    void Update()
    {
        distancePNJ_P = Target.transform.position- this.transform.position;
        if (distancePNJ_P.magnitude < 1)
        {
            Text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                isActive = !isActive;
                TextBox.SetActive(isActive);
                
                // (TextBox).SetActive(true) ;
            }
        }
        else
        {
            Text.SetActive(false);

            (TextBox).SetActive(false);
        }
    }


}
