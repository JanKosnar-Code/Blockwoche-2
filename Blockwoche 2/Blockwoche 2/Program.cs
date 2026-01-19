 /* Iterativ Variante 1
class Program
{
    static void Main(string[] args)
    {
        int ergebnis;
        int zwischen;

        int a = 0;
        int b = 1;

        for (int i = 0; i < 11; i++)
        {
            if (i == 0)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
                i += 2;
            }

            ergebnis = a + b;
            zwischen = a;
            a = b;
            b = ergebnis;
            Console.WriteLine(b);
        }
    }
}
*/
/* Iterativ Variante 2
class Program
{
    static void Main(string[] args)
    {
        int ergebnis;
        int zwischen;

        int a = 0;
        int b = 0;

        for (int i = 0; i < 11; i++)
        {
            if (a == 0)
            {
                Console.WriteLine(a);
                i++;
            }


            if (b == 0)
            {
                b += 1;
                Console.WriteLine(b);
                i++;
            }

            ergebnis = a + b;
            zwischen = a;
            a = b;
            b = ergebnis;
            Console.WriteLine(b);
        }
    }
}
*/
/* Rekursiv */
class Program
{
    static void Main(string[] args)
    {
        int a = 0;
        int b = 1;
        int c = 0;
        int l = 11;

        Rekursion(a, b, l);
    }

    static void Rekursion(int zahl1, int zahl2, int depth)
    {
        if (depth == 0) 
            return;

        Console.WriteLine(zahl1);
        Rekursion(zahl2, zahl1 + zahl2, depth - 1);
    }
}