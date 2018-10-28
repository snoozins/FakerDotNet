using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class UniversityFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _universityFaker = new UniversityFaker(_fakerContainer);

            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private IUniversityFaker _universityFaker;

        [Test]
        public void Name_returns_a_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.Names))
                .Returns("{Prefix} {Address.State} {Suffix}");
            A.CallTo(() => _fakerContainer.University.Prefix())
                .Returns("South");
            A.CallTo(() => _fakerContainer.Address.State())
                .Returns("Texas");
            A.CallTo(() => _fakerContainer.University.Suffix())
                .Returns("College");

            Assert.AreEqual("South Texas College", _universityFaker.Name());
        }

        [Test]
        public void Prefix_returns_a_prefix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.Prefixes))
                .Returns("North");

            Assert.AreEqual("North", _universityFaker.Prefix());
        }

        [Test]
        public void Suffix_returns_a_suffix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.Suffixes))
                .Returns("Institute");

            Assert.AreEqual("Institute", _universityFaker.Suffix());
        }

        [Test]
        public void GreekOrganisation_returns_a_greekorganisation()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(UniversityData.GreekAlphabet, 3))
               .Returns(new[] { "A", "B", "Γ" });

            Assert.AreEqual("ABΓ", _universityFaker.GreekOrganisation());
        }

        [Test]
        public void GreekAlphabet_returns_the_greekalphabet()
        {
            Assert.AreEqual(UniversityData.GreekAlphabet, _universityFaker.GreekAlphabet());
        }
    }
}
