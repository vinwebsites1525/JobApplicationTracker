using Microsoft.EntityFrameworkCore;
using JobApplicationTrackerServer.Models;

namespace JobApplicationTrackerServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}