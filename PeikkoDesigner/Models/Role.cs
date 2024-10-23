using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeikkoDesigner;

public partial class Role
{
    [Key]
    public int Id { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}
