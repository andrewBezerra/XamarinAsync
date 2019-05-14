using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAsync
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public string msg { get; set; }
        public MainPage()
        {
            InitializeComponentsAsync();
        }

        public async Task InitializeComponentsAsync()
        {
            await Task.Run(()=> InitializeComponent());
        }

        private async void BtnAsync_Clicked(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            await DisplayAlert("Tarefa Grande", "Tarefa Assincrona Terminou","OK");
        }

        private void BtnSync_Clicked(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            DisplayAlert("Tarefa Grande", "Tarefa Sincrona Terminou", "OK");
        }
    }
}
