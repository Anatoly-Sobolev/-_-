namespace Lab3;

/// <summary>Категория клиента банка: свой расчёт лимита и ставки (полиморфизм).</summary>
public abstract class ClientCategory
{
    public abstract decimal GetMaxLoan(decimal monthlyIncome);
    public abstract decimal GetAnnualRatePercent();
}

public class BankEmployeeCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome) => monthlyIncome * 24m;
    public override decimal GetAnnualRatePercent() => 5m;
}

public class OrdinaryCitizenCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome) => monthlyIncome * 10m;
    public override decimal GetAnnualRatePercent() => 15m;
}

public class BadCreditHistoryCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome) => monthlyIncome * 4m;
    public override decimal GetAnnualRatePercent() => 26m;
}

public class PensionerCategory : ClientCategory
{
    public override decimal GetMaxLoan(decimal monthlyIncome) => monthlyIncome * 8m;
    public override decimal GetAnnualRatePercent() => 9m;
}
