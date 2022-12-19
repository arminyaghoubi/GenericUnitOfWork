using System.ComponentModel.DataAnnotations;

namespace GenericUnitOfWork.Common.Models;

public class Book : BaseModel<int>
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100, MinimumLength = 2)]
    public string Title { get; set; }
    [Required(AllowEmptyStrings = false)]
    [StringLength(13)]
    public string ISBN { get; set; }
    [Required(AllowEmptyStrings = false)]
    public DateTime PrintYear { get; set; }
    [Required(AllowEmptyStrings = false)]
    public int Pages { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string ImagePath { get; set; }
    [Required(AllowEmptyStrings = false)]
    public short PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    [Required(AllowEmptyStrings = false)]
    public short AuthorId { get; set; }
    public Author Author { get; set; }
}
