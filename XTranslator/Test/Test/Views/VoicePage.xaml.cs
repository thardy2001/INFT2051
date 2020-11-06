using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using Test.Models;
using Test.Views;
using Test.ViewModels;

namespace Test.Views
{
    public partial class VoicePage : ContentPage
    {   
        public VoicePage()
        {
            InitializeComponent();
        }
        void speech_to_text(object sender, EventArgs e)
        {

        }
        async void text_to_speech(object sender, EventArgs e)
        {
            if (txtOutput.Text != null)
            {
                await TextToSpeech.SpeakAsync(txtOutput.Text);
            }

        }
    }
}