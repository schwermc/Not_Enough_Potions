using NUnit.Framework;
using UnityEngine;

public class InventoryTest
{
    private InventoryData iventory;
    private ItemData item;

    [SetUp]
    public void setUpTestInfo()
    {
        iventory = ScriptableObject.CreateInstance<InventoryData>();
        item = ScriptableObject.CreateInstance<ItemData>();
    }

    [Test]
    public void IventoryData_AddItemToIventory()
    {
        iventory.AddItem(item, 1);
        Assert.AreEqual(1, iventory.Container.Count);
    }

    [Test]
    public void IventoryData_FindItemInInventory()
    {
        bool itemFound = false;

        iventory.AddItem(item, 1);
        if (iventory.FindItem(item) > -1)
            itemFound = true;

        Assert.IsTrue(itemFound);
    }

    [Test]
    public void IventoryData_SubItemFromIventory()
    {
        iventory.AddItem(item, 1);
        iventory.SubItem(item, 1);
        Assert.AreEqual(0, iventory.Container[0].getAmount());
    }
}
