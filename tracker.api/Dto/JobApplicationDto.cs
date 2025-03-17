// ********************************
// Model for full JobApplication.
// ********************************
using System.ComponentModel.DataAnnotations;

public record JobApplicationDto(
    int Id,
    [property: Required] string CompanyName,
    [property: Required] string Position,
    [property: Required] byte StatusId,
    DateTime AppliedDate
);