using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]

public class ItemSO : ScriptableObject
{
    public ItemCode codeItem = 0;
    public string itemName = "Item";
}
