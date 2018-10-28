using FakerDotNet.Data;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface IUniversityFaker
    {
        string Name();
        string Prefix();
        string Suffix();
        string GreekOrganisation();
        IEnumerable<string> GreekAlphabet();
    }

    internal class UniversityFaker : IUniversityFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public UniversityFaker(IFakerContainer fakerContainer)
        {
            this._fakerContainer = fakerContainer;
        }

        public string Name()
        {
            return Parse(_fakerContainer.Random.Element(UniversityData.Names));
        }

        public string Prefix()
        {
            return _fakerContainer.Random.Element(UniversityData.Prefixes);
        }

        public string Suffix()
        {
            return _fakerContainer.Random.Element(UniversityData.Suffixes);
        }

        public string GreekOrganisation()
        {
            return String.Join("", _fakerContainer.Random.Assortment(UniversityData.GreekAlphabet, 3));
        }

        public IEnumerable<string> GreekAlphabet()
        {
            return UniversityData.GreekAlphabet;
        }

        private string Parse(string format)
        {
            var text = Regex.Replace(format, @"\{(\w+)\}", @"{University.$1}");

            return _fakerContainer.Fake.F(text);
        }
    }
}
