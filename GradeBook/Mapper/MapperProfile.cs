﻿using System.Linq;
using AutoMapper;
using GradeBook.DTO;
using GradeBook.Models;

namespace GradeBook.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SubjectViewModel, SubjectDto>();
            CreateMap<AccountViewModel, TeacherDto>();
            CreateMap<AccountViewModel, StudentDto>();
            CreateMap<NewAccountViewModel, TeacherDto>();
            CreateMap<SpecialtyViewModel, SpecialtyDto>();
            CreateMap<GroupViewModel, GroupDto>()
                .ForPath(m => m.Speciality.Id, t => t.MapFrom(s => s.SpecialityId));
            CreateMap<NewGroupViewModel, GroupDto>()
                .ForPath(m => m.Speciality.Id, t => t.MapFrom(s => s.SpecialityId));
            CreateMap<NewStudentViewModel, StudentDto>()
                .ForPath(m => m.Group.Id, t => t.MapFrom(s => s.GroupId));
            CreateMap<SemesterSubjectViewModel, SemesterSubjectDto>()
                .ForPath(m => m.AssessmentType.Id, t => t.MapFrom(s => s.AssessmentTypeId))
                .ForPath(m => m.Subject.Id, t => t.MapFrom(s => s.SubjectId));
            CreateMap<GradeViewModel, GradeDto>()
                .ForPath(m => m.GradebookRefId, t => t.Ignore())
                .ForPath(m => m.Id, t => t.Ignore())
                .ForPath(m => m.Teacher, t => t.Ignore());
            
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Specialty, SpecialtyDto>().ReverseMap();
            CreateMap<SemesterSubject, SemesterSubjectDto>()
                .ForMember(m => m.AssessmentType, t => t.MapFrom(s => s.AssestmentType))
                .ForMember(m => m.Teachers,
                    t => t.MapFrom(s =>
                        s.Gradebook.GradebookTeachers.Select(i => i.Teacher)));
            CreateMap<Account, AccountDto>()
                .ForMember(m => m.Email, t => t.MapFrom(s => s.Login));
            CreateMap<Teacher, TeacherDto>()
                .ForMember(m => m.Role, t => t.MapFrom(s => s.Account.Role))
                .ForMember(m => m.Email, t => t.MapFrom(s => s.Account.Login))
                .ForMember(m => m.FirstName, t => t.MapFrom(s => s.Account.FirstName))
                .ForMember(m => m.LastName, t => t.MapFrom(s => s.Account.LastName))
                .ForMember(m => m.MiddleName, t => t.MapFrom(s => s.Account.MiddleName));
            CreateMap<Group, GroupDto>();
            CreateMap<AssestmentType, AssessmentTypeDto>().ReverseMap();
            CreateMap<Semester, SemesterDto>()
                .ForMember(m => m.GroupId, t => t.MapFrom(s => s.GroupRefId));
            CreateMap<Student, StudentDto>()
                .ForMember(m => m.Role, t => t.MapFrom(s => s.Account.Role))
                .ForMember(m => m.Email, t => t.MapFrom(s => s.Account.Login))
                .ForMember(m => m.FirstName, t => t.MapFrom(s => s.Account.FirstName))
                .ForMember(m => m.LastName, t => t.MapFrom(s => s.Account.LastName))
                .ForMember(m => m.MiddleName, t => t.MapFrom(s => s.Account.MiddleName));
            CreateMap<Grade, GradeDto>();
            CreateMap<FinalGrade, FinalGradeDto>()
                .ForMember(m => m.Semester, t => t.MapFrom(s => s.Gradebook.Semester))
                .ForMember(m => m.Subject, t => t.MapFrom(s => s.Gradebook.Subject))
                .ForMember(m => m.AssessmentType, t => t.MapFrom(s => s.Gradebook.SemesterSubject.AssestmentType));
            CreateMap<Gradebook, GradebookDto>()
                .ForMember(m => m.AssessmentType, t => t.MapFrom(s => s.SemesterSubject.AssestmentType))
                .ForMember(m => m.Teachers, t => t.MapFrom(s => s.GradebookTeachers.Select(r => r.Teacher)));
            
            CreateMap<SemesterDto, Semester>()
                .ForPath(m => m.GroupRefId, t => t.MapFrom(s => s.GroupId))
                .ForMember(m => m.Group, t => t.Ignore());
            CreateMap<SemesterSubjectDto, SemesterSubject>()
                .ForMember(m => m.AssestmentTypeRefId, t => t.MapFrom(s => s.AssessmentType.Id))
                .ForMember(m => m.SubjectRefId, t => t.MapFrom(s => s.Subject.Id))
                .ForMember(m => m.Semester, t => t.Ignore())
                .ForMember(m => m.AssestmentType, t => t.Ignore())
                .ForMember(m => m.Subject, t => t.Ignore());
            CreateMap<GroupDto, Group>()
                .ForMember(m => m.SpecialityRefId, t => t.MapFrom(s => s.Speciality.Id))
                .ForMember(m => m.Speciality, t => t.Ignore());
            CreateMap<AccountDto, Account>()
                .ForMember(m => m.Login, t => t.MapFrom(s => s.Email));
            CreateMap<GradebookDto, Gradebook>()
                .ForMember(m => m.SemesterRefId, t => t.MapFrom(s => s.SemesterId))
                .ForMember(m => m.SubjectRefId, t => t.MapFrom(s => s.SubjectId));
        }
    }
}