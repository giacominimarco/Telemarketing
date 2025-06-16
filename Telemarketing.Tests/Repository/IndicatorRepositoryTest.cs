using Moq;
using Telemarketing.Data.Enums;
using Telemarketing.DTOs;
using Telemarketing.Repositories;

namespace Telemarketing.Tests.Repository
{
    public class IndicatorRepositoryTest
    {
        private readonly Mock<IIndicatorRepository> _indicatorRepositoryMock;

        public IndicatorRepositoryTest()
        {
            _indicatorRepositoryMock = new Mock<IIndicatorRepository>();
        }


        [Fact]
        public async Task UpdateCollect_ValidProperties_true()
        {
            // Arrange
            CollectUpdateDTO collectUpdate = new CollectUpdateDTO
            {
                Id = 1,
                Value = 15.00,
            };
            _indicatorRepositoryMock.Setup(repo => repo.UpdateCollect(It.IsAny<CollectUpdateDTO>()))
                .ReturnsAsync(true);
            // Act
            bool result = await _indicatorRepositoryMock.Object.UpdateCollect(collectUpdate);

            // Assert
            Assert.True(result, "UpdateCollect should return true for valid properties.");
            Assert.NotNull(collectUpdate);
            Assert.True(collectUpdate.Id > 0, "Collect ID must be greater than zero.");
            Assert.True(collectUpdate.Value > 0, "Collect value must be greater than zero.");
            Assert.IsType<double>(collectUpdate.Value);
        }

        [Fact]
        public async Task UpdateCollect_InvalidProperties_false()
        {
            // Arrange
            CollectUpdateDTO collectUpdate = new CollectUpdateDTO
            {
                Id = 0, // Invalid ID
                Value = -5.00, // Invalid value
            };
            _indicatorRepositoryMock.Setup(repo => repo.UpdateCollect(It.IsAny<CollectUpdateDTO>()))
                .ReturnsAsync(false);
            
            // Act
            bool result = await _indicatorRepositoryMock.Object.UpdateCollect(collectUpdate);
            // Assert
            Assert.False(result, "UpdateCollect should return false for invalid properties.");
            Assert.NotNull(collectUpdate);
            Assert.True(collectUpdate.Id <= 0, "Collect ID must be zero or negative for invalid case.");
            Assert.True(collectUpdate.Value <= 0, "Collect value must be zero or negative for invalid case.");
        }

        [Fact]
        public async Task CreateCollect_ValidProoerties_True()
        {
            IndicatorDTO indicatorDTO = new IndicatorDTO
            {
                Name = "Test Indicator",
                Description = "This is a test indicator",
                TypeCalc = TypeCalc.Media,
                Collects = new List<CollectDTO>
                {
                    new CollectDTO { Value = 10.00 },
                    new CollectDTO { Value = 20.00 }
                }
            };
            _indicatorRepositoryMock.Setup(repo => repo.Create(It.IsAny<IndicatorDTO>()))
                .ReturnsAsync(true);

            // Act
            bool result = await _indicatorRepositoryMock.Object.Create(indicatorDTO);
            
            Assert.True(result, "Create should return true for valid properties.");
            Assert.NotNull(indicatorDTO);
            Assert.False(string.IsNullOrEmpty(indicatorDTO.Name), "Indicator name must not be empty.");
            Assert.NotNull(indicatorDTO.Collects);
            Assert.True(indicatorDTO.Collects.Count > 0, "Indicator collects must not be empty.");
        }
    }
}
