
using System.Threading.Channels;

List<string> names = new List<string>();

bool close = false;

do
{
    Console.Clear();
    Console.WriteLine("1. Voeg een naam toe");
    Console.WriteLine("2. Toon alle namen");
    Console.WriteLine("3. Zoek een naam");
    Console.WriteLine("4. Verwijder een naam");
    Console.WriteLine("5. Toon het aantal namen");
    Console.WriteLine("6. Stoppen");
    Console.Write("Kies een optie: ");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Clear();
            Console.Write("Typ de naam die u wilt toevoegen: ");
            string inputAddedName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputAddedName))
            {
                inputAddedName = char.ToUpper(inputAddedName[0]) + inputAddedName.Substring(1).ToLower();
                
                if (names.IndexOf(inputAddedName) != -1)
                {
                    Console.WriteLine($"{inputAddedName} staat al in de lijst");
                    Console.ReadKey(true);
                }
                else
                {
                    names.Add(inputAddedName);
                }               
            }
            else 
            {
                Console.WriteLine("Ongeldige input");
            }
            break;
        case "2":
            Console.Clear();
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey(true);
            break;
        case "3":
            Console.Clear();
            Console.Write("Welke naam wilt u zoeken?: ");
            string inputSearchedName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputSearchedName))
            {
                inputSearchedName = char.ToUpper(inputSearchedName[0]) + inputSearchedName.Substring(1).ToLower();
                
                int searchedNameIndex = names.IndexOf(inputSearchedName);

                if (searchedNameIndex == -1)
                {
                    Console.WriteLine("De naam komt niet in de lijst voor!");
                }
                else
                {
                    Console.WriteLine($"{inputSearchedName} komt voor in de lijst op plaats {searchedNameIndex + 1}");
                }
            }
            else
            { 
                Console.WriteLine("Ongeldige input");
            }
            Console.ReadKey(true);
            break;
        case "4":
            Console.Clear();
            Console.Write("Welke naam wilt u verwijderen?: ");
            string inputDeletedName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputDeletedName))
            {
                int searchedNameIndex = names.IndexOf(inputDeletedName);

                if (searchedNameIndex == -1)
                {
                    Console.WriteLine($"{inputDeletedName} komt niet in de lijst voor!");
                }
                else
                {
                    names.RemoveAt(searchedNameIndex);
                }
            }
            else
            {
                Console.WriteLine("Ongeldige input");
            }
            Console.ReadKey(true);
            break;
        case "5":
            Console.Clear();
            int namesInList = names.Count;
            Console.WriteLine($"Er zitten {namesInList} namen in de lijst");
            Console.ReadKey(true);
            break;
        case "6":
            close = true;
            break;
        default:
            break;
    }
}
while (close == false);
