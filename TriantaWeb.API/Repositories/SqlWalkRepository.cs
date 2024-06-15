using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TriantaWeb.API.Data;
using TriantaWeb.API.Models.Domain;

namespace TriantaWeb.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly TriantaDbContext dbContext;

        public SqlWalkRepository(TriantaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool IsAscending = true ,int pageNumber = 1, int pageSize = 1000)
        {
            //return await dbContext.Walks
            //    .Include("Difficulty")
            //    .Include("Region").ToListAsync();

            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                //filtering
                if (filterOn.Equals("Name" , StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x=>x.Name.Contains(filterQuery));
                }
            

            }
            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = IsAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = IsAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //Pagination

            var skipResults = (pageNumber - 1) * pageSize;


            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> UpdateAsync(Guid id , Walk walk)
        {
            var existinWalk = await dbContext.Walks.FirstOrDefaultAsync(x=> x.Id == id);

            if (existinWalk == null)
            {
                return null;
            }

            existinWalk.Name = walk.Name;
            existinWalk.Description = walk.Description;
            existinWalk.LengthInKm = walk.LengthInKm;
            existinWalk.WalkImageUrl = walk.WalkImageUrl;
            existinWalk.DifficultyId = walk.DifficultyId;
            existinWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existinWalk;
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty")
                .Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();

            return existingWalk;
        }

        
    }
}
