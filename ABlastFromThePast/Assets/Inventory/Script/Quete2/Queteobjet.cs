using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
///
/// La classe Queteobjet sert à définir ce qu'est une quête 
///
public class Queteobjet 
{

    public string title;
    public string description;
    public int indexQuete;
    public bool isActive;
    public Item[] rewards;
    public QuestGoal qG;
    public bool questEnded;
    private int QuestIndex;
    public GameObject desactiveObjet;
    public GameObject active;
}
