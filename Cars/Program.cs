using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel1.csv");

            var manufactorers = ProcessManufactorer("manufactorers1.csv");

            //var query = cars.OrderByDescending(c => c.Combined)
            //              .ThenBy(c => c.Name);

            var query =
                from car in cars
                //where car.Manufacturer == "TOYOTA" && car.Year == 2007
                join manufactorer in manufactorers 
                    on car.Manufacturer equals manufactorer.Name
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufactorer.Headquarters,
                    car.Name,
                    car.Combined
                };

            //var top =
            //    cars
            //    //.Where(c => c.Manufacturer == "TOYOTA" && c.Year == 2007)
            //    .OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name)
            //    .Select(c => c)
            //    .First(c => c.Manufacturer == "TOYOTA" && c.Year == 2007);



            var result = cars.SelectMany(c => c.Name);

            Console.WriteLine(result);

            foreach (var name in result)
            {
              
                    Console.WriteLine(name);
                
            }
            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Headquarters}  {car.Name} : {car.Combined}");
            }
        }

        private static List<Manufacturer> ProcessManufactorer(string path)
        {
            var query =
                File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var column = l.Split("\t");
                    return new Manufacturer
                    {
                        Name = column[0],
                        Headquarters = column[1],
                        Year = int.Parse(column[2])
                    };
                });
            return query.ToList();
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =
            //File.ReadAllLines(path)
            //     .Skip(1)
            //     .Where(line => line.Length > 1)
            //     .Select(Car.ParseFromCsv)
            //     .ToList();

            //from line in File.ReadAllLines(path).Skip(1)
            //where line.Length > 1
            //select Car.ParseFromCsv(line);

                File.ReadAllLines(path)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCar();

            return query.ToList();
        }
    }

    public static class CarExtansions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var column = line.Split("\t"); 

                yield return new Car
                {
                    Year = int.Parse(column[0]),
                    Manufacturer = column[1],
                    Name = column[2],
                    Displacement = double.Parse(column[3]),
                    Cylinders = int.Parse(column[4]),
                    City = int.Parse(column[5]),
                    Highway = int.Parse(column[6]),
                    Combined = int.Parse(column[7])
                };
            }
        }
    }
}
