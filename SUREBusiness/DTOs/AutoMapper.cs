using AutoMapper;
using SUREBusiness.Entities;

namespace SUREBusiness.DTOs
{
	public class AutoMapper : Profile
	{
		public AutoMapper()
		{
			CreateMap<Note, NoteDto>();
			CreateMap<NoteDto, Note>();

			CreateMap<User, UserDto>();


		}

	}
}
