using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photogenic
{
	public partial class PhotoGenicSignInPage : ContentPage
	{
		WebService service = new WebService();
		public PhotoGenicSignInPage()
		{
			InitializeComponent();
		}

		void signupAction(object sender, System.EventArgs e)
		{
			if (email.Text != string.Empty || pswd.Text != string.Empty)
			{
				bool result = service.checkUserLogin(email.Text, pswd.Text);

				if (result == true){
					DisplayAlert("Signin Failed", "Wrong username or password", "Ok");
				}
			}
			else
			{
                 DisplayAlert("Signin Failed","Please enter email and password", "Ok");

			}
		}

		async void pushToSignUp(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new PhotogenicPage());
		}
	}
}
