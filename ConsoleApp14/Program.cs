using System.Text;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int[] resulNumbers = randomNumbers();

             Console.WriteLine("La cantidad es " + cantidad(resulNumbers));
             Console.WriteLine("El maximo es " + maxValue(resulNumbers));
             Console.WriteLine("El minimo es " + minValue(resulNumbers));
             Console.WriteLine("El promedio es " + prom(resulNumbers));
             Console.WriteLine("El valor 0 repetido es " + value0(resulNumbers));
             Console.WriteLine("5 primeros valores");

             first5Values(resulNumbers);

             Console.WriteLine("====ORDENAR===");

             var result = orderNumbers(resulNumbers);
             foreach (int i in result)
             {
                 Console.WriteLine(i);


             }
             Console.WriteLine("====Remplazar===");

             var result2 = replaceValue(resulNumbers);
             foreach (int j in result2)
             {
                 Console.WriteLine(j);


             }
            string[] resultWords= wordRandoms();
            Console.WriteLine("hola se repite " + holaTimes(resultWords)+" veces");

            double probability = calculateParadox(1000000);
            Console.WriteLine("La probabilidad de que al menos dos personas compartan cumpleaños en un grupo de 23 personas es aproximadamente "+ probability);


        }

        public static int[] randomNumbers()
        {
            int[] number = new int[10000];
            Random random = new Random();
            for (int i = 0; i < 10000; i++) {

                var value = random.Next(-10000, 10000);
                number[i] = value;
            }
            return number;
        }

        public static int cantidad(int[] values)
        {
            return values.Length;
        }

        public static int maxValue(int[] values)
        {
            int c = values[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > c)
                {
                    c = values[i];
                }
            }
            return c;


        }

        public static int minValue(int[] values)
        {
            int c = values[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < c)
                {
                    c = values[i];
                }
            }
            return c;

        }

        public static int prom(int[] values)
        {
            int c = 0;
            for (int i = 0; i < values.Length; i++)
            {
                c = c + values[i];
            }
            return c / values.Length;

        }

        public static int value0(int[] values)
        {
            int c = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    c++;
                }
            }
            return c;

        }

        public static void first5Values(int[] values)
        {
            var result = values.GroupBy(x => x)
                                      .Select(group => new { Value = group.Key, Count = group.Count() })
                                      .OrderByDescending(x => x.Count)
                                      .Take(5);

            foreach (var item in result)
            {
                Console.WriteLine("numero:" + item.Value +" veces repetida: " +item.Count);
            }
        }

        public static int[] orderNumbers(int[] values)
        {
            for (int i = 0; i < values.Length - 1; i++) {

                for (int j = 0; j < values.Length - 1; j++)
                {
                    if (values[j] > values[j + 1]) {
                        var temp = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = temp;
                    }
                }
            }
            return values;
        }

        public static int[] replaceValue(int[] values)
        {
            for (int i = 0; i < values.Length; i++) {
                if (values[i] % 2 != 0)
                {
                    values[i] = values[i]+1;
                }
            }
            return values;
        }

        static string[] wordRandoms()
        {
            Random rnd = new Random();
            string[] wordList = new string[10000000];

            for (int i = 0; i < 10000000; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < 4; j++)
                {
                    char aleatorio = (char)(97 + rnd.Next(26)); 
                    sb.Append(aleatorio);
                }
                wordList[i] = sb.ToString();
            }

            return wordList;
        }

        public static int holaTimes(string[] values)
        {
            int c = 0;
            for (int i = 0;i < values.Length;i++)
            {
                if (values[i] == "hola") {
                    c++;
                }
        }
            return c;
        }
        static double calculateParadox(int iterations)
        {
            Random rnd = new Random();
            int matches = 0;

            for (int i = 0; i < iterations; i++)
            {
                if (sharedBirthdayInGroup(rnd, 23))
                    matches++;
            }

            return (double)matches / iterations;
        }

        static bool sharedBirthdayInGroup(Random rnd, int groupSize)
        {
            int[] birthdays = new int[365];

            for (int j = 0; j < groupSize; j++)
            {
                int day = rnd.Next(365);
                if (birthdays[day] == 1)
                    return true;
                birthdays[day] = 1;
            }

            return false;
        }
    }
    }