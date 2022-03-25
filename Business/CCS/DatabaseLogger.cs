namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("vritabanına loglandı");
        }
    }
}
