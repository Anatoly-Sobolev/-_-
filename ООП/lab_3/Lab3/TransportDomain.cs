namespace Lab3;

/// <summary>Пассажирский транспорт: выручка за рейс — сумма оплат пассажиров.</summary>
public abstract class Transport
{
    public abstract decimal GetTripRevenue();
}

/// <summary>Автобус: полные и льготные билеты (льготный — половина цены).</summary>
public class Bus : Transport
{
    public int RegularPassengers { get; }
    public int ConcessionPassengers { get; }
    public decimal TicketPrice { get; }

    public Bus(int regularPassengers, int concessionPassengers, decimal ticketPrice)
    {
        RegularPassengers = regularPassengers;
        ConcessionPassengers = concessionPassengers;
        TicketPrice = ticketPrice;
    }

    public override decimal GetTripRevenue()
    {
        decimal regularRevenue = RegularPassengers * TicketPrice;
        decimal concessionRevenue = ConcessionPassengers * TicketPrice * 0.5m;
        return regularRevenue + concessionRevenue;
    }
}

/// <summary>Такси: оплата по километражу.</summary>
public class Taxi : Transport
{
    public decimal Kilometers { get; }
    public decimal PricePerKm { get; }

    public Taxi(decimal kilometers, decimal pricePerKm)
    {
        Kilometers = kilometers;
        PricePerKm = pricePerKm;
    }

    public override decimal GetTripRevenue()
    {
        return Kilometers * PricePerKm;
    }
}

/// <summary>Электричка: фиксированный билет на человека.</summary>
public class CommuterTrain : Transport
{
    public int Passengers { get; }
    public decimal TicketPrice { get; }

    public CommuterTrain(int passengers, decimal ticketPrice)
    {
        Passengers = passengers;
        TicketPrice = ticketPrice;
    }

    public override decimal GetTripRevenue()
    {
        return Passengers * TicketPrice;
    }
}

public static class TripAccounting
{
    public static decimal TotalRevenue(IEnumerable<Transport> transports)
    {
        decimal totalRevenue = 0m;

        foreach (Transport transport in transports)
        {
            decimal transportRevenue = transport.GetTripRevenue();
            totalRevenue = totalRevenue + transportRevenue;
        }

        return totalRevenue;
    }
}
