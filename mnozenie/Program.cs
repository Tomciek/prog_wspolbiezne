namespace mnozenie
{
    public class Program
    {

        public static int multiplication(int x, int y)
        {
            return x * y;
        }

        static void Main(string[] args)
        {
           
            Console.WriteLine("Program mnozy przez siebie dwie liczby calkowite wprowadzone przez uzytkownika");
            Console.WriteLine("Podaj liczbe:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj liczbe:");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("wynik tego mnozenia: " + multiplication(x, y));
        }
    }
}