using System.Threading.Tasks;
using SUREBusiness.Entities;
using SUREBusiness.Interfaces;

namespace SUREBusiness.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;

		public UserRepository(DataContext context)
		{
			_context = context;
		}
		public async Task<User> GetUserByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}
	}
}
