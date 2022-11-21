using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPractice.Models;

namespace ProjectPractice.Repository
{
  public  interface IPostRepository
    {
         Task<List<Procuct>> GetProducts();
    }
}
