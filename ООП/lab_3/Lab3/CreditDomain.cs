namespace Lab3;

/// <summary>Категория клиента банка: свой расчёт лимита и ставки (полиморфизм).</summary>
public abstract class ClientCategory
{
    public abstract decimal GetMaxLoan(decimal monthlyIncome);
    public abstract decimal GetAnnualRatePercent();
}

public class BankEmployeeCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome)
    {
        return monthlyIncome * 24m;
    }

    public override decimal GetAnnualRatePercent()
    {
        return 5m;
    }
}

public class OrdinaryCitizenCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome)
    {
        return monthlyIncome * 10m;
    }

    public override decimal GetAnnualRatePercent()
    {
        return 15m;
    }
}

public class BadCreditHistoryCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome)
    {
        return monthlyIncome * 4m;
    }

    public override decimal GetAnnualRatePercent()
    {
        return 26m;
    }
}

public class PensionerCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome)
    {
        return monthlyIncome * 8m;
    }

    public override decimal GetAnnualRatePercent()
    {
        return 9m;
    }
}
