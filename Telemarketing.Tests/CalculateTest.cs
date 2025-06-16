using Telemarketing.Data.Enums;
using Telemarketing.DTOs;

namespace Telemarketing.Tests
{
    public class CalculateTest
    {
        [Fact]
        public void Calculeted_TypeSum_True()
        {
            // Arrange
            IndicatorDTO indicator = new IndicatorDTO
            {
                Id = 1,
                Description = "Test Indicator",
                TypeCalc = TypeCalc.Soma,
                Collects = new List<CollectDTO>
                {
                    new CollectDTO { Value = 2 },
                    new CollectDTO { Value = 3 }
                }
            };
            indicator.Calculate();
            // Act & Assert
            Assert.Equal(5, indicator.CalcValue);
        }

        [Fact]
        public void Calculeted_TypeAverage_True()
        {
            // Arrange
            IndicatorDTO indicator = new IndicatorDTO
            {
                Id = 1,
                Description = "Test Indicator",
                TypeCalc = TypeCalc.Media,
                Collects = new List<CollectDTO>
                {
                    new CollectDTO { Value = 10 },
                    new CollectDTO { Value = 20 },
                    new CollectDTO { Value = 30 }
                }
            };
            indicator.Calculate();
            // Act & Assert
            Assert.Equal(20, indicator.CalcValue);
        }


        [Fact]
        public void Calculeted_TypeAverage_False()
        {
            // Arrange
            IndicatorDTO indicator = new IndicatorDTO
            {
                Id = 1,
                Description = "Test Indicator",
                TypeCalc = TypeCalc.Media
            };

            indicator.Calculate();
            // Act & Assert
            Assert.Equal(0, indicator.CalcValue);
        }
    }
}
