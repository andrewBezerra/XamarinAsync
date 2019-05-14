using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            CancellationTokenSource CancelSource = new CancellationTokenSource();
            var token = CancelSource.Token;

            Stopwatch watch = new Stopwatch();

            watch.Start();

            //Iniciando Task1 e Task2 paralelamente
            var Task1 = Tarefa(1700,token);
            var Task2 = Tarefa(2000, token);
         
            var retorno = await Task.WhenAny(Task1, Task2);
            CancelSource.Cancel();
            //Task3 iniciada e recebendo o retorno da Tarefa que terminou primeiro.
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
        private async Task<int> Tarefa(int ms, CancellationToken token)
        {
            while (!token.IsCancellationRequested && ms > 0)
            {
                await Task.Delay(1, token);
                ms--;
            }
            if (token.IsCancellationRequested)
                      return 0;
            
            return ms;
        }
    }
}