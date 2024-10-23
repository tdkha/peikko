using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeikkoDesigner;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(255)]
    public string Username { get; set; } = null!;

    [Required, MaxLength(255)]
    public string Password { get; set; } = null!;

    [Required]
    [Column("created_at")]
    public DateOnly CreatedAt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateOnly UpdatedAt { get; set; }

    [Required, MaxLength(50)]
    [DefaultValue("active")]
    public string State { get; set; } = null!;

    public ICollection<Role> Roles { get; set; } = new List<Role>();
}
