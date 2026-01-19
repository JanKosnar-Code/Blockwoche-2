class Program
{
    static void Main(string[] args)
    {
        string? eingabe;

        Random r = new Random();

        Console.WriteLine("Namen mit  getrennt eingeben:");
        eingabe = Console.ReadLine();
        eingabe!.ToLower();

        string[] Wörter = eingabe.Split(' ');

        foreach(string w in Wörter)
        {
            int random = r.Next(1, 6);
            Console.WriteLine($"Der schüler {w} hat die Note {random} bekommen!");
        }
    }
}