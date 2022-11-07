using System.Windows.Input;
using Shell.ViewModels;
using UI.Business.Interface;
using UI.Shell.Commands;

namespace UI.Shell.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string _errorMessage;
        private string _keyword;
        private string _url;
        private string _resultMessage;
        private readonly IUrlSearchService _urlSearchService;

        public SearchViewModel(IUrlSearchService urlSearchService)
        {
            _urlSearchService = urlSearchService;
           SearchCommand = new SearchCommand(this, _urlSearchService);
        }
        public string Keyword
        {
            get
            {
                return _keyword;
            }
            set
            {
                _keyword = value;
                OnPropertyChanged(nameof(Keyword));
                OnPropertyChanged(nameof(IsValidSearch));
            }
        }
       
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                OnPropertyChanged(nameof(Url));
                OnPropertyChanged(nameof(IsValidSearch));
            }
        }


        public bool IsValidSearch => !string.IsNullOrEmpty(Keyword) && !string.IsNullOrEmpty(Url);
       
        public string ResultMessage
        {
            get
            {
                return _resultMessage;
            }
            set
            {
                _resultMessage = value;
                OnPropertyChanged(nameof(ResultMessage));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand SearchCommand { get; set; }
       
        public void ClearMessages()
        {
            ResultMessage = string.Empty;
            ErrorMessage = string.Empty;
        }
    }
}
