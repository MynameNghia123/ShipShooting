using System;
[Serializable]
public class ItemInventory 
{
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;
    public ItemInventory(ItemProfileSO itemProfile, int itemCount, int maxStack, int upgradeLevel)
    {
        this.itemProfile = itemProfile;
        this.itemCount = itemCount;
        this.maxStack = maxStack;
        this.upgradeLevel = upgradeLevel;
    }
    public ItemInventory()
    {
    }
}
