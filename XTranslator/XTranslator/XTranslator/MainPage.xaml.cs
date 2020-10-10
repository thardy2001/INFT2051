using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace XTranslator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void speech_to_text(object sender, System.EventArgs e)
        {

        }
        async void text_to_speech(object sender, System.EventArgs e)
        {
            await TextToSpeech.SpeakAsync(txtInput.Text);
        }
    }
}
