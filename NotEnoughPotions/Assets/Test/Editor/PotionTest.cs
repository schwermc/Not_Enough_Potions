using NSubstitute;
using NUnit.Framework;

public class PotionTest
{
    [Test]
    public void DisplayPotions_CheckCollision()
    {
        var displayPotions = Substitute.For<DisplayPotions>();
        displayPotions.SetCollision(true);
        Assert.IsTrue(displayPotions.GetCollision());
    }
}
