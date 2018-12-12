using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AVGdotNet.Models;
using restserver.Paginator;
using Extensions;
using System.Net.Http;
using System.Text;
using System.Linq.Expressions;
using Newtonsoft.Json;


namespace AVGdotNet.Controllers
{
    namespace Client
{
    public class Filter
    {
        public int kind {get; set; }
        public string att { get; set; }
        public object value { get; set; }
        public Filter a1 { get; set; }
        public Filter a2 { get; set; }

    }

    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        private readonly AVGContext _context;

        public VideosController (AVGContext context)
        {
            _context = context;
        }
        // GET api/videos
        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return _context.Videos.ToList();
        }

        // GET api/videos/2
        [HttpGet("{id}")]
        public IActionResult Get (int id)
        {
            var video = _context.Videos.FirstOrDefault(t => t.ID == id);
            if (video == null)
            {
                return NotFound();
            }
            return new ObjectResult (video);
        }

        [HttpGet("GetVideosPaged/{page_index}/{page_size}")]
        public IActionResult GetAllVideos(int page_index, int page_size)
        {
            var res = _context.Videos.GetPage<Video>(page_index, page_size, v => v.ID);
            if(res == null) return NotFound();
            return Ok(res);
        }
        
        [HttpPost("GetVideos")]
        public IActionResult GetAllVideos([FromBody] Filter f_p)
        {
            if(f_p == null)
            {
                return NotFound();
            }

            Expression<Func<Video, bool>> e_p = FilterToExpr<Video>(f_p);
            return Ok(_context.Videos.Where(e_p).ToArray());
        }

        Expression<Func<T, bool>> FilterToExpr<T> (Filter f)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "p");
            return FilterToExpr_AUX<T>(f, parameter);
        }

        Expression<Func<T, bool>> FilterToExpr_AUX<T>(Filter f, ParameterExpression parameter)
        {
            switch(f.kind)
            {
                case 0:
                {
                    var propertyReference = Expression.Property(parameter, f.att);
                    var constantReference = Expression.Constant(f.value);
                    return Expression.Lambda<Func<T, bool>>(Expression.Equal(propertyReference, constantReference), parameter);
                }

                case 1:
                {
                    Expression<Func<T, bool>> expr1 = FilterToExpr_AUX<T>(f.a1, parameter);
                    Expression<Func<T, bool>> expr2 = FilterToExpr_AUX<T>(f.a2, parameter);

                    var body = Expression.And(expr1.Body, expr2.Body);

                    var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                    return lambda;
                }
                default: 
                return null;
            }
        }

        

        // POST api/videos
        [HttpPost]
        public void Post([FromBody]Video value)
        {
        }

        // PUT api/videos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Video value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
