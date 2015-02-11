﻿using System;
using NServiceBus;

class Program
{

    static void Main()
    {
        var busConfig = new BusConfiguration();
        busConfig.EndpointName("Samples.ComplexSagaFindingLogic");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.UsePersistence<InMemoryPersistence>();

        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            bus.SendLocal(new StartOrder
                          {
                              OrderId = "123"
                          });
            bus.SendLocal(new StartOrder
                          {
                              OrderId = "456"
                          });
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.ReadKey();
        }
    }
}
