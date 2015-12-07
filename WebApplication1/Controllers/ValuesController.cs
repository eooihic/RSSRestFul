using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly IItemRepository _repo = new UrlRepository();
        // GET /api/values
        [HttpGet]
        [Route("")]
        [Route("api/news")]
        [Route("api/values")]
        public IEnumerable<Item> Get()
        {
            return _repo.GetAll();
        }
    }
}
