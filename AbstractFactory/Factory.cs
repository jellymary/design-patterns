using System;

namespace AbstractFactory
{
    // AbstractFactory
    public interface ICarFactory
    {
        IBody CreateBody();
        IEngine CreateEngine();
        IInterior CreateInterior();
        IWheels CreateWheels();
        IWindows CreateWindows();
    }

    // AbstractProducts
    public interface IBody {}
    public interface IEngine {}
    public interface IInterior {}
    public interface IWheels {}
    public interface IWindows {}

    // ConcreteFactory 1
    public class BmwFactory : ICarFactory
    {
        public IBody CreateBody() => new BmwBody();
        public IEngine CreateEngine() => new BmwEngine();
        public IInterior CreateInterior() => new BmwInterior();
        public IWheels CreateWheels() => new BmwWheels();
        public IWindows CreateWindows() => new BmwWindows();
    }

    // Products 1
    public class BmwBody : IBody {}
    public class BmwEngine : IEngine {}
    public class BmwInterior : IInterior {}
    public class BmwWheels : IWheels {} 
    public class BmwWindows : IWindows {}

    // ConcreteFactory 2
    public class AudiFactory : ICarFactory
    {
        public IBody CreateBody() => new AudiBody();
        public IEngine CreateEngine() => new AudiEngine();
        public IInterior CreateInterior() => new AudiInterior();
        public IWheels CreateWheels() => new AudiWheels();
        public IWindows CreateWindows() => new AudiWindows();
    }

    // Products 2
    public class AudiBody : IBody {}
    public class AudiEngine : IEngine {}
    public class AudiInterior : IInterior {}
    public class AudiWheels : IWheels {} 
    public class AudiWindows : IWindows {}

    // Client
    public class Car
    {
        public IBody Body { get; }
        public IEngine Engine { get; }
        public IInterior Interior { get; }
        public IWheels Wheels { get; }
        public IWindows Windows { get; }

        public Car(ICarFactory carFactory)
        {
            Body = carFactory.CreateBody();
            Engine = carFactory.CreateEngine();
            Interior = carFactory.CreateInterior();
            Wheels = carFactory.CreateWheels();
            Windows = carFactory.CreateWindows();
        }
    }
}