using System.Threading.Tasks;
using SUREBusiness.Entities;

namespace SUREBusiness.Interfaces
{
	public interface IUserRepository
	{
		public Task<User> GetUserByIdAsync(int id);
	}
}
