namespace GenericUnitOfWork.Common.ViewModels;

public class PublisherViewModel : BaseViewModel<short>
{
    public string Title { get; set; }
    public int BookCount { get; set; }
}