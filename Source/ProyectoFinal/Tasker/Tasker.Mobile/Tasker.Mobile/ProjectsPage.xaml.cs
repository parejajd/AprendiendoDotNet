using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasker.Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProjectsPage : ContentPage
	{
		public ProjectsPage ()
		{
			InitializeComponent ();
		}

        private async void Refresh_Clicked(object sender, EventArgs e)
        {
            RestService rest = new RestService();

            ListaDeProyectos.ItemsSource = await rest.GetProjects();
        }
    }
}