namespace GPArray
{
    class Program
    {
        //The array for the details of the arrangement in text
        static string[] arrangements = new string[100];
        //Multidimensional array :
        //int[100, 3] = { {0,1,2} {0,1,2} {0,1,2} ...x 100}
        static int[,] tickets = new int[1000,2];

        static void Main(string[] args)
        {
            //Add data til array
            AddToArray();
            //Looper menu infinite
            while(true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.WriteLine("\n1. Vis arrangementer \n2. Køb Billet\n3. Vis alle billetter\n\nIndtast valg");
            //Switcher on the numerical key pressed 
            switch (Console.ReadKey(true).Key)
            {
                //Both cases points to the same code
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowAllArrangements();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    ShowAllArrangements();
                    int t = BuyTicket();
                    Console.WriteLine("Billet nummer: " + t);
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    ShowTicketsBought();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// BuyTicket adds to ticketarray the number of tickets and the arrangement
        /// </summary>
        /// <returns>int next free spot</returns>
        static int BuyTicket()
        {
            Console.Write("Indtast nummer på arrangement du ønsker at købe billet til.");
            string input = Console.ReadLine();
            //Gets the string and tries to convert it to int.
            //If succes return is true and it outputs an int,
            //if fail nothing happens
            int.TryParse(input, out int arrangementNumber);
            Console.Write("Indtast antal ønskede billetter: ");
            //No reason to add another string. We ask directly on the readline()
            int.TryParse(Console.ReadLine(), out int amountOfTickets);

            int freeSpot = GetNextFreeSpotInTicketArray();
            //We insert out ticket data in our multiD array.
            //First the 0 pos, then the 1st. pos,
            //because microsoft sucks and cant add an array at one time
            tickets[freeSpot, 0] = amountOfTickets;
            tickets[freeSpot, 1] = arrangementNumber;
            return freeSpot;
        }
        /// <summary>
        /// Shows all the tickets that have been purchased by looping through all
        /// of the MultiD array, and stopping when its empty
        /// </summary>
        static void ShowTicketsBought()
        {
            Console.WriteLine("Antal\tArrangement\tLokation");
            for (int i = 0; i < tickets.Length; i++)
            {
                //If its empty we stop the loop
                if (tickets[i, 0] == 0) return;
                //Otherwise we print it on screen in details
                //by splitting the stringarray arrangements[]
                string arr = arrangements[tickets[i, 1]];
                string[] splitArray = arr.Split("- ");
                Console.WriteLine(tickets[i, 0] + "\t" + splitArray[0] + "\t" + splitArray[1]);
            }
        }
        /// <summary>
        /// Loops through all the ticket array, and return first empty spot
        /// unless its full, then it starts over from 0
        /// </summary>
        /// <returns></returns>
        static int GetNextFreeSpotInTicketArray()
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i,0] == 0) { return i; }
            }
            return 0;
        }
        static void ShowAllArrangements()
        {
            foreach (string arr in arrangements)
            {
                ShowArrangement(arr);
            }
        }

        static void ShowArrangement(string arr)
        {
            if (arr != null && arr != "")
            {
                //IndexOf takes the data of the array and ask what position it
                //have in the array.
                int i = Array.IndexOf(arrangements, arr);
                Console.WriteLine(i + " " + arr);
            }
        }

        static void AddToArray()
        {
            arrangements[0] = "Lil Johan - Den grå hal";
            arrangements[1] = "Deagle - TEC Kantinen";
            arrangements[2] = "Tec Lærerband - Amager Plads";
        }
    }

}
