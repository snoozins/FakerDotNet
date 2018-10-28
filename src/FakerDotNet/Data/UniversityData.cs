using System;
using System.Collections.Generic;
using System.Text;

namespace FakerDotNet.Data
{
    internal class UniversityData
    {
        public static readonly IEnumerable<string> Prefixes = new[]
        {
            "The",
            "Northern",
            "North",
            "Western",
            "West",
            "Southern",
            "Eastern",
            "East"
        };
        public static readonly IEnumerable<string> Suffixes = new[]
        {
            "University",
            "Insistute",
            "College",
            "Academy"
        };
        public static readonly IEnumerable<string> Names = new[]
        {
            "{Name.LastName} {Suffix}",
            "{Prefix} {Name.LastName} {Suffix}",
            "{Prefix} {Name.LastName}",
            "{Prefix} {Address.State} {Suffix}"
        };
        public static readonly IEnumerable<string> GreekAlphabet = new[]
        {
            "Α", "B", "Γ", "Δ", "E", "Z", "H", "Θ", "I", "K",
            "Λ", "M", "N", "Ξ", "O", "Π", "P", "Σ", "T", "Y", "Φ", "X", "Ψ", "Ω"
        };
    }
}
