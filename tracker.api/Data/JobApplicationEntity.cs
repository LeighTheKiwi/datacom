// ********************************
// Class representation of the datastore table/entity
// ********************************
namespace tracker.api.Data
{
    public class JobApplicationEntity
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }

        public required string Position { get; set; }

        public required byte StatusId { get; set; }

        public DateTime AppliedDate { get; set; }
    }
}
