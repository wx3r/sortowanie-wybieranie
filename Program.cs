using System.Reflection.Emit;

class Program
{
    const int iloscE = 80;
    const int maxE = 999;

    static void Sortuj(uint[] z1, uint[] z2, uint m)
    {
        uint[] L = new uint[2];
        L[0] = L[1] = 0;

        for (int i = 1; i <= iloscE; i++)
        {
            L[(z1[i] & m) > 0 ? 1 : 0]++;
        }

        L[1] += L[0];

        for (int i = iloscE; i >= 1; i--)
        {
            z2[L[(z1[i] & m) > 0 ? 1 : 0]--] = z1[i];
        }
    }
    static void Main()
    {
        uint[] d = new uint[iloscE + 1];
        uint[] b = new uint[iloscE + 1];
        uint m;

        Console.WriteLine("  Sortowanie pozycyjne  \n" +
                          "------------------------\n" +
                          " (C)2005 Jerzy Walaszek \n\n" +
                          "Przed sortowaniem:");

        Random rand = new Random();
        for (int i = 1; i <= iloscE; i++)
        {
            d[i] = (uint)rand.Next(0, maxE + 1);
            Console.Write($"{d[i],4}");
        }

        m = 1;

        while (m <= maxE)
        {
            Sortuj(d, b, m);
            m <<= 1;
            Sortuj(b, d, m);
            m <<= 1;
        }

        Console.WriteLine("\nPo sortowaniu:");
        for (int i = 1; i <= iloscE; i++)
        {
            Console.Write($"{d[i],4}");
        }
        Console.WriteLine();
    }
}
