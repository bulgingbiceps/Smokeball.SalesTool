using AsyncAwaitBestPractices.MVVM;
using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;
using System;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.ViewModel
{
    public class SearchRelevanceViewModel : BaseViewModel
    {
        private SearchRelevanceInput searchRelevanceInput;
        private SearchRelevanceOutput searchRelevanceOutput = new SearchRelevanceOutput();
        private ISearchRelevanceService _searchRelevanceService;
        private IDefaultParameterService _defaultParameterService;
        private bool _isBusy;

        public AsyncCommand FetchResultsCommand { get; private set; }


        public SearchRelevanceInput SearchRelevanceInput
        {
            get => searchRelevanceInput;
            set
            {
                searchRelevanceInput = value;
                NotifyPropertyChanged(nameof(SearchRelevanceInput));
            }
        }

        public SearchRelevanceOutput SearchRelevanceOutput
        {
            get => searchRelevanceOutput;
            set
            {
                searchRelevanceOutput = value;
                NotifyPropertyChanged(nameof(SearchRelevanceOutput));
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    FetchResultsCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public SearchRelevanceViewModel(ISearchRelevanceService searchRelevanceService, IDefaultParameterService defaultParameterService)
        {
            _searchRelevanceService = searchRelevanceService;
            _defaultParameterService = defaultParameterService;
            FetchResultsCommand = new AsyncCommand(ExecuteFetchResultsAsync, CanExecuteFetchResultsAsync);
            SearchRelevanceInput = _defaultParameterService.GetDefaultInput();
        }


        private bool CanExecuteFetchResultsAsync(object arg)
        {
            return !IsBusy;
        }

        private async Task ExecuteFetchResultsAsync()
        {
            IsBusy = true;
            try
            {
                SearchRelevanceOutput = await _searchRelevanceService.GetSearchRelevance(SearchRelevanceInput);
            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
        
    }
}
