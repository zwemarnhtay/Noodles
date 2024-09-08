using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Models;

[Table("Tbl_BLog")]
public class BlogModel
{
  [Key]
  public int Id { get; set; }
  [Required]
  public string Title { get; set; }
  public string Content { get; set; }
  [Required]
  public string Author { get; set; }
}
