using System.ComponentModel.DataAnnotations;

namespace GenericUnitOfWork.Common.Models;

public class Publisher : BaseModel<short>
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(50, MinimumLength = 2)]
    public string Title { get; set; }
    public ICollection<Book> Books { get; set; }
}
