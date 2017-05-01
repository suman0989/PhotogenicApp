using System;
using System.Collections.Generic;

namespace Photogenic
{
	

public class VeggieViewModel
{
	public string Name { get; set; }
	public string Type { get; set; }
	public string Image { get; set; }
}

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
		public UserModel curreentUser { get; set; }
	}
}
