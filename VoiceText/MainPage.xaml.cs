using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace VoiceText
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<VoiceInformation> voiceInformationList = new List<VoiceInformation>();
        List<string> vs = new List<string>();
        IDictionary<string, string> text = new Dictionary<string, string>();
       
        List<string> lan = new List<string>() { "中文欢迎}", "英文欢迎" };
        public MainPage()
        {
            this.InitializeComponent();
            foreach (var item in SpeechSynthesizer.AllVoices)
            {
                voiceInformationList.Add(item);
                vs.Add(item.DisplayName);
            }
            text.Add("中文欢迎","zh-CN");
            text.Add("英文欢迎","en-US");
            Select2.ItemsSource = text.Keys;
            Select2.SelectedIndex = 0;
            Select.ItemsSource = vs;
            Select.SelectedIndex = 0;
        }

        private async void Text_Click(object sender, RoutedEventArgs e)
        {
           var a= Select2.SelectedItem;
            string lan=text[Select2.SelectedItem.ToString()];
            VoiceInformation voice ;
            foreach (var item in voiceInformationList)
            {
                if(item.DisplayName==Select.SelectedItem.ToString()&&item.Language==lan)
                {
                 voice = item;
                    string str ="欢迎 "+ Content.Text;
                    SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                    synthesizer.Voice = voice;
                    SpeechSynthesisStream stream = await synthesizer.SynthesizeTextToStreamAsync(str);
                    Me.SetSource(stream, stream.ContentType);
                    Me.Play();
                }
                else if(item.DisplayName == Select.SelectedItem.ToString() && item.Language == "en-US")
                {
                    voice = item;
                    string str = "Welcome " + Content.Text;
                    SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                    synthesizer.Voice = voice;
                    SpeechSynthesisStream stream = await synthesizer.SynthesizeTextToStreamAsync(str);
                    Me.SetSource(stream, stream.ContentType);
                    Me.Play();
                }
                else if(item.DisplayName == Select.SelectedItem.ToString()&& item.Language == "zh-TW")
                {
                    voice = item;
                    string str = "欢迎" + Content.Text;
                    SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                    synthesizer.Voice = voice;
                    SpeechSynthesisStream stream = await synthesizer.SynthesizeTextToStreamAsync(str);
                    Me.SetSource(stream, stream.ContentType);
                    Me.Play();
                }
            }
         
           
        }
    }
}
