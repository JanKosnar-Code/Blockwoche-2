using System.IO;

class Program
{
    static void Main(string[] args) 
    {
        string message;
        string? PlayerInput;

        bool canParse;

        int loses = 0;
        int wins = 0;

        while (true)
        {
            Console.WriteLine("Spiel Starten?");
            PlayerInput = Console.ReadLine();

            if (PlayerInput == null)
                Console.WriteLine("Falsche eingabe! null wird nicht Aktzeptiert!");
            else
            {
                PlayerInput = PlayerInput!.ToLower();

                Eingabe Eingabe = Eingabe.none;
                canParse = Enum.TryParse(PlayerInput, out Eingabe);

                if (Eingabe == Eingabe.none)
                    Console.WriteLine("Falsche Eingabe!");
                else if (Eingabe == Eingabe.nein)
                {
                    Console.WriteLine("Danke für das Spielen!");
                    break;
                }
                else if (Eingabe == Eingabe.ja)
                {
                    Console.WriteLine($"Deine stats: {wins} wins, {loses} loses");
                    message = Spiel(Eingabe);
                    if (message == "1L")
                        loses++;
                    else if (message == "1W")
                        wins++;
                }
            }
        }
    }

    static string Spiel(Eingabe en) // Das main Game
    {
        string? PlayerInput;

        string EnemyInput;

        bool canParse;

        // int zahl = 0; // Delete Me

        int PlayerPoints = 0;
        int EnemyPoints = 0;

        int OriginalPlayerPoints = 0;
        int OriginalEnemyPoints = 0;

        do
        {
            Console.WriteLine($"Punkte zum Gewinnen: {PlayerPoints}/{EnemyPoints}");
            Console.WriteLine("Schere, Stein, Papier, Echse, Spock?");
            PlayerInput = Console.ReadLine();

            if (PlayerInput == null)
                Console.WriteLine("Falsche eingabe! null wird nicht Aktzeptiert!");
            else
            {
                PlayerInput = PlayerInput!.ToLower();

                SpielVariablen SpielVariablen = SpielVariablen.none;
                canParse = Enum.TryParse(PlayerInput, out SpielVariablen);

                //Random rnd = new Random(); // Delete Me

                if (!canParse)
                    Console.WriteLine("Fehler, Falsche eingabe!");
                if (canParse)
                {
                    EnemyInput = KI();
                    //zahl = rnd.Next(1, 6); // Delete Me

                    //EnemyInput = ((SpielVariablen)zahl).ToString(); // Delete Me

                    Console.WriteLine($"Deine eingabe: {PlayerInput}, Eingabe des gegners: {EnemyInput}");

                    bool PWin =
                        (PlayerInput == "stein" && (EnemyInput == "schere" || EnemyInput == "echse")) ||
                        (PlayerInput == "echse" && (EnemyInput == "spock" || EnemyInput == "papier")) ||
                        (PlayerInput == "spock" && (EnemyInput == "schere" || EnemyInput == "stein")) ||
                        (PlayerInput == "schere" && (EnemyInput == "papier" || EnemyInput == "echse")) ||
                        (PlayerInput == "papier" && (EnemyInput == "stein" || EnemyInput == "spock"));

                    if (PlayerInput == EnemyInput)
                        Console.WriteLine("Unentschieden");
                    else if (PWin)
                        PlayerPoints++;
                    else
                        EnemyPoints++;

                    KIRechner(EnemyInput, OriginalEnemyPoints, OriginalPlayerPoints, EnemyPoints, PlayerPoints);

                    OriginalPlayerPoints = PlayerPoints;

                    OriginalEnemyPoints = EnemyPoints;

                    if (EnemyPoints == 3)
                    {
                        Console.WriteLine("Du hast verloren! + 1 Lose");
                        return "1L";
                    }
                    else if (PlayerPoints == 3)
                    {
                        Console.WriteLine("Du hast Gewonnen! + 1 Win");
                        return "1W";
                    }
                }
            }
        } while (true);
    }

    static string KI() // Der Zweite teil der KI: Kümmert sich um die random berechnungen
    {
        int zahl;
        int zahl2;
        int GrößteZahl;
        int KleinsteZahl;

        string trennzeichen = ", ";
        string EnemyInput = "";

        Random rnd = new Random();

        string Pfad = "C:\\Users\\Student\\Blockwoche-2\\Informationen\\KIScore.txt";
        string Inhalt = File.ReadAllText(Pfad);
        string[] Count = Inhalt.Split(trennzeichen);

        int[] Counting = Array.ConvertAll(Count, int.Parse);

        GrößteZahl = Counting.Max();
        KleinsteZahl = Counting.Min();

        Console.WriteLine($"Größte Zahl: {GrößteZahl}, Kleinste Zahl: {KleinsteZahl}");

        for (int i = 0; i <= GrößteZahl; i++)
        {
            zahl = rnd.Next(1, 5);

            Console.WriteLine("Erste Random Zahl: " + zahl);

            if (Counting[zahl] == KleinsteZahl)
            {
                zahl2 = rnd.Next(1, 3);

                Console.WriteLine("Zweite Random Zahl: " + zahl2);

                if (zahl2 == 2)
                {
                    EnemyInput = ((SpielVariablen)zahl).ToString();
                }
            }
            else if (Counting[zahl] == GrößteZahl)
            {
                EnemyInput = ((SpielVariablen)zahl).ToString();
                return (EnemyInput);
            }
            EnemyInput = ((SpielVariablen)zahl).ToString();

            Console.WriteLine("Schleifen Wiederholungen: " + (i + 1));
        }
        Console.WriteLine("Gegner input: " + EnemyInput);

        return EnemyInput;
    }

    static void KIRechner(string EnemyInput, int OriginalEnemyPoints, int OriginalPlayerPoints, int EnemyPoints, int PlayerPoints) // Der erste Teil der KI: Verteilt die Belohnungen
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

        if (EnemyPoints > OriginalEnemyPoints) 
        {
            if (EnemyInput == "schere")
                schere += 1;
            else if (EnemyInput == "stein")
                stein += 1;
            else if (EnemyInput == "papier")
                papier += 1;
            else if (EnemyInput == "echse")
                echse += 1;
            else if (EnemyInput == "spock")
                spock += 1;
        }
        else if (PlayerPoints > OriginalPlayerPoints)
        {
            if (EnemyInput == "schere")
                schere -= 1;
            else if (EnemyInput == "stein")
                stein -= 1;
            else if (EnemyInput == "papier")
                papier -= 1;
            else if (EnemyInput == "echse")
                echse -= 1;
            else if (EnemyInput == "spock")
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