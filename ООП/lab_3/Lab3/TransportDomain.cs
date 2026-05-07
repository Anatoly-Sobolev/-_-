namespace Lab3;

/// <summary>Пассажирский транспорт: выручка за рейс — сумма оплат пассажиров.</summary>
public abstract class Transport
{
    public abstract decimal GetTripRevenue();
}

/// <summary>Автобус: полные и льготные билеты (льготный — половина цены).</summary>
public class Bus : Transport
{
    private readonly int _regularPassengers;
    private readonly int _concessionPassengers;
    private readonly decimal _ticketPrice;

    public Bus(int regularPassengers, int concessionPassengers, decimal ticketPrice)
    {
        _regularPassengers = regularPassengers;
        _concessionPassengers = concessionPassengers;
        _ticketPrice = ticketPrice;
    }

    public override decimal GetTripRevenue()
    {
        return _regularPassengers * _ticketPrice + _concessionPassengers * _ticketPrice * 0.5m;
    }
}

/// <summary>Такси: оплата по километражу.</summary>
public class Taxi : Transport
{
    private readonly decimal _kilometers;
    private readonly decimal _pricePerKm;

    public Taxi(decimal kilometers, decimal pricePerKm)
    {
        _kilometers = kilometers;
        _pricePerKm = pricePerKm;
    }

    public override decimal GetTripRevenue() => _kilometers * _pricePerKm;
}

/// <summary>Электричка: фиксированный билет на человека.</summary>
public class CommuterTrain : Transport
{
    private readonly int _passengers;
    private readonly decimal _ticketPrice;

    public CommuterTrain(int passengers, decimal ticketPrice)
    {
        _passengers = passengers;
        _ticketPrice = ticketPrice;
    }

    public override decimal GetTripRevenue() => _passengers * _ticketPrice;
}

public static class TripAccounting
{
    public static decimal TotalRevenue(IEnumerable<Transport> transports) =>
        transports.Sum(t => t.GetTripRevenue());
}
