using System.Collections.Generic;
using System.Threading.Tasks;
using SUREBusiness.DTOs;
using SUREBusiness.Entities;
using SUREBusiness.Helpers;

namespace SUREBusiness.Interfaces
{
	public interface INoteRepository
	{
		void AddNote(Note note);
		void DeleteNote(Note note);
		Task<Note> GetNote(int id);
		Task<IEnumerable<NoteDto>> GetNotes(FilterParams filterParams);

		Task<IEnumerable<NoteDto>> GetAllNotesForUser(int id);
		Task<bool> SaveAllAsync();

	}
}
