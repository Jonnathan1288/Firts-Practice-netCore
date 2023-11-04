using Microsoft.AspNetCore.Mvc;
using practice_proyect.Model;
using practice_proyect.Repository.Generic;

namespace practice_proyect.Repository
{
    public interface IParentRepository: IGenericRepository<Parent, int>
    {
    }
}
