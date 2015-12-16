namespace UwpSamples.Wikipedia.ViewModels
{
    #region Namespace Imports

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Windows.UI.Popups;

    using Prism.Commands;
    using Prism.Windows.Mvvm;

    using UwpSamples.Wikipedia.Service;

    #endregion

    public class SearchViewModel : ViewModelBase
    {
        #region Constants and Fields

        private readonly DelegateCommand _searchCommand;

        private readonly IWikipediaService _wikipediaService;

        private string _queryText;
        private WikipediaPage _selectedPage;

        #endregion

        #region Constructors and Destructors

        public SearchViewModel(IWikipediaService wikipediaService)
        {
            _wikipediaService = wikipediaService;

            _searchCommand = new DelegateCommand(SearchAsync, () => !string.IsNullOrWhiteSpace(QueryText));
        }

        #endregion

        #region Properties

        public string QueryText
        {
            get
            {
                return _queryText;
            }

            set
            {
                if (SetProperty(ref _queryText, value))
                {
                    _searchCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand SearchCommand => _searchCommand;

        public ObservableCollection<WikipediaPage> SearchResults { get; } = new ObservableCollection<WikipediaPage>();

        public WikipediaPage SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                SetProperty(ref _selectedPage, value);
            }
        }

        #endregion

        #region Methods

        private async void SearchAsync()
        {
            try
            {
                List<WikipediaPage> pages = await _wikipediaService.SearchAsync(QueryText).ConfigureAwait(true);

                SearchResults.Clear();

                foreach (WikipediaPage page in pages)
                {
                    SearchResults.Add(page);
                }
            }
            catch
            {
                var messageDialog = new MessageDialog("Search failed.", "error");
                await messageDialog.ShowAsync();
            }
        }

        #endregion
    }
}