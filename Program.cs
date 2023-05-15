using System;

class City
{
    public int Id;
    public string Name;
    public int ContactCityId;
    public int InfectionLevel;

    public City(int id, string name, int contactCityId)
    {
        Id = id;
        Name = name;
        ContactCityId = contactCityId;
        InfectionLevel = 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of cities: ");
        int numCities = int.Parse(Console.ReadLine());

        City[] cities = new City[numCities];

        // Read city data
        for (int i = 0; i < numCities; i++)
        {
            Console.WriteLine($"Enter details for City {i}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Contact City ID: ");
            int contactCityId = int.Parse(Console.ReadLine());

            // Check for valid contact city ID
            while (contactCityId < 0 || contactCityId > i || contactCityId == i)
            {
                Console.WriteLine("Invalid ID. Please enter again.");
                Console.Write("Contact City ID: ");
                contactCityId = int.Parse(Console.ReadLine());
            }

            cities[i] = new City(i, name, contactCityId);
        }

        // Simulate virus spread
        cities[0].InfectionLevel = 1; // Assume first city is infected

        for (int i = 1; i < numCities; i++)
        {
            int contactCityId = cities[i].ContactCityId;
            cities[i].InfectionLevel = cities[contactCityId].InfectionLevel;
        }

        // Display city data
        Console.WriteLine("City Data:");
        Console.WriteLine("ID\tName\tInfection Level");
        foreach (City city in cities)
        {
            Console.WriteLine($"{city.Id}\t{city.Name}\t{city.InfectionLevel}");
        }
    }
}
