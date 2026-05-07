using NUnit.Framework;
using Task3_Queue;

namespace Lab4.Tests;

[TestFixture]
public class QueueTests
{
    [Test]
    public void TwoFails_StudentExpelled()
    {
        var s = Student.CreateWithGrades("Тест", 2, 2, 3, 4);
        Assert.That(s.GetDecision(), Is.True);
    }

    [Test]
    public void OneFail_StudentNotExpelled()
    {
        var s = Student.CreateWithGrades("Тест", 2, 3, 4, 5);
        Assert.That(s.GetDecision(), Is.False);
    }

    [Test]
    public void NoFails_StudentNotExpelled()
    {
        var s = Student.CreateWithGrades("Тест", 3, 4, 5, 4);
        Assert.That(s.GetDecision(), Is.False);
    }

    [Test]
    public void FourFails_StudentExpelled()
    {
        var s = Student.CreateWithGrades("Тест", 2, 2, 2, 2);
        Assert.That(s.GetDecision(), Is.True);
    }

    [Test]
    public void GetStudentInfo_ContainsName()
    {
        var s = Student.CreateWithGrades("Иванов", 3, 3, 3, 3);
        Assert.That(s.GetStudentInfo(), Does.Contain("Иванов"));
    }
}
