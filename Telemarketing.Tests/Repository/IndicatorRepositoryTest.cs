using Telemarketing.DTOs;

namespace Telemarketing.Tests.Repository
{
    public class IndicatorRepositoryTest
    {
        [Fact]
        public void UpdateCollect_ValidProperties_true()
        {
            // Arrange
            CollectUpdateDTO collectUpdate = new CollectUpdateDTO
            {
                Id = 1,
                Value = 15.00,
            };
            // Act

            // Assert
            Assert.NotNull(collectUpdate);
            Assert.True(collectUpdate.Id > 0, "Collect ID must be greater than zero.");
            Assert.True(collectUpdate.Value > 0, "Collect value must be greater than zero.");
            Assert.IsType<double>(collectUpdate.Value);
        }
    }
}
