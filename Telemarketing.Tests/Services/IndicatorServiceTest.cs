using Moq;
using Telemarketing.Data.Enums;
using Telemarketing.DTOs;
using Telemarketing.Repositories;

namespace Telemarketing.Tests.Services
{
    public class IndicatorServiceTest
    {
        private readonly Mock<IIndicatorRepository> _indicateRepositorieMock;

        public IndicatorServiceTest()
        {
            _indicateRepositorieMock = new Mock<IIndicatorRepository>();
        }

        [Fact]
        public void GetCollect_ValidReturn_ResultTrue()
        {
            // Arrange
            IndicatorDTO indicator = new IndicatorDTO
            {
                Id = 1,
                Name = "Test Indicator",
                TypeCalc = TypeCalc.Soma,
            };
            indicator.Collects = new List<CollectDTO>
            {
                new CollectDTO { Id = 1, Value = 10.00 },
                new CollectDTO { Id = 2, Value = 20.00 }
            };

            _indicateRepositorieMock.Setup(repo => repo.GetCalcByIndicatorId(indicator.Id))
                .ReturnsAsync(indicator);
            
            // Act
            indicator.Calculate();

            // Assert
            Assert.True(indicator.Id > 0);
            Assert.True(!string.IsNullOrWhiteSpace(indicator.Name));
            Assert.Equal(1, indicator.Id);
            Assert.NotNull(indicator.Collects);
            Assert.Equal(2, indicator.Collects.Count);
            Assert.Equal(30, indicator.CalcValue);
        }

        [Fact]
        public void CreateCalc_Media_ResultTrue()
        {
            // Arrange
            IndicatorDTO indicator = new IndicatorDTO
            {
                Name = "Test Indicator",
                Description = "This is a test indicator",
                TypeCalc = TypeCalc.Media,
                Collects = new List<CollectDTO> { 
                    new CollectDTO { Value = 10.00 },
                    new CollectDTO { Value = 20.00 },
                    new CollectDTO { Value = 30.00 }
                }
            };
            // Act
            indicator.Calculate();

            // Assert
            Assert.Equal(20.00, indicator.CalcValue);
        }

        [Fact]
        public void CreateCalc_Soma_ResultTrue()
        {
            // Arrange
            IndicatorDTO indicator = new IndicatorDTO
            {
                Name = "Test Indicator",
                Description = "This is a test indicator",
                TypeCalc = TypeCalc.Soma,
                Collects = new List<CollectDTO> {
                    new CollectDTO { Value = 10.00 },
                    new CollectDTO { Value = 20.00 },
                    new CollectDTO { Value = 30.00 }
                }
            };
            // Act
            indicator.Calculate();

            // Assert
            Assert.Equal(60.00, indicator.CalcValue);
        }
    }
}