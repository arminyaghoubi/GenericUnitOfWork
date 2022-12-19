namespace GenericUnitOfWork.Common.Models;

public abstract class BaseModel<TKey>
{
    public TKey Id { get; set; }
}