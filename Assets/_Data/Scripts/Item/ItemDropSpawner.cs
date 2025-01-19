using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    protected static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl;
    [SerializeField] protected float dropGameRate = 1;
    protected override void LoadComponent()
    {
        base.LoadComponent();
      //  this.LoadItemCtrl();
    }
    protected virtual void LoadItemCtrl()
    {
        if (itemCtrl != null) return;
        GameObject t = GameObject.Find("PrefabsItem");
        Debug.Log(t.transform.parent.name);
        if (t != null)
        {
            itemCtrl = t.GetComponentInChildren<ItemCtrl>();
            Debug.Log(transform.name + ": Load Item Ctrl", gameObject);
        }
        else
        {
            Debug.LogWarning("can't find");
        }
    }
    protected override void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        // list ban đầu sẽ là rỗng sau khi chạy program sẽ add dần vào
        Transform prefabObj = transform.Find("PrefabsItem");

        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
            Debug.Log(prefab.name + " :loadPrefabs ");
        }
        Debug.Log(transform.name + " :loadPrefabs ");
    }
    protected override void Awake()
    {
        base.Awake();
        if(instance != null)
        {
            Debug.LogWarning("Only 1 Item Spawner in Scence");
            return;
        }
        instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();

        if (dropList.Count < 1) return null;
        dropItems = this.DropItems(dropList);
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemCode itemCode = itemDropRate.itemSO.itemCode;
            //Debug.Log(itemCode.ToString());
            Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }

        return dropItems;
    }
    public virtual Transform DropFromInventory(ItemInventory item, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = item.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if(itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(item);
        return itemDrop;
    }
    public virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();
        float rate, itemRate;
        int itemDropMore;
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1.0f);
            itemRate = item.dropRate/100000f * this.dropGameRate;
            itemDropMore = Mathf.FloorToInt(itemRate);

             
            if(itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++)
                    dropItems.Add(item);


            }
            if (rate <= itemRate)
            {
                dropItems.Add(item);
            }
        }
        return dropItems;
    }
    protected virtual float GameDropRate()
    {
        float dropRateFromItem = 0.5f;

        return this.dropGameRate * dropRateFromItem;
    }
}
