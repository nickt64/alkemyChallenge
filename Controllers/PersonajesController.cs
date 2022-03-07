using AlkemyChallenge.Models;
using AlkemyChallenge.Models.Data;
using AlkemyChallenge.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Controllers
{

    [ApiController]
    [Route("api/Personajes")]
    public class PersonajesController : ControllerBase
    {
        private readonly MyDbContext myDbContext;
        private readonly IMapper mapper;
        public PersonajesController(MyDbContext myDbContext, IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        //------------listado de personajes------------------
        [HttpGet]
        [Route("/characters")]
        //devolver solo campo imagen y nombre con personajeDetalleDTO
        public async Task<ActionResult<List<PersonajeListadoDTO>>> Get()
        {

            var personajes = await myDbContext.Personajes.ToListAsync();
            return mapper.Map<List<PersonajeListadoDTO>>(personajes);
        }
        
        [HttpGet("GetPersId")]
        public async Task<ActionResult<PersonajeDTO>> Get(int id)
        {
            var personaje = await myDbContext.Personajes.FirstOrDefaultAsync(p => p.PersonajeId == id);

            if (personaje == null)
            { return NotFound(); }

            return mapper.Map<PersonajeDTO>(personaje);
        }   




        //busscar personaje con filtros
        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<PersonajeDTO>>> Get(string nombre, [FromQuery] int edad, int peso)
        {
            var personajes = await myDbContext.Personajes.ToListAsync();
            
            List<Personaje> pers = new();
            foreach (var p in personajes)
            {

                if ((edad == 0 && peso == 0) && p.Nombre.Contains(nombre))
                {
                    pers.Add(p);
                }
                else 
                if ((edad == 0 && peso != 0) && (p.Peso == peso && p.Nombre.Contains(nombre)))
                {
                    pers.Add(p);
                }
                  else 
                if ((edad!=0 && peso == 0)&&(p.Edad==edad && p.Nombre.Contains(nombre))){
                    pers.Add(p);
                }
                else 
                if ((edad!=0 && peso != 0 ) && (p.Edad==edad && p.Peso==peso && p.Nombre.Contains(nombre))){
                    pers.Add(p);
                }else { return NotFound(); }
            }
         
            if (pers == null)
            {
                return NotFound();
            }
            return mapper.Map<List<PersonajeDTO>>(pers);
        }

        


        //---------CREACION DE PERSONAJES-------------
        [HttpPost]
        public async Task<ActionResult<PersonajeDTO>> post([FromBody]PersonajeCreacionDTO personajeCreacionDTO)
        {
            var personaje = mapper.Map<Personaje>(personajeCreacionDTO);
            myDbContext.Add(personaje);

            await myDbContext.SaveChangesAsync();
            var dto = mapper.Map<PersonajeDTO>(personaje);

            return new CreatedAtRouteResult("GetPersId", new {id = personaje.PersonajeId }, dto);
        }

        //------------------EDICION ----------------------------

        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id, PersonajeCreacionDTO personajeCreacionDTO)
        {
            var personaje = await myDbContext.Personajes.FirstOrDefaultAsync(p => p.PersonajeId == id);

            if(personaje == null)
            {
                return NotFound();
            }

            mapper.Map(personajeCreacionDTO, personaje);

            myDbContext.Entry(personaje).State = EntityState.Modified;

            await myDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var personaje = await myDbContext.Personajes.FirstOrDefaultAsync(p => p.PersonajeId == id);

            if(personaje == null)
            {
                return NotFound();
            }
            myDbContext.Entry(personaje).State = EntityState.Deleted;

            await myDbContext.SaveChangesAsync();

            return NoContent();

        }



    }
}
