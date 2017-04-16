using System;
namespace Photogenic
{
	public class UserModel
	{
		public string fName { get; set; }
public string lName { get; set; }
public	string emailId { get; set; }
public	string passWord { get; set; }
public	string mobileNumber { get; set; }


		public UserModel(string firstName, String lastName, String email, string mobileNumber, string pswd)
		{
			fName = firstName;
			lName = lastName;
			emailId = email;
            passWord = pswd;

		}
	}
}
