using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Photogenic
{
	public partial class PhotogenicPage : ContentPage
	{
		WebService service = new WebService();
		const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
								@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"; 

		public PhotogenicPage()
		{
			InitializeComponent();

		}

		void signUpAction(object sender, System.EventArgs e)
		{
			if (email.Text != null && pswd.Text != null
				&& cnfPswd.Text != null && fName.Text != null
				&& lName.Text != null){

				if (Regex.Match(email.Text, emailRegex).Success){

					callSignupApi();
				}
				else{
                    DisplayAlert("Please enter valid email","", "Ok");
				}

			}
			else{
                  DisplayAlert("Please enter all mandatory fields","", "Ok");
			}
		}

		void callSignupApi()
		{
			bool result = false;
			activity.IsVisible = true;
			activity.IsRunning = true;
			setTextFieldEnable(false);
			Task.Factory.StartNew (() => {
				result = service.signUpUser(email.Text, fName.Text, lName.Text, pswd.Text);
			}).ContinueWith(task => {
				activity.IsVisible = false;
				activity.IsRunning = false;
				setTextFieldEnable(true);
				if (result == true){
					Navigation.PushModalAsync(new PhotoGenicHomePage());
				}
				else{
					DisplayAlert("Signin Failed", "Wrong username or password", "Ok");
				}
			}, TaskScheduler.FromCurrentSynchronizationContext ());
		}

		void setTextFieldEnable(bool value){
			email.IsEnabled = value;
			pswd.IsEnabled = value;
			fName.IsEnabled = value;
			lName.IsEnabled = value;
			mobile.IsEnabled = value;
			cnfPswd.IsEnabled = value;
			signupbtn.IsEnabled = value;
		}
	 
	
	}
}
