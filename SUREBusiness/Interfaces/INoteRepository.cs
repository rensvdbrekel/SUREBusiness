using System.Collections.Generic;
using System.Threading.Tasks;
using SUREBusiness.DTOs;
using SUREBusiness.Entities;

namespace SUREBusiness.Interfaces
{
	public interface INoteRepository
	{
		void AddNote(Note note);
		void DeleteNote(Note note);
		Task<Note> GetNote(int id);
		Task<IEnumerable<NoteDto>> GetNotes();

		Task<IEnumerable<NoteDto>> GetAllNotesForUser(int id);
		Task<bool> SaveAllAsync();

	}
}
