using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SUREBusiness.Entities;
using SUREBusiness.Enums;

namespace SUREBusiness.Data
{
	public class Seed
	{
		public static async Task SeedUsers(DataContext context)
		{
			if (await context.Users.AnyAsync()) return;
			
			var seedData = Enumerable.Range(0, 10).Select(user => new User
			{
				FirstName = Faker.Name.First(),
				LastName = Faker.Name.Last(),
				Notes = Enumerable.Range(0, 10).Select(note => new Note
				{
						Name = string.Join(" ", Faker.Lorem.Words(6)),
						Content = string.Join(" ", Faker.Lorem.Sentences(2)),
						Status = NoteStatus.New,
						PhoneNumber = Faker.Phone.Number(),
				}).ToList()
			});

			foreach (var user in seedData)
			{
				context.Users.Add(user);
				
			}
			await context.SaveChangesAsync();
		}
	}
}