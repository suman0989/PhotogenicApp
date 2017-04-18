using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photogenic
{
	public partial class PhotogenicPage : ContentPage
	{

		public PhotogenicPage()
		{
			InitializeComponent();

			//var imageList = new Image[3];
			//imageList[0].Source = ImageSource.FromFile("mainimg1.jpeg");
			//imageList[1].Source = ImageSource.FromFile("mainimg2.jpeg");
			//imageList[2].Source = ImageSource.FromFile("mainimg3.jpeg");


			//ImagesListViews.Children.Add(Image.s,j,0);
		}

		void signUpAction(object sender, System.EventArgs e)
		{

			/*
 if (Regex.Match("myemail@validationexample.com", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
     {
                 //Valid email      
     }else
     {
                //Not valid email      
     }

*/
			UserModel user = new UserModel(fName.Text, lName.Text, email.Text, mobile.Text, pswd.Text);

			DisplayAlert("SignUp Success", "Welcome \n" + user.fName +" "+ user.lName , "Ok");
		}
	}
}
