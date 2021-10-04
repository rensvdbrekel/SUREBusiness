using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUREBusiness.Data;
using SUREBusiness.Entities;

namespace SUREBusiness.Controllers
{
	public class UsersController : BaseApiController
	{
		private readonly DataContext _context;

		// add data context in ctor
		public UsersController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			return await _context.Users.ToListAsync();
		}
	}
}
