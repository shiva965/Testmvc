using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPractice.Models;
using ProjectPractice.Repository;

namespace ProjectPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        IPostRepository postRepository;
        public OrderDetailsController(IPostRepository _postRepository) 
        {
            postRepository = _postRepository;
        }
       //public async Task<List<IActionResult>>GetProcucts()
       // {
       //     try
       //     {
       //       //  return await postRepository.GetProducts();
               

       //     }
       //     catch(Exception ex)
       //     {
       //         throw ex;
       //     }
       // }
    }
}
