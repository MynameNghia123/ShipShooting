using System;
using System.Diagnostics;

public enum ItemCode
{
    NoItem = 0,

    IronOre = 1,
    GoldOre = 2,
    Sword = 3,
}
public class ItemCodeParse
{
    public static ItemCode FromString(string str)
    {
        try
        {
            return (ItemCode) System.Enum.Parse(typeof(ItemCode), str);
        }
        catch (ArgumentException e)
        {
            Debug.WriteLine(e.ToString());
            return ItemCode.NoItem;
        }
    }
}
