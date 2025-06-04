// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

using System.Text.Json.Serialization;

namespace efCourse.Models;

// [Table("Categories")]
public class Category
{
    // [Key]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(50)]
    public string Name { get; set; }

    public string Description { get; set; }

    public int WorkLoad { get; set; }

    // relationship
    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; }

}