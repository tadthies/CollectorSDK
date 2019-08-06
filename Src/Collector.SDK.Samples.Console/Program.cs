﻿using Collector.SDK.Collectors;
using Collector.SDK.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.SDK.Samples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = File.OpenText(@"ad-collector-config.json"))
            {
                var serializer = new JsonSerializer();
                // convert from json to the collector configuration object
                var collectorConfig = (CollectorConfiguration)serializer.Deserialize(file, typeof(CollectorConfiguration));
                // instantiate the collector
                var collector = CollectorFactory.CreateCollector(collectorConfig);
                // Run it...
                collector.Run();
            }
            System.Console.ReadKey();
        }
    }
}
