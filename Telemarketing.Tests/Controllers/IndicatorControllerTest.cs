using Telemarketing.Data.Entities;
using Telemarketing.Data.Enums;
using Telemarketing.DTOs;

namespace Telemarketing.Tests.Controllers
{
    public class IndicatorControllerTest
    {
        [Fact]
        public void Create_ValidParamters_ResultTrue()
        {
            // Datas
            IndicatorDTO indicator = new IndicatorDTO
            {
                Name = "Test Indicator",
                Description = "This is a test indicator",
                TypeCalc = TypeCalc.Media,
                Collects = new List<CollectDTO>()
            };
            indicator.Collects.Add(new CollectDTO { Value = 10.00 });

            // Act
            bool result = indicator != null &&
                          !string.IsNullOrEmpty(indicator.Name) && 
                          indicator.Collects.Count > 0 && 
                          indicator.Collects.All(c => c.Value > 0);

            // Assert
            Assert.True(result, "Indicator creation failed with valid parameters.");
            Assert.Equal(TypeCalc.Media, indicator.TypeCalc);
            Assert.NotEmpty(indicator.Name);
            Assert.NotEmpty(indicator.Collects);
            Assert.All(indicator.Collects, c => Assert.True(c.Value > 0, "Collect value must be greater than zero."));
        }
        
        [Fact]
        public void Create_ValidParamters_ResultFalse()
        {
            // Datas
            IndicatorDTO indicator = new IndicatorDTO
            {
                Name = "",
                Collects = new List<CollectDTO>()
            };
            indicator.Collects.Add(new CollectDTO { Value = -10.00 });

            // Act
            bool result = indicator != null && 
                          string.IsNullOrEmpty(indicator.Name) && 
                          indicator.Collects.Count > 0 && 
                          indicator.Collects.All(c => c.Value <= 0);

            // Assert
            Assert.True(result, "Indicator creation failed with valid parameters.");
            Assert.NotEqual(TypeCalc.Media, indicator.TypeCalc);
            Assert.Empty(indicator.Name);
            Assert.All(indicator.Collects, c => Assert.True(c.Value <= 0, "Collect value must be less than or equal to zero."));
        }
    }
}
