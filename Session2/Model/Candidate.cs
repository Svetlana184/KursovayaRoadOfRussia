using System;
using System.Collections.Generic;

namespace Desktop.Model;

public partial class Candidate
{
    public int IdCandidate { get; set; }

    public string CandidateSurname { get; set; } = null!;

    public string CandidateName { get; set; } = null!;

    public string? CandidateSecondName { get; set; }

    public string AreaOfActivity { get; set; } = null!;

    public string DateOfReceipt { get; set; } = null!;

    public string? Rezume { get; set; }
}
