using Shell.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Business.Interface;
using UI.Shell.ViewModels;

namespace UI.Shell.Commands
{
    public class SearchCommand : BaseCommand
    {
        private readonly SearchViewModel _viewModel;
        private readonly IUrlSearchService _urlSearchService;
       
        public SearchCommand(SearchViewModel viewModel, IUrlSearchService urlSearchService)
        {
            _viewModel = viewModel;
            _urlSearchService = urlSearchService;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
        
        public override bool CanExecute(object parameter)
        {
            return _viewModel.IsValidSearch;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ClearMessages();

            try
            {
                var result = new List<int>();

               Task task = Task.Run(async () =>
               {
                     result = await _urlSearchService.GoogleSearchAsync(_viewModel.Url, _viewModel.Keyword);
               });
               task.Wait();
               var resultString = string.Join(", ", result);
                _viewModel.ResultMessage = $"Successfully find {resultString}.{Environment.NewLine}This message is not responsing api just dumy data to test";
            }
            catch (SearchResultNotFoundException)
            {
                _viewModel.ErrorMessage = $"Search failed. Unable to find {_viewModel.Keyword}.";
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchViewModel.IsValidSearch))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
