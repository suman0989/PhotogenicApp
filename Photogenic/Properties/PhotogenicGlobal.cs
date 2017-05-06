﻿namespace Photogenic
{
	public static class PhotogenicConfiguration
	{
		#if DEBUG
				public const string Configuration = "Debug";
                public const string APP_KEY = "#455rgrgr!@tt^&eqq1dd";
		        public const string API_URL = "http://api.freshzbyte.com/api/call";
				public const int Intro_NumberOfPages = 3;
		#else 
				public const string Configuration = "Release";
                public const string APP_KEY = "#455rgrgr!@tt^&eqq1dd";
	         	public const string API_URL = "http://api.freshzbyte.com/api/call";
				public const int Intro_NumberOfPages = 3;
		#endif
	}
}
