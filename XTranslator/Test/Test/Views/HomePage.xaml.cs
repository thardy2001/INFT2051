using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Google.Cloud.Translation.V2;
using System.Collections.Generic;

namespace Test.Views
{

    public partial class HomePage : ContentPage
    {
        string text = ""; // The text to be translated 

        IDictionary<string, string> languages = new Dictionary<string, string>(){
                {"English", "en"},
                {"Russian", "ru"},
                {"Chinese (Simple)", "zh-CN"},
                {"Chinese (Traditional)", "zh-TW"},
                {"Spanish", "es"},
                {"German", "de"},
                {"Japanese", "ja"},
                {"Auto-Detect", "auto"}
        };

        void EditorTextChanged(object sender, TextChangedEventArgs e) {text = e.NewTextValue;} // Update the text whenever a change occurs 
        private void translateButton_Click(object sender, EventArgs e)
        {
            if(languages[(string)languageFrom.SelectedItem] == "auto"){
                TranslateText(text, DetectLanguage(), languages[(string)languageTo.SelectedItem]);
            } else
            {
                TranslateText(text, languages[(string)languageFrom.SelectedItem], languages[(string)languageTo.SelectedItem]);
            }
            
        }
        public string DetectLanguage() // https://cloud.google.com/translate/docs/basic/detecting-language
        {
            TranslationClient client = TranslationClient.Create();
            var detection = client.DetectLanguage(text: text);
            return detection.Language;
        }
        public string TranslateText(string t, string target, string source) //https://cloud.google.com/translate/docs/basic/translating-text
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TranslationClient client = TranslationClient.Create();
            var response = client.TranslateText(
                text: t,
                targetLanguage: target, 
                sourceLanguage: source);  
            translated.Text = response.TranslatedText;
            return response.TranslatedText;
        }
        public HomePage()
        {
            InitializeComponent();
        }
    }
}