using FunWithForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithForms
{
    public interface ICarRepository
    {
        void Create(Car car);
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Delete(int id);
    }
}
