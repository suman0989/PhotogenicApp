using System;
using System.Collections.Generic;

namespace Photogenic
{
	//public class UserModel
	//{
	//	public string fName { get; set; }
	//	public string lName { get; set; }
	//	public	string emailId { get; set; }
	//	public	string passWord { get; set; }
	//	public	string mobileNumber { get; set; }


	//	public UserModel(string firstName, String lastName, String email, string mobileNumber, string pswd)
	//	{
	//		fName = firstName;
	//		lName = lastName;
	//		emailId = email;
 //           passWord = pswd;

	//	}
	//}



	public class UserModel
	{
		public string user_id { get; set; }
		public string email { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string user_pic { get; set; }
	}

	public class LoginModel
	{
		public string status { get; set; }
		public string message { get; set; }
	    public List<UserModel> data { get; set; }
	}

	public class LoginErrorModel
	{
		public string status { get; set; }
		public string message { get; set; }
	}

	public class SharedVariables
	{
		// this is the default static instance you'd use like string text = Settings.Default.SomeSetting;
		public readonly static SharedVariables Default = new SharedVariables();
		public string name { get; set; } // add shared value properties as you wish
		public string userid { get; set; }
		public string mobileNumber { get; set; }
		public string emailId { get; set; }
	}
}
