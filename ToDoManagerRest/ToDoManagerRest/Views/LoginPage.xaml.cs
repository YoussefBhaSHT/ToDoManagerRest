using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagerRest.Models;
using ToDoManagerRest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoManagerRest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void ToRegisterPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegisterPage());
        }
    }
}