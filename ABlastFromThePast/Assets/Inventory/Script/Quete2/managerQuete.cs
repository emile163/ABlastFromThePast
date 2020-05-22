using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerQuete : MonoBehaviour
{
    public List<Queteobjet> quetes;
    public void addQuete(Queteobjet quete)
    {
        quetes.Add(quete);
    }
}
