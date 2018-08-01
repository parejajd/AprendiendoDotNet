using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Mobile.Services;
using Tasker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasker.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksPage : ContentPage
    {
        public ObservableCollection<MyTask> Tareas = new ObservableCollection<MyTask>();

        public TasksPage()
        {
            InitializeComponent();

            Tareas.Add(new MyTask { MyTaskId = 1, Name = "Preparar cafe", Description = "Preparar café pa que la gente no se duerma" });
            Tareas.Add(new MyTask { MyTaskId = 2, Name = "Preparar cafe 1", Description = "Preparar café pa que la gente no se duerma" });
            Tareas.Add(new MyTask { MyTaskId = 3, Name = "Preparar cafe 2", Description = "Preparar café pa que la gente no se duerma" });
            Tareas.Add(new MyTask { MyTaskId = 4, Name = "Preparar cafe 3", Description = "Preparar café pa que la gente no se duerma" });
            Tareas.Add(new MyTask { MyTaskId = 5, Name = "Preparar cafe 4", Description = "Preparar café pa que la gente no se duerma" });
            Tareas.Add(new MyTask { MyTaskId = 6, Name = "Preparar cafe 5", Description = "Preparar café pa que la gente no se duerma" });
            Tareas.Add(new MyTask { MyTaskId = 7, Name = "Preparar cafe 6", Description = "Preparar café pa que la gente no se duerma" });

            ListaDeTareas.ItemsSource = Tareas;


        }

        private async void Refresh_Clicked(object sender, EventArgs e)
        {
            RestService rest = new RestService();

            ListaDeTareas.ItemsSource = await rest.GetTasks();
        }
    }
}