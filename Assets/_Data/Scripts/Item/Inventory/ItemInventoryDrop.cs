using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 6.0f);
    }
    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }
    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = inventory.Items[itemIndex];
        //Debug.Log(itemInventory.itemProfile.itemCode);
        //Debug.Log(itemInventory.upgradeLevel);

        Vector3 pos = transform.position;
        pos.x += 1;
        Quaternion ros = transform.rotation;
        ItemDropSpawner.Instance.Drop(itemInventory, pos, ros);
        this.inventory.Items.Remove(itemInventory);
    }
}
