// BookAnalyzerTests.cs
using NUnit.Framework;
using UnitTestingDemo;

[TestFixture] // Marks this as a test class
public class BookAnalyzerTests
{
    [Test] // Marks this as a test method
    public void CountBooks_WithTwoBooks_ReturnsTwo()
    {
        // Arrange: Set up test data
        string[] books = new string[3];
        books[0] = "Book1";
        books[1] = "Book2";
        books[2] = null; // One null entry
        BookAnalyzer analyzer = new BookAnalyzer();

        // Act: Call the method
        int result = analyzer.CountBooks(books);

        // Assert: Check the result
        Assert.That(result, Is.EqualTo(2)); // Expect 2 non-null books
    }

    [Test]
    public void CountBooks_WithEmptyArray_ReturnsZero()
    {
        // Arrange
        string[] books = new string[2]; // All null by default
        BookAnalyzer analyzer = new BookAnalyzer();

        // Act
        int result = analyzer.CountBooks(books);

        // Assert
        Assert.That(result, Is.EqualTo(0)); // Expect 0
    }
}
