using Xunit;
using BusinessLogic;

namespace BusinessLogicTest
{
    public class FitnessClubTest
    {
        [Fact]
        public void GroupTrainingsAreAvailable_ReturnsTrue()
        {
            var fitnessClub = new FitnessClub
            {
                ExtraServices = new Dictionary<string, List<bool>>
                {
                    { "TariffWithGroupTrainings", new List<bool> { true, false } }
                }
            };

            var result = fitnessClub.GroupTrainingsAreAvaliable("TariffWithGroupTrainings");

            Assert.True(result);
        }

        [Fact]
        public void GroupTrainingsAreAvailable_ReturnsFalse()
        {
            var fitnessClub = new FitnessClub
            {
                ExtraServices = new Dictionary<string, List<bool>>
                {
                    { "TariffWithoutGroupTrainings", new List<bool> { false, true } }
                }
            };

            var result = fitnessClub.GroupTrainingsAreAvaliable("TariffWithoutGroupTrainings");

            Assert.False(result);
        }

        [Fact]
        public void MassageIsAvailable_ReturnsTrue()
        {
            var fitnessClub = new FitnessClub
            {
                ExtraServices = new Dictionary<string, List<bool>>
                {
                    { "TariffWithMassage", new List<bool> { false, true } }
                }
            };

            var result = fitnessClub.MassageIsAvaliable("TariffWithMassage");

            Assert.True(result);
        }

        [Fact]
        public void MassageIsAvailable_ReturnsFalse()
        {
            var fitnessClub = new FitnessClub
            {
                ExtraServices = new Dictionary<string, List<bool>>
                {
                    { "TariffWithoutMassage", new List<bool> { true, false } }
                }
            };

            var result = fitnessClub.MassageIsAvaliable("TariffWithoutMassage");

            Assert.False(result);
        }
    }
}