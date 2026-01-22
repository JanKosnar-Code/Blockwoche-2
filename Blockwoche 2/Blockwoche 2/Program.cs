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

            if (Input == null)
                Console.WriteLine("Falsche eingabe! null wird nicht Aktzeptiert!");
            else
            {
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
    }

    static string Spiel(Eingabe en)
    {
        string? Input; // Player Input

        string EInput; // Enemy Input

        bool canParse;

        int zahl = 0;

        int Ppoints = 0; // Player Points
        int Epoints = 0; // Enempy Points

        int OPpoints = 0; // Original Player Points
        int OEpoints = 0; // Original Enemy Points

        do
        {
            Console.WriteLine($"Punkte zum Gewinnen: {Ppoints}/{Epoints}");
            Console.WriteLine("Schere, Stein, Papier, Echse, Spock?");
            Input = Console.ReadLine();

            if (Input == null)
                Console.WriteLine("Falsche eingabe! null wird nicht Aktzeptiert!");
            else
            {
                Input = Input!.ToLower();

                SpielVariablen SpielVariablen = SpielVariablen.none;
                canParse = Enum.TryParse(Input, out SpielVariablen);

                Random rnd = new Random(); // Delete Me

                if (!canParse)
                    Console.WriteLine("Fehler, Falsche eingabe!");
                if (canParse)
                {
                    //EInput = KI();
                    zahl = rnd.Next(1, 6); // Delete Me

                    EInput = ((SpielVariablen)zahl).ToString(); // Delete Me

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
                        Ppoints++;
                    else
                        Epoints++;

                    KIRechner(EInput, OEpoints, OPpoints, Epoints, Ppoints);

                    OPpoints = Ppoints;  
                    
                    OEpoints = Epoints;

                    if (Epoints == 3)
                    {
                        Console.WriteLine("Du hast verloren! + 1 Lose");
                        return "1L";
                    }
                    else if (Ppoints == 3)
                    {
                        Console.WriteLine("Du hast Gewonnen! + 1 Win");
                        return "1W";
                    }
                }
            }
        } while (true);
    }

    /*static string KI()
    {
        int zahl;
        int zahl2;
        int GrößteZahl;
        int KleinsteZahl;

        string trennzeichen = ", ";
        string Ei = "";

        Random rnd = new Random();

        string Pfad = "C:\\Users\\Student\\Blockwoche-2\\Informationen\\KIScore.txt";
        string Inhalt = File.ReadAllText(Pfad);
        string[] Count = Inhalt.Split(trennzeichen);

        int[] Counting = Array.ConvertAll(Count, int.Parse);

        GrößteZahl = Counting.Max();
        KleinsteZahl = Counting.Min();

        for (int i = 0; i <= GrößteZahl; i++)
        {
            zahl = rnd.Next(0, 5);

            if (Counting[zahl] == KleinsteZahl)
            {
                zahl2 = rnd.Next(1, 3);
                if (zahl2 == 2)
                {
                    Ei = ((SpielVariablen)Counting[zahl]).ToString();
                }
            }
            else if (Counting[zahl] == GrößteZahl)
            {
                Ei = ((SpielVariablen)Counting[zahl]).ToString();
                return (Ei);
            }
            else
            {
                Ei = ((SpielVariablen)Counting[zahl]).ToString();
            }
        }
        return Ei;
    }*/

    static void KIRechner(string Ei, int OEP, int OPP, int EP, int PP)
    {
        int schere;
        int stein;
        int papier;
        int echse;
        int spock;

        string trennzeichen = ", ";

        string Pfad = "C:\\Users\\Student\\Blockwoche-2\\Informationen\\KIScore.txt";
        string Inhalt = File.ReadAllText(Pfad);

        string NewCount;

        string[] Count = Inhalt.Split(trennzeichen);

        schere = Convert.ToInt32(Count[0]); stein = Convert.ToInt32(Count[1]); papier = Convert.ToInt32(Count[2]);
        echse = Convert.ToInt32(Count[3]); spock = Convert.ToInt32(Count[4]);

        if (EP > OEP) 
        {
            if (Ei == "schere")
                schere += 1;
            else if (Ei == "stein")
                stein += 1;
            else if (Ei == "papier")
                papier += 1;
            else if (Ei == "echse")
                echse += 1;
            else if (Ei == "spock")
                spock += 1;
        }
        else if (PP > OPP)
        {
            if (Ei == "schere")
                schere -= 1;
            else if (Ei == "stein")
                stein -= 1;
            else if (Ei == "papier")
                papier -= 1;
            else if (Ei == "echse")
                echse -= 1;
            else if (Ei == "spock")
                spock -= 1;
        }

        NewCount = $"{schere}, {stein}, {papier}, {echse}, {spock}";

        File.WriteAllText(Pfad, NewCount);
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