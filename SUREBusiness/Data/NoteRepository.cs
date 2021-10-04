using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SUREBusiness.DTOs;
using SUREBusiness.Entities;
using SUREBusiness.Interfaces;

namespace SUREBusiness.Data
{
	public class NoteRepository : INoteRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public NoteRepository(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public void AddNote(Note note)
		{
			_context.Notes.Add(note);
		}

		public void DeleteNote(Note note)
		{
			_context.Notes.Remove(note);
		}

		public async Task<Note> GetNote(int id)
		{
			return await _context.Notes
				.Include(user => user.User)
				.SingleOrDefaultAsync(note => note.Id == id);
		}

		public async Task<IEnumerable<NoteDto>> GetNotes()
		{
			var query = _context.Notes.AsQueryable();
			var notes = query.ProjectTo<NoteDto>(_mapper.ConfigurationProvider).AsNoTracking();

			return await notes.ToListAsync();
		}

		public async Task<IEnumerable<NoteDto>> GetAllNotesForUser(int id)
		{
			var query = _context.Notes
				.Where(note => note.UserId == id)
				.AsQueryable();

			var notes = query.ProjectTo<NoteDto>(_mapper.ConfigurationProvider);

			return await notes.ToListAsync();
			
		}

		public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
