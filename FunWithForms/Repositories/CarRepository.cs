using FunWithForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithForms.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AutoContext db) : base(db)
        { }
    }
}
