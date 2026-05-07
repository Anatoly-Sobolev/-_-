using NUnit.Framework;
using Task8_Stack;

namespace Lab4.Tests;

[TestFixture]
public class StackTests
{
    [Test]
    public void StudyThink_IsGoodDecision()
    {
        var t = Think.CreateWithType(TypeThink.Study, "Надо сделать лабу");
        Assert.That(t.GetDecision(), Is.True);
    }

    [Test]
    public void FoodThink_IsBadDecision()
    {
        var t = Think.CreateWithType(TypeThink.Food, "Хочу есть");
        Assert.That(t.GetDecision(), Is.False);
    }

    [Test]
    public void GamesThink_IsBadDecision()
    {
        var t = Think.CreateWithType(TypeThink.Games, "Хочу поиграть");
        Assert.That(t.GetDecision(), Is.False);
    }

    [Test]
    public void GetThinkInfo_ContainsType()
    {
        var t = Think.CreateWithType(TypeThink.Study, "Текст");
        Assert.That(t.GetThinkInfo(), Does.Contain("Study"));
    }

    [Test]
    public void GetThinkInfo_ContainsText()
    {
        var t = Think.CreateWithType(TypeThink.Food, "Хочу в KFC");
        Assert.That(t.GetThinkInfo(), Does.Contain("Хочу в KFC"));
    }
}
