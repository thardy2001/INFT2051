using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test.ViewModels
{
    public class HelpViewModel : BaseViewModel
    {
        public HelpViewModel()
        {
            Title = "Help";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}