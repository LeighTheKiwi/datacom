// ********************************
// Model for Updating a JobApplication
//  Does not expose AppliedDate as this is assumed to be a timestamp.
// ********************************
using System.ComponentModel.DataAnnotations;

public record JobApplicationUpdateDto(
    int Id,
    [property: Required] string CompanyName,
    [property: Required] string Position,
    [property: Required] byte StatusId
);