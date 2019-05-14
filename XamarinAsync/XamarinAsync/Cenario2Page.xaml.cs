using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAsync
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cenario2Page : ContentPage
    {
        public Cenario2Page()
        {
            InitializeComponent();
        }

        private async void btnProcessar_Clicked(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

            //Iniciando Task1, Task2 e Task3 paralelamente
            var Task1 = Tarefa(1700);
            var Task2 = Tarefa(2000);
            var Task3 = Tarefa(1500);

            var retorno = await Task.WhenAny(Task1, Task2, Task3);
            //Task4 iniciada e recebendo os retornos das tarefas.
            await Tarefa(retorno.Result);

            watch.Stop();

            await DisplayAlert(
                "Tarefas Terminaram",
                $"Tempo:{watch.Elapsed}",
                "OK");
        }

        private async Task<int> Tarefa(int ms)
        {
            await Task.Delay(ms);
            return ms;
        }
    }
}