using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using SUREBusiness.DTOs;
using SUREBusiness.Entities;
using SUREBusiness.Enums;
using SUREBusiness.Interfaces;

namespace SUREBusiness.Controllers
{
	public class NotesController : BaseApiController
	{
		private readonly INoteRepository _noteRepository;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;


		public NotesController(INoteRepository noteRepository, IUserRepository userRepository, IMapper mapper)
		{
			_noteRepository = noteRepository;
			_userRepository = userRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<Note>> GetNotes()
		{
			var notes = await _noteRepository.GetNotes();
			return Ok(notes);
		}

		[HttpPost("add-note")]
		public async Task<ActionResult<Note>> CreateNote(NoteDto noteDto)
		{
			// check if user exists
			var user = await _userRepository.GetUserByIdAsync(noteDto.UserId);
			if (user == null) return NotFound("User not found");


			var note = _mapper.Map<Note>(noteDto);
			_noteRepository.AddNote(note);

			if (await _noteRepository.SaveAllAsync()) return NoContent();

			return BadRequest("Failed to create note");
		}


		[HttpPut("{id}/update-status/{status}")]
		public async Task<ActionResult<Note>> EditStatus(int id, NoteStatus status)
		{
			var note = await _noteRepository.GetNote(id);
			if (note == null) return NotFound("Note not found");
			if (note.Status == status) return BadRequest("Status needs to be different from current status");

			note.Status = status;
			if (await _noteRepository.SaveAllAsync()) return NoContent();

			return BadRequest("Failed to update status");
		}

		[HttpPut("{id}/update-user/{userId}")]
		public async Task<ActionResult<Note>> EditUser(int id, int userId)
		{
			var note = await _noteRepository.GetNote(id);
			if (note == null) return NotFound("Note not found");

			var user = await _userRepository.GetUserByIdAsync(userId);
			if (user == null) return NotFound("User not found");

			note.UserId = user.Id;
			if (await _noteRepository.SaveAllAsync()) return NoContent();

			return BadRequest("Failed to update user");
		}

	}

	

}
