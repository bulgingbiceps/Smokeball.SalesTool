using Smokeball.SalesTool.Services;
using Xunit;

namespace Smokeball.SalesTool.Test.Services
{
    public class DefaultParameterServiceTest
    {
        [Fact]
        public void TestGetDefaultInput()
        {
            var defaultParameterService = new DefaultParameterService();
            var searchRelevanceInput = defaultParameterService.GetDefaultInput();
            Assert.NotNull(searchRelevanceInput);
            Assert.NotNull(searchRelevanceInput.SearchPattern);
            Assert.NotNull(searchRelevanceInput.SearchUrl);
            Assert.NotNull(searchRelevanceInput.SearchKeyWord);
        }
    }
}
