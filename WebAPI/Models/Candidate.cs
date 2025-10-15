using System;
using System.Collections.Generic;
namespace WebAPI.Models;

public partial class Candidate
{
    public int IdCandidate { get; set; }

    public string CandidateSurname { get; set; } = null!;

    public string CandidateName { get; set; } = null!;

    public string? CandidateSecondName { get; set; }

    public string AreaOfActivity { get; set; } = null!;

    public DateOnly DateOfReceipt { get; set; }

    public string? Rezume { get; set; }
}
