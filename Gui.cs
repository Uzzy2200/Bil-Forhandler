using System;
namespace Bilhandler
{
    internal class Gui
    {
        private string path = @"/Users/uzzy/Projects/BilProjekt/Saved data/Bilhandler- Data.rtf";
        private Data data = new Data();
        public Gui()
        {
            while (true)
            {
                Menu();
            }
        }
        public void Menu()
        {
            //Console.Clear();
            Console.WriteLine("Køb og sælg dine køretøjer her! \n1 - Varevogne\n2 - Personbiler\n3 - Fælge\n4 - Save Data\n5 - Load Data");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    VarevognMenu();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    PersonbilerMenu();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    AccerseroizessMenu();
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SaveData();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    LoadData();
                    break;
               // default:
                 //   break;
            }
        }
        private void SaveData()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
            Console.WriteLine("File saved succesfully at " + path);
        }

        private void LoadData()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Creating new file at: " + path);
                SaveData();
            }
            string json = File.ReadAllText(path);
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.Clear();
            Console.WriteLine("File loaded succesfully from " + path);
        }
        public void VarevognMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu \n1 - Sælg din Varevogn\n2 - Alle Varevogne til salg\n9 - Home");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    SearchVarevogn();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowVarevogn();
                    break;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    Menu();
                    break;
            }
        }
        public void SearchVarevogn()
        {
            Console.Clear();
            Varevogn varevogn = new Varevogn();
            varevogn.Navn = GetString("Mærke: ");
            varevogn.Pris = GetInt("Pris: ");
            varevogn.År = GetInt("Årgang: ");
            varevogn.KM = GetInt("KM: ");
            data.Varevognlist.Add(varevogn);

        }
        public void ShowVarevogn(Varevogn v)
        {
            Console.Clear();
            Console.WriteLine($"{v.Navn} {v.År} {v.Pris} {v.KM}");
            Console.WriteLine();
            Console.Write("Tryk Enter for at vende tilbage: ");
            Console.ReadKey();
            Console.Clear();
        }
        private void ShowVarevogn()
        {
            foreach (Varevogn v in data.Varevognlist)
            {
                ShowVarevogn(v);
            }
        }
        public void PersonbilerMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu \n1 - Sælg din Personbiler\n2 - Alle Personbiler til salg\n9 - Home");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    SearchCars();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ListCars();
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    Menu();
                    break;
            }
        }
        public void SearchCars()
        {
            Console.Clear();
            Personbil personbil = new Personbil();
            personbil.Navn = GetString("Mærke: ");
            personbil.Pris = GetInt("Pris: ");
            personbil.År = GetInt("Årgang: ");
            personbil.KM = GetInt("KM: ");
            data.ListOfCars.Add(personbil);
        }
        public void ListCars(Personbil b)
        {
            Console.Clear();
            Console.WriteLine($"{b.Navn} {b.År} {b.Pris} {b.KM}");
            Console.WriteLine();
            Console.Write("Tryk Enter for at se næste bil: ");
            Console.ReadKey();
            Console.Clear();
        }
        private void ListCars()
        {
            foreach (Personbil b in data.ListOfCars)
            {
                ListCars(b);
            }
        }
        public void AccerseroizessMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu \n1 - Sælg dine Fælge\n2 - Fælge til salg\n9 - Home");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    SearchAcceseroizes();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ListOfAcces();
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    Menu();
                    break;
            }
        }
        private void SearchAcceseroizes()
        {
            Console.Clear();
            Accerseroizes acces = new Accerseroizes();
            acces.Navn = GetString("Navn: ");
            acces.Pris = GetInt("Pris: ");
            acces.År = GetInt("Årgang: ");
            acces.Stand = GetString("Stand: ");
            data.ListAcces.Add(acces);
        }
        private void ListOfAcces(Accerseroizes a)
        {
            Console.Clear();
            Console.WriteLine($"{a.Navn} {a.År} {a.Pris} {a.Stand}");
            Console.WriteLine();
            Console.Write("Tryk Enter for at vende tilbage: ");
            Console.ReadKey();
            Console.Clear();
        }
        private void ListOfAcces()
        {
            foreach (Accerseroizes a in data.ListAcces)
            {
                ListOfAcces(a);
            }
        }
        private int GetInt(string request)
        {
            int result;
            do
            {
                Console.WriteLine(request);
            }
            while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }
        private string GetString(string type)
        {
            string? input;
            do
            {
                Console.WriteLine(type);
                input = Console.ReadLine();
            }
            while (input == null || input == "");
            return input;
        }
    }
}
