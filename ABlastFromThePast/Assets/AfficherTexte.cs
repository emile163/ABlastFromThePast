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
    }


}
