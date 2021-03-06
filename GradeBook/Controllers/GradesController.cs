﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GradeBook.Common.Security;
using GradeBook.DTO;
using GradeBook.Models;
using GradeBook.Services.Abstactions;
using GradeBook.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeBook.Controllers
{
    [Produces("application/json")]
    [Route("api/students/{studentId:int:min(1)}/courses/{courseId:int:min(1)}/grades")]
    public class GradesController : Controller
    {
        private readonly IStudentGradesService _studentGradesService;
        private readonly IMapper _mapper;

        public GradesController(IStudentGradesService studentGradesService, IMapper mapper)
        {
            _studentGradesService = studentGradesService;
            _mapper = mapper;
        }
        
        private int AccountId => int.Parse(User.Claims.First(c => c.Type == ClaimTypes.Sid).Value);
        
        /// <summary>
        /// Get student's grades for the subject
        /// </summary>
        [Authorize(Roles = Roles.Teacher+","+Roles.Admin)]
        [HttpGet]
        [ProducesResponseType(typeof(StudentSubjectGradesDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStudentGradesAsync(int studentId, int courseId)
        {
            var studentSubjectGrades = await _studentGradesService.GetStudentSubjectCurrentGradesAsync(studentId, courseId);

            return Ok(studentSubjectGrades);
        }
        
        /// <summary>
        /// Create student's grade for the subject
        /// </summary>
        [Authorize(Roles = Roles.Teacher)]
        [HttpPut]
        [ProducesResponseType(typeof(GradeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStudentGradeAsync(int studentId, int courseId, [FromBody]GradeViewModel grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationError(ModelState));
            }
            
            var newGrade = await _studentGradesService.AddStudentCourseGradeAsync(_mapper.Map<GradeDto>(grade), studentId, AccountId, courseId);

            return Created(String.Empty, newGrade);
        }
        
        /// <summary>
        /// Delete student's grade
        /// </summary>
        [Authorize(Roles = Roles.Teacher)]
        [HttpDelete("{gradeId:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteStudentGradeAsync(int gradeId)
        {            
            await _studentGradesService.RemoveStudentCourseGradeAsync(gradeId, AccountId);

            return NoContent();
        }
        
        /// <summary>
        /// Get student's final grade for the subject
        /// </summary>
        [Authorize(Roles = Roles.Teacher+","+Roles.Admin)]
        [HttpGet("final")]
        [ProducesResponseType(typeof(FinalGradeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentFinalGradeAsync(int studentId, int courseId)
        {
            var grade = await _studentGradesService.GetStudentSubjectFinalGradeAsync(studentId, courseId);

            if (grade == null)
            {
                return NotFound();
            }
            
            return Ok(grade);
        }
        
        /// <summary>
        /// Create student's final grade for the subject
        /// </summary>
        [Authorize(Roles = Roles.Teacher)]
        [HttpPut("final")]
        [ProducesResponseType(typeof(FinalGradeDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> ConfirmStudentFinalGradeAsync(int studentId, int courseId)
        {
            var finalGrade = await _studentGradesService.ConfirmStudentCourseFinalGradeAsync(studentId, AccountId, courseId);
            
            return Created(String.Empty, finalGrade);
        }
    }
}