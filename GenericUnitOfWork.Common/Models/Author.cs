using System.ComponentModel.DataAnnotations;

namespace GenericUnitOfWork.Common.Models;

public class Author : BaseModel<short>
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; }
    [Required(AllowEmptyStrings = false)]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    public ICollection<Book> Books { get; set; }
}