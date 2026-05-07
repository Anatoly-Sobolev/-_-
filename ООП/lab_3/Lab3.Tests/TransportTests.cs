using Lab3;
using NUnit.Framework;

namespace Lab3.Tests;

[TestFixture]
public class TransportTests
{
    [Test]
    public void Bus_OnlyRegular_PaysFullPrice()
    {
        var bus = new Bus(10, 0, 40m);
        Assert.That(bus.GetTripRevenue(), Is.EqualTo(400m));
    }

    [Test]
    public void Bus_ConcessionPaysHalf()
    {
        var bus = new Bus(0, 4, 100m);
        Assert.That(bus.GetTripRevenue(), Is.EqualTo(200m));
    }

    [Test]
    public void Bus_MixedRegularAndConcession()
    {
        var bus = new Bus(2, 2, 50m);
        Assert.That(bus.GetTripRevenue(), Is.EqualTo(150m));
    }

    [Test]
    public void Taxi_RevenueIsKmTimesRate()
    {
        var taxi = new Taxi(10m, 30m);
        Assert.That(taxi.GetTripRevenue(), Is.EqualTo(300m));
    }

    [Test]
    public void Taxi_FractionalKm()
    {
        var taxi = new Taxi(2.5m, 40m);
        Assert.That(taxi.GetTripRevenue(), Is.EqualTo(100m));
    }

    [Test]
    public void CommuterTrain_AllPassengersPaySameTicket()
    {
        var train = new CommuterTrain(25, 60m);
        Assert.That(train.GetTripRevenue(), Is.EqualTo(1500m));
    }

    [Test]
    public void CommuterTrain_NoPassengers()
    {
        var train = new CommuterTrain(0, 100m);
        Assert.That(train.GetTripRevenue(), Is.EqualTo(0m));
    }

    [Test]
    public void TripAccounting_SumsSeveralTransports()
    {
        var parts = new Transport[]
        {
            new Bus(1, 0, 10m),
            new Taxi(1m, 10m),
            new CommuterTrain(1, 10m)
        };
        Assert.That(TripAccounting.TotalRevenue(parts), Is.EqualTo(30m));
    }

    [Test]
    public void TripAccounting_EmptyList_IsZero()
    {
        Assert.That(TripAccounting.TotalRevenue(Array.Empty<Transport>()), Is.EqualTo(0m));
    }

    [Test]
    public void PolymorphicCollection_UsesOverride()
    {
        Transport t = new Taxi(3m, 10m);
        Assert.That(t.GetTripRevenue(), Is.EqualTo(30m));
    }
}
