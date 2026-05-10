using Lab3;

Transport[] transports = new Transport[]
{
    new Bus(20, 5, 50m),
    new Taxi(12m, 35m),
    new CommuterTrain(80, 45m)
};

decimal revenue = TripAccounting.TotalRevenue(transports);
Console.WriteLine($"Общая выручка за рейс: {revenue}");

OrdinaryCitizenCategory client = new OrdinaryCitizenCategory();
Console.WriteLine(
    $"Кредит (обычный гражданин): до  {client.GetMaxLoan(40_000m)} руб., ставка {client.GetAnnualRatePercent()} % годовых.");
