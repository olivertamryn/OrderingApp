using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetSwagOrderingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var netswag = new NetSwag();
            BindingContext = netswag;
        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            var netswag = (NetSwag)BindingContext;
            OrdersDatabase database = await OrdersDatabase.Instance;
            await database.SaveItemAsync(netswag);
            
            await Navigation.PushAsync(new OrderList());
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var netswag = (NetSwag)BindingContext;
            OrdersDatabase database = await OrdersDatabase.Instance;
            await database.DeleteItemAsync(netswag);
            await Navigation.PopAsync();
            await Navigation.PushAsync(new OrderList());
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderList());
        }
    }
}
