using System.Collections.Generic;

namespace SUREBusiness.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ICollection<Note> Notes { get; set; }
	}
}
