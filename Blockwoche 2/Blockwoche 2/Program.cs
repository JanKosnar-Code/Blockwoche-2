class Program
{
    static void Main(string[] args)
    {
        double Gewicht;
        double Größe;
        double BMIE;

        string? name;
        string? Geschlecht;

        Console.WriteLine("Hallo. Wie heißt du?");
        name = Console.ReadLine() ?? "Deafault Benutzer";
        Console.WriteLine($"Ah, {name}, Wieviel wiegst du?");
        Gewicht = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Wie Groß bist du?");
        Größe = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Dein Geschlecht?");
        Geschlecht = Console.ReadLine();

        Geschlecht!.ToLower();

        BMIE = Rechner(Gewicht, Größe);

        BMI(BMIE, Geschlecht);
    }
    static double Rechner(double Ge, double Gr)
    {
        double zwischen1;
        double ergebnis;

        zwischen1 = Gr * Gr;
        ergebnis = Ge / zwischen1;
        Math.Round(ergebnis, 2);

        // Console.WriteLine(ergebnis);
        // Console.WriteLine(zwischen1);

        return ergebnis;
    }

    static void BMI(double bmi, string Gs)
    {
        if (Gs == "mänlich" || Gs == "mann")
        {
            if (bmi < 18.5)
                Console.WriteLine("Du bist Untergewichtig");
            else if (bmi >= 18.5 && bmi < 24.9)
                Console.WriteLine("Du hast das Normalgewicht");
            else if (bmi >= 25 && bmi < 29.9)
                Console.WriteLine("Du bist Übergewichtig");
            else if (bmi >= 30 && bmi < 34.9)
                Console.WriteLine("Du hast Adipositas Grad I");
            else if (bmi >= 35 && bmi < 39.9)
                Console.WriteLine("Du hast Adipositas Grad II");
            else if (bmi > 40)
                Console.WriteLine("Du hast Adipositas Grad III");
        }
        else
        {
            if (bmi < 17.5)
                Console.WriteLine("Du bist Untergewichtig");
            else if (bmi >= 17.5 && bmi < 23.9)
                Console.WriteLine("Du hast das Normalgewicht");
            else if (bmi >= 24 && bmi < 28.9)
                Console.WriteLine("Du bist Übergewichtig");
            else if (bmi >= 29 && bmi < 33.9)
                Console.WriteLine("Du hast Adipositas Grad I");
            else if (bmi >= 34 && bmi < 38.9)
                Console.WriteLine("Du hast Adipositas Grad II");
            else if (bmi > 39)
                Console.WriteLine("Du hast Adipositas Grad III");
        }
    }
}