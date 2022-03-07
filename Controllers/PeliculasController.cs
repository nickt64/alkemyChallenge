using AlkemyChallenge.Models.Data;
using AlkemyChallenge.Models.DTOs.PeliculaDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Controllers
{
    public class PeliculasController : ControllerBase
    {
        private readonly MyDbContext myDbContext;
        private readonly IMapper mapper;
        public PeliculasController(MyDbContext myDbContext, IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }


        //-----------------Listado de peliculas---------------------
        [HttpGet]
        [Route("/Movies")]
        public async Task<ActionResult<List<PeliculaListadoDTO>>> Get()
        {

            var peliculas = await myDbContext.Peliculas.ToListAsync();
            return mapper.Map<List<PeliculaListadoDTO>>(peliculas);
        }
    }
}
