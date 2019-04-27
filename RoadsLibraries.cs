using System.Collections.Generic;

namespace Hackerrank
{
    public class City
    {
        public int Id { get; set; }
        public List<int> ConnectedCities {get;set;} 

        public City(int id )
        {
            Id = id;
            ConnectedCities = new List<int>();
        }
    }

    public static class RoadsLibraries
    {
        internal static long RoadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
        {
            if(c_road > c_lib)
            {
                return (long)c_lib * n;
            }

            var listOfCities = new City[n+1];
            for(int i = 1; i <= n ; i++)
            {
                var city = new City(i);
                listOfCities[i] = city;
            }

            for(int i = 0; i < cities.Length; i++)
            {
                var source = cities[i][0];
                var destination = cities[i][1];
                listOfCities[source].ConnectedCities.Add(destination);
                listOfCities[destination].ConnectedCities.Add(source);
            }

            return FindConstructionScope(listOfCities, c_road, c_lib, n);
        }

        static long FindConstructionScope(City[] listofCities, int c_road, int c_lib, int numberOfCities)
        {
            var cityVisited = new bool[numberOfCities + 1];
            long totalCost = 0;
            for(int i = 1; i <= numberOfCities; i++)
            {
                if(cityVisited[i])
                    continue;

                var bfs = new Queue<int>();
                bfs.Enqueue(listofCities[i].Id);
                var roadsRequired = -1; // We want to count roads only from the second city.
                while(bfs.Count != 0)
                {
                    var cityId = bfs.Dequeue();
                    if(cityVisited[cityId]) continue;
                    cityVisited[cityId] = true;
                    roadsRequired++;

                    foreach(var connection in listofCities[cityId].ConnectedCities)
                    {
                        if(cityVisited[connection])
                            continue;

                        bfs.Enqueue(connection);
                    }
                }
                totalCost += (roadsRequired * c_road) + c_lib;
            }
            return totalCost;
        }
    }
}