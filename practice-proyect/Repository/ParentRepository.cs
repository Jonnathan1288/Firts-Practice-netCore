using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice_proyect.Context;
using practice_proyect.Model;
using practice_proyect.Repository.Generic;

namespace practice_proyect.Repository
{
    public class ParentRepository : GenericRepository<Parent, int>, IParentRepository
    {
        private readonly FirstContext _context;
        public ParentRepository(FirstContext context) : base(context)
        {
            _context = context;
        }
    }
}
