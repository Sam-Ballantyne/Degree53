using Degree53.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Degree53.Services
{
    public interface ITotalUpService
    {
        decimal TotalUp(List<Product> products);
    }
}
