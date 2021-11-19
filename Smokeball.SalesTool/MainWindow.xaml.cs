using Smokeball.SalesTool.ViewModel;
using System;
using System.Windows;

namespace Smokeball.SalesTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchRelevanceViewModel _searchRelevanceViewModel;

        public MainWindow(SearchRelevanceViewModel searchRelevanceViewModel)
        {
            _searchRelevanceViewModel = searchRelevanceViewModel;
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            try
            {
                this.DataContext = _searchRelevanceViewModel;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            base.OnInitialized(e);
        }
    }
}
