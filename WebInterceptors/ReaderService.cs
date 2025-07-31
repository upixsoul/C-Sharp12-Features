namespace WebInterceptors
{
    public interface IReaderService
    {
        string ReadData(string query);
    }

    public class ReaderService : IReaderService
    {
        public string ReadData(string query)
        {
            return $"Processed: {query}";
        }
    }
}
