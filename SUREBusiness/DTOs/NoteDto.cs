using SUREBusiness.Enums;

namespace SUREBusiness.DTOs
{
	public class NoteDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
		public string PhoneNumber { get; set; }
		public NoteStatus Status { get; set; }
		public int UserId { get; set; }
	}
}
