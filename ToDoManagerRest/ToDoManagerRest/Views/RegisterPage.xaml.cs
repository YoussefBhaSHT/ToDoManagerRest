using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoManagerRest.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoManagerRest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        TaskManager taskmanager = new TaskManager();
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private async void RegisterAsync(object sender, EventArgs e)
        {
            try
            {

                await taskmanager.Register(name.Text, email.Text, password.Text);
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("not working : "+ex);
            }
        }
    }
}