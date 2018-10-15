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
        public MainPage()
        {
            this.InitializeComponent();
            foreach (var item in SpeechSynthesizer.AllVoices)
            {
                voiceInformationList.Add(item);
                vs.Add(item.DisplayName);
            }
            Select.ItemsSource = vs;
        }

        private async void Text_Click(object sender, RoutedEventArgs e)
        {
            VoiceInformation voice ;
            foreach (var item in voiceInformationList)
            {
                if(item.DisplayName==Select.SelectedItem.ToString())
                {
                 voice = item;
                    string str = Content.Text;
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
