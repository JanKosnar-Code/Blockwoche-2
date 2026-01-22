using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string message;
        string? Input;

        bool canParse;

        int lose = 0;
        int win = 0;

        while (true) 
        {
            Console.WriteLine("Spiel Starten?");
            Input = Console.ReadLine(); 
            Input = Input!.ToLower();

            Eingabe Eingabe = Eingabe.none;
            canParse = Enum.TryParse(Input, out Eingabe);

            if (Eingabe == Eingabe.none)
                Console.WriteLine("Nein Nein Nein so Darf das nicht sein!");
            else if (Eingabe == Eingabe.nein)
            {
                Console.WriteLine("Danke für das Spielen!");
                break;
            }
            else if (Eingabe == Eingabe.ja)
            {
                    Console.WriteLine($"Deine stats: {win} wins, {lose} loses");
                message = Spiel(Eingabe);
                if (message == "1L")
                    lose++;
                else if (message == "1W")
                    win++;
            }
        }
    }

    static string Spiel(Eingabe en)
    {
        string? Input;

        bool canParse;

        int Ppoints = 0;
        int Epoints = 0;

        int zahl;

        Random rnd = new Random();

        while (true) 
        {
           

            Console.WriteLine($"Punkte zum Gewinnen: {Ppoints}/{Epoints}");
            Console.WriteLine("Schere, Stein, Papier, Echse, Spock?");
            Input = Console.ReadLine();
            Input = Input!.ToLower();

            SpielVariablen SpielVariablen = SpielVariablen.none;
            canParse = Enum.TryParse(Input, out SpielVariablen);

            if (!canParse)
                Console.WriteLine("Fehler, Falsche eingabe!");
            if (canParse)
            {
                zahl = rnd.Next(1, 6);
                string EInput = ((SpielVariablen)zahl).ToString();

                Console.WriteLine($"Deine eingabe: {Input}, Eingabe des gegners: {EInput}");

                bool PWin =
                    (Input == "stein" && (EInput == "schere" || EInput == "echse")) ||
                    (Input == "echse" && (EInput == "spock" || EInput == "papier")) ||
                    (Input == "spock" && (EInput == "schere" || EInput == "stein")) ||
                    (Input == "schere" && (EInput == "papier" || EInput == "echse")) ||
                    (Input == "papier" && (EInput == "stein" || EInput == "spock"));

                if (Input == EInput)
                    Console.WriteLine("Unentschieden");
                else if (PWin) 
                {
                    Ppoints++;
                }
                else
                {
                    Epoints++;
                }


                if (Epoints == 3)
                {
                    Console.WriteLine("Du hast verloren! + 1 Lose.");
                    return "1L";
                }
                else if (Ppoints == 3)
                {
                    Console.WriteLine("Du hast Gewonnen! + 1 Win.");
                    return "1W";
                }
            }
        }
    }
    enum Eingabe
    {
        none, 
        ja, 
        nein
    }
    enum SpielVariablen
    {
        none,
        schere,
        stein,
        papier,
        echse,
        spock
    }
}