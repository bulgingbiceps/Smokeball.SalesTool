namespace Smokeball.SalesTool.Models
{
    public class SearchRelevanceInput : BaseModel
    {
        private string searchUrl;
        private string searchKeyWord;

        public string SearchUrl
        {
            get => searchUrl;
            set
            {
                searchUrl = value;
                NotifyPropertyChanged(nameof(SearchUrl));
            }

        }

        public string SearchKeyWord
        {
            get => searchKeyWord;
            set
            {
                searchKeyWord = value;
                NotifyPropertyChanged(nameof(SearchKeyWord));
            }

        }

        public string SearchPattern { get; set; }
    }


}
