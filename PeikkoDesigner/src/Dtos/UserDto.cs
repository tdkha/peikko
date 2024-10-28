public class UserDto
{
	public int Id { get; set; }

	public required string Username { get; set; }
	public List<string> Roles { get; set; } = new List<string>();
}