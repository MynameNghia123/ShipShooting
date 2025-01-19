using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("Item Upgrade")]
    [SerializeField] protected int maxLevel = 9;
    int i = 0;
    protected override void Start()
    {
        base.Start();
        //Invoke(nameof(Test), 1f);
        //Invoke(nameof(Test), 2f);
        //Invoke(nameof(Test), 3f);


    }
    public virtual void Test()
    {
        i++;
        UpgradeItem(0);
        Debug.Log(i);
    }
    public virtual bool UpgradeItem(int indexItem)
    {
        if (indexItem >= this.inventory.Items.Count) return false;
        ItemInventory itemInventory = this.inventory.Items[indexItem];
        if (itemInventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;
        if (!this.ItemUpgradeable(upgradeLevels)) return false;
        if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;

        this.DeductIngredients(upgradeLevels, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;

        return true;
    }
    protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevels)
    {
        if (upgradeLevels.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        if (currentLevel > upgradeLevels.Count)
        {
            Debug.LogError("Item cant upgrade anymore, current: " + currentLevel);
            return false;
        }

        // hummmmmmmm
        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredients ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            if (!this.inventory.ItemCheck(itemCode, itemCount)) return false;
        }
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredients ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            this.inventory.DeductItem(itemCode, itemCount);
        }
    }
}
