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
public enum NomStat
{
    Attaque,
    Defence,
    Autre,
}

[CreateAssetMenu]
public class EquipableItem : Item
{
    public NomStat NomStat;
    public int stat;
    public EquipmentType EquipmentType;
}
