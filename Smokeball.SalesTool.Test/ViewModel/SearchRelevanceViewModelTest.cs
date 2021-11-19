using Moq;
using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;
using Smokeball.SalesTool.ViewModel;
using System.Collections.Generic;
using Xunit;

namespace Smokeball.SalesTool.Test.ViewModel
{
    public class SearchRelevanceViewModelTest
    {
        private const string SuccessMessage = "Success";

        [Fact]
        public void TestGetSearchRelevance()
        {

            var relevanceIndex = new List<int> { 1, 3, 9 };
            var searchRelevanceOutput = new SearchRelevanceOutput() { Result = SuccessMessage, RelevanceIndex=relevanceIndex};

            var searchRelevanceService = new Mock<ISearchRelevanceService>();
            var defaultParameterService = new Mock<IDefaultParameterService>();
            searchRelevanceService.Setup(x => x.GetSearchRelevance(It.IsAny<SearchRelevanceInput>())).ReturnsAsync(searchRelevanceOutput);

            var searchRelevanceViewModel = new SearchRelevanceViewModel(searchRelevanceService.Object, defaultParameterService.Object);
            searchRelevanceViewModel.FetchResultsCommand.ExecuteAsync().Wait();

            Assert.NotNull(searchRelevanceViewModel.SearchRelevanceOutput);
            Assert.Equal(SuccessMessage, searchRelevanceViewModel.SearchRelevanceOutput.Result);
            Assert.Equal("1,3,9", searchRelevanceViewModel.SearchRelevanceOutput.RelevanceIndexDisplay);

        }

    }
}
