using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using TriantaWeb.API.CustomActionFilters;
using TriantaWeb.API.Models.Domain;
using TriantaWeb.API.Models.DTO;
using TriantaWeb.API.Repositories;

namespace TriantaWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        //Create Walk
        //POST /api/walks
        public WalksController(IMapper mapper , IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody]AddWalkRequestDto addWalkRequestDto)
        {
            //MAP DTO to Domail Model
            var walkDomaiModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomaiModel);

            return Ok(mapper.Map<WalkDto>(walkDomaiModel));
        }

        //GET /api/walks?filterOn=Name
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery ,
            [FromQuery] string? sortBy, [FromQuery] bool? IsAscending , [FromQuery] int pageNumber = 1 , [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, IsAscending ?? true ,pageNumber,pageSize);
            
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        //Get walk by id
        //Get /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepository.GetByIdAsync(id);

            if(walksDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walksDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);


            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel =  await walkRepository.DeleteAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
