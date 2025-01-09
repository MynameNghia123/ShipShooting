using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    protected static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl;
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

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Debug.Log(itemCode.ToString());
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
    public virtual Transform Drop(ItemInventory item, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = item.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if(itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(item);
        return itemDrop;
    }
}
