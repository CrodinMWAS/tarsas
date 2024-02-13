namespace Tarsas
{
    internal class Program
    {
        static List<string> Paths = new List<string>();
        static List<string> Dice = new List<string>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("osvenyek.txt");
            while (!(sr.EndOfStream))
            {
                Paths.Add(sr.ReadLine());
            }
            sr = new StreamReader("dobasok.txt");
            while (!(sr.EndOfStream))
            {
                string[] round = sr.ReadLine().Split(" ");
                foreach (var item in round)
                {
                    Dice.Add(item);
                }
            }
            Console.WriteLine("2. Feladat: ");
            Console.WriteLine($"Dobások száma: {Dice.Count}");
            Console.WriteLine($"Ösvények száma: {Paths.Count}");
            int longest = 0;
            int longestPlace = 0;
            int counter = 1;
            foreach (var item in Paths)
            {
                if (item.Length >= longest)
                {
                    Console.WriteLine(item.Length);
                    longest = item.Length;
                    longestPlace = counter;
                }
                counter++;
            }
            Console.WriteLine("3. Feladat: ");
            Console.WriteLine($"Leghosszabb Ösvény: {longestPlace}  Hossz: {longest}");
            Console.WriteLine("4. Feladat: ");
            Console.Write("Adja meg egy ösvény sorszámát! ");
            string SelectedPathString = Console.ReadLine();
            Console.Write("Adja meg a Játékosok számát! ");
            string PlayerCountString = Console.ReadLine();

            int SelectedPath = 0;
            int PlayerCount = 0;
            try
            {
                SelectedPath = Convert.ToInt32(SelectedPathString);
                PlayerCount = Convert.ToInt32(PlayerCountString);

                if (PlayerCount < 2 || PlayerCount > 5)
                {
                    Console.WriteLine("Legyen Több játékos mint 2, és kisebb mint 5!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("számot!");
            }

            int CounterM = 0;
            int CounterV = 0;
            int CounterE = 0;
            counter = 1;
            List<int> Specials = new List<int>();
            int pathLength = 0;
            foreach (var path in Paths)
            {
                if (counter == SelectedPath)
                {
                    foreach (var item in path)
                    {
                        if (item == 'M')
                        {
                            CounterM++;
                        }
                        else if (item == 'V')
                        {
                            CounterV++;
                            Specials.Add(pathLength);
                            Specials.Add(item);
                        }
                        else if (item == 'E')
                        {
                            CounterE++;
                            Specials.Add(pathLength);
                            Specials.Add(item);
                        }
                        pathLength++;
                    }
                }
                counter++;
            }
            Console.WriteLine("5. Feladat: ");
            Console.WriteLine($"M: {CounterM} \nV: {CounterV} \nE: {CounterE}");

            StreamWriter sw = new StreamWriter("kulonleges.txt");
            for (int i = 0; i != Specials.Count; i++)
            {
                sw.WriteLine($"{Specials[i]}    {Convert.ToChar(Specials[++i])}");
            }
            sw.Close();

            Console.WriteLine("7. Feladat: ");
            for (int i = 0; i != Dice.Count; i++)
            {

            }
        }
    }
}