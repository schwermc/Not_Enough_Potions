using System.Reflection;
using NSubstitute;
using NUnit.Framework;

public class ShopCounterTest
{
    private ShopCounter shop;
    private InventoryData inventory;
    private CustomerCart cart;
    //private ItemData item;

    [SetUp]
    public void SetUp()
    {
        ItemData item = new ItemData();
        item.ingredientName = GetName();

        shop = Substitute.For<ShopCounter>();
        cart = Substitute.For<CustomerCart>();
        inventory = new InventoryData();

        cart.Container.Add(new CartItem());
        //cart.Container[0].
        cart.Container[0].getAmount().Returns(1);
        inventory.Container.Add(new InventorySlot(item, GetAmount()));
    }

    [Test]
    public void canSellItem()
    {
        var shopMethod = GetShopMethod("CanSell");

        //Assert.IsTrue(shopMethod.Invoke(shop, null));
    }

    string GetName() { return "testing"; }
    int GetAmount() { return 1; }

    MethodInfo GetShopMethod(string methodName)
    {
        if (string.IsNullOrWhiteSpace(methodName))
            Assert.Fail("methodName cannot be null or whitespace");
        
        var method = typeof(ShopCounter).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

        if (method == null)
            Assert.Fail(string.Format("{0} method not found", methodName));
        
        return method;
    }
}
