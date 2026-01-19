// Namenliste in Array packen mit foreach durch array jedem eintrag random note zuweisen
class Program
{
    static void Main(string[] args)
    {
        string? eingabe;

        Console.WriteLine("Namen mit , getrennt eingeben:");
        eingabe = Console.ReadLine();
        eingabe!.ToLower();

        string[] Wörter = eingabe.Split(',');

        foreach(string w in Wörter)
        {
            Random r = new Random();
            int random = r.Next(0, 6);
            Console.WriteLine($"Der schüler {w} hat die Note {random} bekommen!");
        }
    }
}