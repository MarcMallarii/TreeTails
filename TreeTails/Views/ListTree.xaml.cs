using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTails.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using TreeTails.ViewModel;

namespace TreeTails.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTree : ContentPage
    {
        TreeListViewModel viewModel;
        public ListTree()
        {
            InitializeComponent();
            viewModel = new TreeListViewModel();      
        }
         protected override void OnAppearing()
        {
            base.OnAppearing();
 
            showTreeList();
        }
        private void showTreeList()
        {
            var res = viewModel.GetAllTreeLists().Result;
            TreeListView.ItemsSource = res;
            
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddTree());
        }

        private async void TreeListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                TreeModel obj = (TreeModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddTree(obj));
                        break;
                    case "Delete":
                        viewModel.DeleteTreeList(obj);
                        showTreeList();
                        break;
                }
                TreeListView.SelectedItem = null;
            }
        }
    }
}