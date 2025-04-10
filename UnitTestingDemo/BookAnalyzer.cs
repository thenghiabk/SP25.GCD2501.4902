namespace UnitTestingDemo
{
    // BookAnalyzer.cs
    public class BookAnalyzer
    {
        public int CountBooks(string[] books)
        {
            int count = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
