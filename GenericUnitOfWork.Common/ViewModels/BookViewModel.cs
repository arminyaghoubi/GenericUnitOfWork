namespace GenericUnitOfWork.Common.ViewModels;

public class BookViewModel:BaseViewModel<int>
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateTime PrintYear { get; set; }
    public int Pages { get; set; }
    public string ImagePath { get; set; }
    public short PublisherId { get; set; }
    public string PublisherTitle { get; set; }
    public short AuthorId { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
}