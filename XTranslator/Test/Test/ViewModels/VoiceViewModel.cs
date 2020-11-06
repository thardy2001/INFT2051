using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test.ViewModels
{
    public class VoiceViewModel : BaseViewModel
    {
        public VoiceViewModel()
        {
            Title = "Voice Translation";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}