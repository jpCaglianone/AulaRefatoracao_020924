namespace AulaRefatoracao_020924
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie0 = new Movie("Filme 0", Movie.REGULAR);
            Movie movie1 = new Movie("Filme 1", Movie.NEW_RELEASE);
            Movie movie2 = new Movie("Filme 2", Movie.CHILDRENS);
            Rental rental0 = new Rental(movie0, 3);
            Rental rental1 = new Rental(movie1, 2);
            Rental rental2 = new Rental(movie2, 1);
            Customer cliente0 = new Customer("LP");
            cliente0.AddRental(rental0);
            cliente0.AddRental(rental1);
            cliente0.AddRental(rental2);

            string result = cliente0.Statement();
            Console.WriteLine(result);
        }
    }

}

