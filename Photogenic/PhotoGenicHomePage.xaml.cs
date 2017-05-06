using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Photogenic
{
	public partial class PhotoGenicHomePage : ContentPage
	{
        public ObservableCollection<VeggieViewModel> veggies { get; set; }
		public PhotoGenicHomePage()
		{
			InitializeComponent();

            DisplayAlert("Welcome!!!", SharedVariables.Default.curreentUser.first_name, "Ok");

            veggies = new ObservableCollection<VeggieViewModel> ();
			veggies.Add (new VeggieViewModel{ Name="Tomato", Type="Fruit", Image="demo1.jpeg"});
			veggies.Add (new VeggieViewModel{ Name="Romaine Lettuce", Type="Vegetable", Image="demo2.jpg"});
			veggies.Add (new VeggieViewModel{ Name="Zucchini", Type="Vegetable", Image="demo3.jpg"});
			veggies.Add (new VeggieViewModel{ Name="Tomato", Type="Fruit", Image="demo1.jpeg"});
			veggies.Add (new VeggieViewModel{ Name="Romaine Lettuce", Type="Vegetable", Image="demo2.jpg"});
			veggies.Add (new VeggieViewModel{ Name="Zucchini", Type="Vegetable", Image="demo3.jpg"});

			lstView.ItemsSource = veggies;
		}

		protected override bool OnBackButtonPressed(){
			if (Convert.ToInt64(SharedVariables.Default.curreentUser.user_id) > 0){
				return false;
			}
			return base.OnBackButtonPressed();	
		}
		
	}	
}
