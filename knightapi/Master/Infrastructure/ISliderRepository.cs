using System;
using Master.Model;
using System.Collections.Generic;
using System.Text;

namespace Master.Infrastructure
{
    public interface ISliderRepository : IRepository<Slider>
    {
        void Delete(int id);
    }
}
