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
		public PhotoGenicSignInPage(){
			InitializeComponent();
		}

		void  signupAction(object sender, System.EventArgs e){

			if (email.Text != null && pswd.Text != null){
				callSignInAPI();
			}
			else{
                DisplayAlert("Please enter your email and password","", "Ok");
			}
		}

		void callSignInAPI(){
			bool result = false;
			activity.IsVisible = true;
			activity.IsRunning = true;
			email.IsEnabled = false;
			pswd.IsEnabled = false;
			signinbtn.IsEnabled = false;
			signupbtn.IsEnabled = false;
			Task.Factory.StartNew (() => {
                result = service.checkUserLogin(email.Text, pswd.Text);
			}).ContinueWith(task => {
				activity.IsVisible = false;
				activity.IsRunning = false;
				email.IsEnabled = true;
				pswd.IsEnabled = true;
				signinbtn.IsEnabled = true;
				signupbtn.IsEnabled = true;
				if (result == true){
					Navigation.PushModalAsync(new PhotoGenicHomePage());
				}
				else{
					DisplayAlert("Signin Failed", "Wrong username or password", "Ok");
				}
			}, TaskScheduler.FromCurrentSynchronizationContext ());
		}

		async void pushToSignUp(object sender, System.EventArgs e){
			await Navigation.PushModalAsync(new PhotogenicPage());
		}


	}
}
