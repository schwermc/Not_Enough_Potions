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

    [Test]
    public void PotionStationData_CheckUpdateUI()
    {
        var potionStationData = Substitute.For<PotionStationData>();
        var preUpdate = potionStationData.getCheck();

        potionStationData.updateUI();
        Assert.AreNotEqual(preUpdate, potionStationData.getCheck());
    }
}
