using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObjectSO")]
public class ShootableObjectSO : ScriptableObject
{
    public string objName = "Shootable Object";
    public ObjectType objType;
    public int maxHp = 2;
    public List<ItemDropRate> dropList;
}
