using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SUREBusiness.Controllers;
using SUREBusiness.DTOs;
using SUREBusiness.Enums;
using SUREBusiness.Helpers;
using SUREBusiness.Interfaces;
using Xunit;


namespace SUREbusiness_Unit_Tests
{
	public class NotesTests
	{
		public Mock<INoteRepository> Mock = new Mock<INoteRepository>();
		
		[Fact]
		public async void Test_NotesRepository_GetNotes()
		{
			// 1. Arrange
			 Mock.Setup(repo => repo.GetNotes(new FilterParams()))
				.ReturnsAsync(GetTestNotes());
			 var noteController = new NotesController(Mock.Object, null, null);

			// 2. Act 
			var result = await noteController.GetNotes(new FilterParams());

			// 3. Assert
			Assert.NotNull(result);
			Assert.IsType<OkObjectResult>(result.Result);
		}

		private static IEnumerable<NoteDto> GetTestNotes()
		{
			var sessions = new List<NoteDto>
			{
				new NoteDto() {Id = 1, Name = "Test One", Status = NoteStatus.New},
				new NoteDto() {Id = 2, Name = "Test Two", Status = NoteStatus.InProgress}
			};
			return sessions;
		}
	}
}
