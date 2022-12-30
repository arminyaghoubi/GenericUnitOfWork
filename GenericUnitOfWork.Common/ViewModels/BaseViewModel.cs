namespace GenericUnitOfWork.Common.ViewModels;

public abstract class BaseViewModel<TKey>
{
    public TKey Id { get; set; }
}
