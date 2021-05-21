using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTails.ViewModel;
using TreeTails.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeTails.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTree : ContentPage
    {
        TreeListViewModel _viewModel;
    
        bool _isUpdate;
        int id;
        public AddTree()
        {
            InitializeComponent();
            _viewModel = new TreeListViewModel();
            _isUpdate = false;
        }

        public AddTree(TreeModel obj)
        {
            InitializeComponent();
            _viewModel = new TreeListViewModel();
            if (obj != null)
            {
                id = obj.id;
                TreeCode.Text = obj.TreeCode;
                InitialIdentification.Text = obj.InitialIdentification;
                Notes.Text = obj.Notes;
                GPSCoordinates.Text = obj.GPSCoordinates;
                Location.Text = obj.Location;
                LandmarkOfLocation.Text = obj.LandmarkOfLocation;
                Height.Text = obj.Height;
                DMB.Text = obj.DMB;
                TrunkWounds.Text = obj.TrunkWounds;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            TreeModel obj = new TreeModel();
            obj.id = id;
            obj.TreeCode = TreeCode.Text;
            obj.InitialIdentification = InitialIdentification.Text;
            obj.Notes = Notes.Text;
            obj.GPSCoordinates = GPSCoordinates.Text;
            obj.Location = Location.Text;
            obj.LandmarkOfLocation = LandmarkOfLocation.Text;
            obj.Height = Height.Text;
            obj.DMB = DMB.Text;
            obj.TrunkWounds=TrunkWounds.Text;
            if (_isUpdate)
            {
                obj.id = id;
                await _viewModel.UpdateTreeList(obj);
            }
            else
            {
                _viewModel.InsertTreeList(obj);
            }
            await this.Navigation.PopAsync();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListTree());
        }



    }
}