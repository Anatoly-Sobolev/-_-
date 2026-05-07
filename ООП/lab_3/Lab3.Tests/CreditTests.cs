using Lab3;
using NUnit.Framework;

namespace Lab3.Tests;

[TestFixture]
public class CreditTests
{
    [Test]
    public void BankEmployee_HigherLimitThanOrdinary()
    {
        var emp = new BankEmployeeCategory();
        var ord = new OrdinaryCitizenCategory();
        var income = 50_000m;
        Assert.That(emp.GetMaxLoan(income), Is.GreaterThan(ord.GetMaxLoan(income)));
    }

    [Test]
    public void BankEmployee_LowerRateThanBadHistory()
    {
        var emp = new BankEmployeeCategory();
        var bad = new BadCreditHistoryCategory();
        Assert.That(emp.GetAnnualRatePercent(), Is.LessThan(bad.GetAnnualRatePercent()));
    }

    [Test]
    public void OrdinaryCitizen_MaxLoan_IsTenMonthsIncome()
    {
        var c = new OrdinaryCitizenCategory();
        Assert.That(c.GetMaxLoan(30_000m), Is.EqualTo(300_000m));
    }

    [Test]
    public void BadHistory_MaxLoan_IsFourMonthsIncome()
    {
        var c = new BadCreditHistoryCategory();
        Assert.That(c.GetMaxLoan(25_000m), Is.EqualTo(100_000m));
    }

    [Test]
    public void Pensioner_Rate_IsLessThanOrdinary()
    {
        var p = new PensionerCategory();
        var o = new OrdinaryCitizenCategory();
        Assert.That(p.GetAnnualRatePercent(), Is.LessThan(o.GetAnnualRatePercent()));
    }

    [Test]
    public void BankEmployee_MaxLoan_IsTwentyFourMonthsIncome()
    {
        var c = new BankEmployeeCategory();
        Assert.That(c.GetMaxLoan(10_000m), Is.EqualTo(240_000m));
    }

    [Test]
    public void Pensioner_MaxLoan_IsEightMonthsIncome()
    {
        var c = new PensionerCategory();
        Assert.That(c.GetMaxLoan(15_000m), Is.EqualTo(120_000m));
    }

    [Test]
    public void OrdinaryCitizen_Rate_Is15()
    {
        Assert.That(new OrdinaryCitizenCategory().GetAnnualRatePercent(), Is.EqualTo(15m));
    }

    [Test]
    public void BadHistory_HasHighestRateAmongAll()
    {
        var bad = new BadCreditHistoryCategory().GetAnnualRatePercent();
        Assert.That(bad, Is.EqualTo(26m));
        Assert.That(bad, Is.GreaterThan(new OrdinaryCitizenCategory().GetAnnualRatePercent()));
        Assert.That(bad, Is.GreaterThan(new PensionerCategory().GetAnnualRatePercent()));
    }

    [Test]
    public void PolymorphicClientCategory_UsesCorrectImplementation()
    {
        ClientCategory cat = new BankEmployeeCategory();
        Assert.That(cat.GetAnnualRatePercent(), Is.EqualTo(5m));
        Assert.That(cat.GetMaxLoan(1000m), Is.EqualTo(24_000m));
    }
}
