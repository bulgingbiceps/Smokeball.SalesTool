using Moq;
using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;
using Smokeball.SalesTool.Services;
using Smokeball.SalesTool.Services.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Smokeball.SalesTool.Test.Services
{
    public class SearchRelevanceServiceTest
    {
       

        [Fact]
        public void TestGetSearchRelevance()
        {
            var response = "responsestring";
            var relevanceIndex = new List<int> { 1, 3, 9 };
            var searchRelevanceInput = new SearchRelevanceInput();

            var httpHelperService = new Mock<IHttpHelperService>();
            httpHelperService.Setup(x => x.GetHttpResponseAsync(It.IsAny<SearchRelevanceInput>())).ReturnsAsync(response);

            var keyWordMatchService = new Mock<IKeyWordMatchService>();
            keyWordMatchService.Setup(x => x.CountMatches(searchRelevanceInput, response)).Returns(relevanceIndex);
            var searchRelevanceService = new SearchRelevanceService(httpHelperService.Object, keyWordMatchService.Object);

            var searchRelevanceOutput = searchRelevanceService.GetSearchRelevance(searchRelevanceInput).Result;

            Assert.NotNull(searchRelevanceOutput);
            Assert.Equal(Constants.SuccessMessage, searchRelevanceOutput.Result);
            Assert.Equal(relevanceIndex, searchRelevanceOutput.RelevanceIndex);

        }

    }
}
