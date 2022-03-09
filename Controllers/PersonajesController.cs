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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace AlkemyChallenge.Controllers
{

    [ApiController]
    [Route("api/Personajes")]
    public class PersonajesController : ControllerBase

    {
        //para cargar imagenes
        private readonly IWebHostEnvironment webHostEnvironment;
       
        
        private readonly MyDbContext myDbContext;
        private readonly IMapper mapper;
        public PersonajesController(MyDbContext myDbContext, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
            this.webHostEnvironment  = webHostEnvironment;
        }

        //------------listado de personajes------------------
        [HttpGet]
        [Route("characters")]
        //devolver solo campo imagen y nombre con personajeDetalleDTO
        public async Task<ActionResult<List<PersonajeListadoDTO>>> Get()
        {

            var personajes = await myDbContext.Personajes.ToListAsync();
            return mapper.Map<List<PersonajeListadoDTO>>(personajes);
        }
        
        [HttpGet("DetalleCompletoId",Name ="GetPersId")]
        public async Task<ActionResult<PersonajeDTO>> Get(int id)
        {
            var personaje = await myDbContext.Personajes.FirstOrDefaultAsync(p => p.PersonajeId == id);

            if (personaje == null)
            { return NotFound(); }

            return mapper.Map<PersonajeDTO>(personaje);
        }   




        //busscar personaje con filtros
        [HttpGet("BuscarPersonajes")]
        public async Task<ActionResult<List<PersonajeDTO>>> BuscarPersonajes([FromQuery] [Required] string nombre, int? edad, int? peso)
        {
            var query = myDbContext.Personajes.Where(x => x.Nombre.Contains(nombre));

            if (edad != null) // .HasValue son lo mismo
            {
                query = query.Where(x => x.Edad == edad.Value);
            }

            if (peso.HasValue)
            {
                query = query.Where(x => x.Peso == peso.Value);
            }

            var personajes = await query.ToListAsync();

            if (personajes.Count == 0) // !personajes.Any()
            {
                return NotFound();
            }

            var result = new List<PersonajeDTO>();

            foreach (var personaje in personajes)
            {
                var personajeDto = mapper.Map<PersonajeDTO>(personaje);

                if (personaje.Imagen != null)
                {
                    var bytes = System.IO.File.ReadAllBytes(personaje.Imagen);
                    personajeDto.ImagenBase64 = Convert.ToBase64String(bytes);
                }

                result.Add(personajeDto);
            }

            return result;
        }

        
        //---------CREACION DE PERSONAJES-------------
        [HttpPost("CrearPersonaje")]
        public async Task<ActionResult<PersonajeDTO>> CrearPersonaje([FromForm] PersonajeCreacionDTO personajeCreacionDTO)
        {
            var validExtensions = new[] { ".jpg", ".png" };

            if (!validExtensions.Contains(System.IO.Path.GetExtension(personajeCreacionDTO.Imagen.FileName).ToLower()))
            {
                return BadRequest(new { Message = "Extension no valida" });
            }


            var rutaCarpeta = Path.Combine(webHostEnvironment.WebRootPath, "imagenes");
            var nombreIdArchivo = Guid.NewGuid().ToString() + "_" + personajeCreacionDTO.Imagen.FileName;
            var rutaArchivo = Path.Combine(rutaCarpeta, nombreIdArchivo);

            using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
            {
                personajeCreacionDTO.Imagen.CopyTo(fileStream);
            }
            
            var personaje = mapper.Map<Personaje>(personajeCreacionDTO);

            personaje.Imagen = rutaArchivo;

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
