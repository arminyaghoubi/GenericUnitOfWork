namespace GenericUnitOfWork.Common.ViewModels;

public class AuthorViewModel : BaseViewModel<short>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public int BookCount { get; set; }
}
