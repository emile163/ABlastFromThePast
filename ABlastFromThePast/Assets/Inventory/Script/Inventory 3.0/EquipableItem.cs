using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Casque, 
    Armure,
    Botte,
    Gants,
    Arme,
    autre,
}

[CreateAssetMenu]
public class EquipableItem : Item
{
    public string nomStat;
    public int stat;
    public EquipmentType EquipmentType;
}
