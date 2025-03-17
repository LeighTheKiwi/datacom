// ********************************
// Model for creating Job Applications.
//  Does not expose Id or AppliedDate as both are system generated.
//  AppliedDate is assumed to be a timestamp.
// ********************************
using System.ComponentModel.DataAnnotations;
public record JobApplicationCreateDto(
    [property: Required] string CompanyName,
    [property: Required] string Position,
    [property: Required] byte StatusId
);