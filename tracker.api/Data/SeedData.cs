// ********************************
// Test Data for insert within initial migration
// ********************************
using Microsoft.EntityFrameworkCore;

namespace tracker.api.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder) 
        {
            builder.Entity<JobApplicationEntity>().HasData(new List<JobApplicationEntity> {
                new() { 
                    Id = 1,
                    CompanyName = "Bulk Tea Importers",
                    Position = "Tea Lady",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 2, 12, 43, 44, 586, DateTimeKind.Local).AddTicks(2832)
                },
                new() {
                    Id = 2,
                    CompanyName = "Coca Cola NZ",
                    Position = "Taste Tester",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 2, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(6989)
                }
                ,
                new() {
                    Id = 3,
                    CompanyName = "Griffens Food Company",
                    Position = "Packaging Assistents Assistent",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 3, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7003)
                },
                new() {
                    Id = 4,
                    CompanyName = "Sausage Roles R Us",
                    Position = "Personal Assistant",
                    StatusId = 3,
                    AppliedDate = new DateTime(2025, 3, 6, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7007)
                },
                new() {
                    Id = 5,
                    CompanyName = "Sausage Roles R Us",
                    Position = "Sales Manager",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 6, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7008)
                },
                new() {
                    Id = 6,
                    CompanyName = "Aunt Megs",
                    Position = "Gossip",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 6, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7012)
                },
                new() {
                    Id = 7,
                    CompanyName = "Kings Water",
                    Position = "Plumber",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 7, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7014)
                },
                new() {
                    Id = 8,
                    CompanyName = "Ashphalts Under Us",
                    Position = "Heavy Machinery Operator",
                    StatusId = 2,
                    AppliedDate = new DateTime(2025, 3, 7, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7016)
                },
                new() {
                    Id = 9,
                    CompanyName = "Driver Ed",
                    Position = "Driving Instructor",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 8, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7018)
                },
                new() {
                    Id = 10,
                    CompanyName = "Customs",
                    Position = "Drugs Detection Dog",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 9, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7020)
                },
                new() {
                    Id = 11,
                    CompanyName = "Shipping NZ",
                    Position = "Captain First Class",
                    StatusId = 1,
                    AppliedDate = new DateTime(2025, 3, 10, 12, 43, 44, 587, DateTimeKind.Local).AddTicks(7022)
                }
            });
        }
    }
}
