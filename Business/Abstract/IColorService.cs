using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int id);
        void Insert(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
