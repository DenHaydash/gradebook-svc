﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GradeBook.DAL.Repositories.Abstractions;
using GradeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.DAL.Repositories
{
    public class TeachersRepository : BaseRepository<Teacher>, ITeachersRepository
    {
        public TeachersRepository(GradebookContext context) : base(context)
        {
        }

        public override async Task<Teacher> GetByIdAsync(int id)
        {
            return await Set
                .Include(t => t.Account)
                .FirstOrDefaultAsync(t => t.Id == id)
                .ConfigureAwait(false);
        }

        public override async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await Set
                .Include(t => t.Account)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        
        public override async Task<IEnumerable<Teacher>> GetAllAsync(Expression<Func<Teacher, bool>> predicate)
        {
            return await Set
                .Include(t => t.Account)
                .Where(predicate)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}