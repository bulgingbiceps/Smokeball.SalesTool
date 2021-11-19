using System.Collections.Generic;

namespace Smokeball.SalesTool.Models
{
    public class SearchRelevanceOutput : BaseModel
    {
        private const string CommaSeparator = ",";
        private string result;
        private IList<int> relevanceIndex;

        public string Result
        {
            get => result;
            set
            {
                result = value;
                NotifyPropertyChanged(nameof(Result));
            }
        }

        public IList<int> RelevanceIndex
        {
            get => relevanceIndex;
            set
            {
                relevanceIndex = value;
                NotifyPropertyChanged(nameof(RelevanceIndex));
                NotifyPropertyChanged(nameof(RelevanceIndexDisplay));
                
            }
        }

        public string RelevanceIndexDisplay => relevanceIndex == null ? string.Empty : string.Join(CommaSeparator, relevanceIndex);
    }
}
