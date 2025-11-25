using NSubstitute;
using NUnit.Framework;

public class PotionTest
{
    DisplayPotions displayPotions;

    [SetUp]
    public void SetUp()
    {
        displayPotions = Substitute.For<DisplayPotions>();
        displayPotions.SetCollision(true);
    }

    [Test]
    public void DisplayPotions_GetCollision()
    {
        Assert.IsTrue(displayPotions.GetCollision());
    }
}
