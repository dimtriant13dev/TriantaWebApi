﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TriantaWeb.API.CustomActionFilters;
using TriantaWeb.API.Data;
using TriantaWeb.API.Models.Domain;
using TriantaWeb.API.Models.DTO;
using TriantaWeb.API.Repositories;

namespace TriantaWeb.API.Controllers
{
    //https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly TriantaDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(TriantaDbContext dbContext , IRegionRepository regionRepository , IMapper mapper , ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        //Get all
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                throw new Exception("This is custom exception");

                var regionsDomain = await regionRepository.GetAllAsync();
                //var regionDto = new List<RegionDto>();
                ////Map Domain Models to DTO

                //foreach (var regionDomain in regionsDomain)
                //{
                //    regionDto.Add(new RegionDto()
                //    {
                //        Id = regionDomain.Id,
                //        Code = regionDomain.Code,
                //        Name = regionDomain.Name,
                //        RegionImageUrl = regionDomain.RegionImageUrl,
                //    });
                //}

                var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
                logger.LogInformation($@"Finished GetAllRegions request with data : {JsonSerializer.Serialize(regionsDomain)}");

                return Ok(regionsDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw ;
            }
            
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Get Data From Models
            //var region = await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);

            var regionDomainModel = await regionRepository.GetByIdAsync(id);
            if(regionDomainModel is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Conver Dto to Domain Model 

            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl
            //};
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
            //Use Domain Model to create Region

            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //await dbContext.Regions.AddAsync(regionDomainModel);
            //await dbContext.SaveChangesAsync();
            // Map Domail Model bact to Dto

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //var regionDomainModel  = await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id == id);

            //MAP DTO to DomainModel 

            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            //};
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writere,Reader")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto 
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);

        }
    }
}
