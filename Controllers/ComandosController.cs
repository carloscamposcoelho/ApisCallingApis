using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApisCallingApis.Models;
using ApisCallingApis.Util;
using System.Text.Json;
using ApisCallingApis.Data;
using ApisCallingApis.Dto;
using AutoMapper;

namespace ApisCallingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandosController : ControllerBase
    {
        private readonly IComandosRepo _repository;
        private readonly IMapper _mapper;

        public ComandosController(IComandosRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/comandos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comando>>> GetAll()
        {
            var comandos = await _repository.GetAllAsync();

            if (comandos == null)
            {
                return NotFound();
            }

            return Ok(comandos);
        }

        //GET api/commandos/{id}
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Comando>> GetById(int id)
        {
            var comando = await _repository.GetByIdAsync(id);

            if (comando == null)
            {
                return NotFound();
            }

            return Ok(comando);
        }

        //POST api/comandos
        [HttpPost]
        public async Task<ActionResult<Comando>> Create(Comando cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            var comandoCreated = await _repository.CreateAsync(cmd);

            return CreatedAtRoute(nameof(GetById), new { comandoCreated.Id }, comandoCreated);
        }

        //PUT api/comandos/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ComandoUpdateDto cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            var cmdRepo = await _repository.GetByIdAsync(id);

            _mapper.Map(cmd, cmdRepo);

            await _repository.UpdateAsync(cmdRepo);

            return NoContent();

        }
    }
}
