namespace WeatherStationSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of days to simulate: ");
            int days = int.Parse(Console.ReadLine()!);

            int[] temperatures = new int[days];

            string[] conditions = ["Snowy","Rainy","Sunny","Cloudy"];
            string[] weatherConditions = new string[days];

            Random random = new Random();

            for (int i = 0; i < days; i++)
            {
                temperatures[i] = random.Next(-10, 49);
                weatherConditions[i] = GetWeatherCondition(temperatures[i],random);
            }

            double avgTemp = AvgTemperature(temperatures);
            Console.WriteLine($"Average temperature for the last {days} is {avgTemp}");
            Console.WriteLine($"The max temp was: {temperatures.Max()}");
            //Console.WriteLine(MaxTemp(temperatures));
            Console.WriteLine($"The min temp was: {temperatures.Min()}");
            //Console.WriteLine(MinTemp(temperatures));
            Console.WriteLine($"Most Common Weather Conditions: {mostCommonWeather(weatherConditions)}");
        }

        //static int MinTemp(int[] temperatures)
        //{
        //    int min = temperatures[0];
        //    for (int i = 1; i < temperatures.Length; i++)
        //    {
        //        if (temperatures[i] < min) { min = temperatures[i]; }
        //    }
        //    return min;
        //}

        //static int MaxTemp(int[] temperatures)
        //{
        //    int max = temperatures[0];
        //    for (int i = 1; i < temperatures.Length; i++)
        //    {
        //        if (temperatures[i] > max) { max = temperatures[i]; }
        //    }
        //    return max;
        //}

        static double AvgTemperature(in int[] temperatures)
        {
            double sum = 0;
            foreach (int temperature in temperatures) { sum += temperature; }
            return sum/temperatures.Length;
        }

        static string GetWeatherCondition(int temperature,Random random)
        {
            if (temperature < 0)
            {
                return "Snowy";
            }
            else if(temperature <15)
            {
                return random.Next(2) == 0 ? "Cloudy" : "Rainy";
            }
            else if(temperature <25)
            {
                return random.Next(2) == 0 ? "Sunny" : "Cloudy";
            }
            else
            {
                return random.Next(4) == 0 ? "Rainy" : "Sunny";
            }
        }
    
        //static string mostCommonWeather(string[] weatherConditions)
        //{
        //    int count = 0;
        //    string mostCommon = weatherConditions[0];

        //    for (int i = 0; i < weatherConditions.Length; i++)
        //    {
        //        int tempCount = 0;
        //        for (int j = 0; j < weatherConditions.Length; j++)
        //        {
        //            if (weatherConditions[j] == weatherConditions[i])
        //            {
        //                tempCount++;
        //            }
        //        }
        //        if (tempCount > count)
        //        {
        //            count = tempCount;
        //            mostCommon = weatherConditions[i];
        //        }
        //    }
        //    return mostCommon;
        //}

        static string mostCommonWeather(string[] weatherConditions)
        {
            Dictionary<string, int> frequency = new();
            foreach (string condition in weatherConditions)
            {
                if (frequency.ContainsKey(condition))
                {
                    frequency[condition]++;
                }
                else
                {
                    frequency[condition] = 1;
                }
            }

            string mostCommon = weatherConditions[0];
            int maxCount = 0;

            foreach (var pair in frequency)
            {
                if (pair.Value > maxCount)
                {
                    maxCount = pair.Value;
                    mostCommon = pair.Key;
                }
            }
            return mostCommon;
        }

    }
}
