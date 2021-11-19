using AsyncAwaitBestPractices.MVVM;
using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;
using Smokeball.SalesTool.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smokeball.SalesTool.ViewModel
{
    public class SearchRelevanceViewModel : BaseViewModel
    {
        private SearchRelevanceInput searchRelevanceInput;
        private SearchRelevanceOutput searchRelevanceOutput = new SearchRelevanceOutput();
        private ISearchRelevanceService _fetchService;
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


        public SearchRelevanceViewModel(ISearchRelevanceService fetchService, IDefaultParameterService defaultParameterService)
        {
            _fetchService = fetchService;
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
                SearchRelevanceOutput = await _fetchService.GetSearchRelevance(SearchRelevanceInput);
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
