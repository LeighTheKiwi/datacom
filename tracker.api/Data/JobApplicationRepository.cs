// ********************************
// Job Application implementations for interacting with the datastore.
// ********************************
using Microsoft.EntityFrameworkCore;

namespace tracker.api.Data
{
    // For readability I will keep the interface definition with the class. Usually I would have this as its own
    // file in an interfaces directory
    public interface IJobApplicationRepository {
        Task<List<JobApplicationDto>> GetAll();
        Task<JobApplicationDto?> Get(int id);
        Task<JobApplicationDto> Create(JobApplicationCreateDto jobApplication);
        Task<JobApplicationDto> Update(JobApplicationUpdateDto jobApplication);
    }

    public class JobApplicationRepository : IJobApplicationRepository
    {

        private readonly JobApplicationDbContext _context;

        public JobApplicationRepository(JobApplicationDbContext context)
        {
            this._context = context;
        }

        private static JobApplicationDto EntityToDto(JobApplicationEntity e)
        {
            return new JobApplicationDto(e.Id, e.CompanyName, e.Position, e.StatusId, e.AppliedDate);
        }

        public async Task<JobApplicationDto?> Get(int id)
        {
            var entity = await _context.JobApplications.SingleOrDefaultAsync(a => a.Id == id);
            return entity == null ? null : EntityToDto(entity);
        }

        public async Task<List<JobApplicationDto>> GetAll()
        {
            return await _context.JobApplications.Select(e => 
                new JobApplicationDto(
                    e.Id, 
                    e.CompanyName, 
                    e.Position, 
                    e.StatusId, 
                    e.AppliedDate
                )).ToListAsync();
        }

        public async Task<JobApplicationDto> Create(JobApplicationCreateDto jobApplication)
        {
            var entity = new JobApplicationEntity()
            {
                CompanyName = jobApplication.CompanyName,
                Position = jobApplication.Position,
                StatusId = jobApplication.StatusId,
                AppliedDate = DateTime.Now      // Treat the AppliedDate as a timestamp.
            };

            _context.JobApplications.Add(entity);
            await _context.SaveChangesAsync();

            return EntityToDto(entity);
        }

        public async Task<JobApplicationDto> Update(JobApplicationUpdateDto jobApplication)
        {
            var entity = await _context.JobApplications.FindAsync(jobApplication.Id);
            if (entity == null)
                throw new ArgumentException($"Update Job Application: entity with Id {jobApplication.Id} not found.");

            entity.CompanyName = jobApplication.CompanyName;
            entity.Position = jobApplication.Position;
            entity.StatusId = jobApplication.StatusId;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return EntityToDto(entity);
        }
    }
}
