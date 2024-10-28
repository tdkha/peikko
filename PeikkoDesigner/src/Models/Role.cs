using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeikkoDesigner;

public partial class Role
{
	[Key]
	[Column("id")]
	public int Id { get; set; }

	[Required, MaxLength(200)]
	[Column("title")]
	public string Title { get; set; } = "";

	[Column("description", TypeName = "text")]
	public string? Description { get; set; }

	public ICollection<User> Users { get; set; } = new List<User>();
}