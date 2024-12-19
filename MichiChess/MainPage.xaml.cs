using MichiChess.ViewModels;
using MichiChess.Models;
using System.Diagnostics;

namespace MichiChess
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            var viewModel = new ChessViewModel();

        }


    }


}
