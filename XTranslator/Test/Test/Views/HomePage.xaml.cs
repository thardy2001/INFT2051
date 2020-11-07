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

        IDictionary<string, string> languages = new Dictionary<string, string>(){ // Convert between readable and required format 
                {"English", "en"},
                {"Russian", "ru"},
                {"Chinese (Simple)", "zh-CN"},
                {"Chinese (Traditional)", "zh-TW"},
                {"Spanish", "es"},
                {"German", "de"},
                {"Japanese", "ja"},
                {"Auto-Detect", "auto"}
        };

        void EditorTextChanged(object sender, TextChangedEventArgs e) { Console.WriteLine("Text Updated"); text = e.NewTextValue;} // Update the text whenever a change occurs 
        private void translateButton_Click(object sender, EventArgs e) // Tranlate the text when tranate button is pressed 
        {
            Console.WriteLine("Button pressed");
            if(languages[(string)languageFrom.SelectedItem] == "auto"){
                TranslateText(text, DetectLanguage(), languages[(string)languageTo.SelectedItem]);
            } else
            {
                TranslateText(text, languages[(string)languageFrom.SelectedItem], languages[(string)languageTo.SelectedItem]);
            }
            
        }
        public string DetectLanguage() // detects the language typed in https://cloud.google.com/translate/docs/basic/detecting-language
        {
            TranslationClient client = TranslationClient.Create();
            var detection = client.DetectLanguage(text: text);
            return detection.Language;
        }
        public string TranslateText(string t, string target, string source) // translates the given text https://cloud.google.com/translate/docs/basic/translating-text
        {
            Console.WriteLine("Entered TranslateText()");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TranslationClient client = TranslationClient.Create();
            var response = client.TranslateText(
                text: t,
                targetLanguage: target, 
                sourceLanguage: source);
            Console.WriteLine(response.TranslatedText);
            translated.Text = response.TranslatedText;
            return response.TranslatedText;
        }
        public HomePage()
        {
            InitializeComponent();
        }
    }
}