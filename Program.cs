namespace EntityFramework02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var context = new EventHubContext();
            Console.WriteLine("EventHub - Database Connection Check");
            try
            {
                if (context.Database.CanConnect())
                    Console.WriteLine("Connected to EventHubDB successfully.");
                else
                    Console.WriteLine("Connection failed. Check SQL Server name and run Update-Database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
        }
    }
}
