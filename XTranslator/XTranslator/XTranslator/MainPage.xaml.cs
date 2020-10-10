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
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void speech_to_text(object sender, EventArgs e)
        {

        }
        async void text_to_speech(object sender, EventArgs e)
        {
            outLabel.Text = txtInput.Text;
            if(txtInput.Text != null)
            {
                await TextToSpeech.SpeakAsync(txtInput.Text);
            }
            
        }
    }
}
