using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Casque,
    Armure,
    Arme,
    Botte,
    Gants,

}
[CreateAssetMenu]
public class EquipableItems : Item
{
    public int PointDAttaque;
    public int PointDeDefence;
    public EquipmentType EquipmentType;
}
