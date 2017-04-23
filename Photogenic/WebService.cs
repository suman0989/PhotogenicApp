using System;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;


namespace Photogenic
{
	public class WebService
	{
		public bool checkUserLogin(string email, string password){
			
			try{
				using (HttpClient client = new HttpClient()){
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var postData = new List<KeyValuePair<string, string>>();
					postData.Add(new KeyValuePair<string, string>("email", email));
					postData.Add(new KeyValuePair<string, string>("pass", password));
					postData.Add(new KeyValuePair<string, string>("appKey", PhotogenicConfiguration.APP_KEY));

					var content = new System.Net.Http.FormUrlEncodedContent(postData);

					var url = PhotogenicConfiguration.API_URL+"/users";
					var result = client.PostAsync(url, content).Result;
					if (result.IsSuccessStatusCode){
						try{
							var dataString = result.Content.ReadAsStringAsync().Result;
							Debug.WriteLine("DataString: " + dataString);
							var contentData = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginModel>(dataString);
							if (contentData.data.Count > 0){
								UserModel user = contentData.data.First();
								if (user.email == null || user.email == string.Empty){
									//LoginErrorModel
									var errorData = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginErrorModel>(dataString);
									Debug.WriteLine("Error: {0}", errorData.message);
									return false;
								}
								else{
									Debug.WriteLine("Login Success: {0}", user.first_name+user.last_name);
									//share login data ....
									SharedVariables.Default.curreentUser = user;
									return true;
								}
							}
							else{
								return false;
							}
						}
						catch (Exception exp){
							var dataString = result.Content.ReadAsStringAsync().Result;
							var errorData = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginErrorModel>(dataString);
							Debug.WriteLine("Error: {0}", errorData.message);
							Debug.WriteLine("Error: {0}", exp);
							return false;
						}
					}
					else {
						return false;
					}
				}
			}

			catch (Exception exp){
				Debug.WriteLine("Error: {0}", exp);
				return false;
			}

		}



		/*
		public bool resetUserPassword(string userid, string password)//reset user password...
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var postData = new List<KeyValuePair<string, string>>();
					postData.Add(new KeyValuePair<string, string>("id", userid));
					postData.Add(new KeyValuePair<string, string>("password", password));
					var content = new System.Net.Http.FormUrlEncodedContent(postData);

					var url = "http://184.106.114.93/KnockKnock/resetPassword";
					var result = client.PostAsync(url,content).Result;
					if (result.IsSuccessStatusCode)
					{
						try
						{
							var dataString = result.Content.ReadAsStringAsync().Result;
							var contentData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(dataString);
							//Debug.WriteLine("DataString: {0}", contentData["status"]);
							Debug.WriteLine("DataString: " + dataString);

							if (contentData["status"].ToString() == "Success")
							{
								return true;
							}
							else {
								return false;
							}

						}
						catch (Exception exp)
						{
							Debug.WriteLine("Error: {0}", exp);
							return false;
						}
					}
					else {

						return false;
					}
				}

			}


			catch (Exception exp)
			{

				Debug.WriteLine("Error: {0}", exp);

				return false;
			}

		}


		public List<MeetingModel> getMeetingList()//get all meetingList....
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var url = "http://184.106.114.93/KnockKnock/getBookingList";
					var result = client.GetAsync(url).Result;
					if (result.IsSuccessStatusCode)
					{
						try
						{
							var dataString = result.Content.ReadAsStringAsync().Result;
							var contentData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MeetingModel>>(dataString);
							Debug.WriteLine("DataString: " + dataString);

							//for (int i = 0; i < contentData.Count(); i++)
							//{
							//	MeetingModel meetingModel = contentData[i];
							//	Debug.WriteLine("Metting: {0} Sub: {1}", meetingModel.MeetingRoomID, meetingModel.Subject);
							//}
							return contentData;
						}
						catch (Exception exp)
						{
							Debug.WriteLine("Error: {0}", exp);
							return null;
						}
					}
					else {
						return null;
					}
				}

			}


			catch (Exception exp)
			{

				Debug.WriteLine("Error: {0}", exp);
				return null;

			}

		}


		public bool bookMeetingRoom(string meetingRoomId, string userId, string startTime, string endTime, string subject, string desc)
		{//book meeting room...
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				
					var postData = new List<KeyValuePair<string, string>>();
					postData.Add(new KeyValuePair<string, string>("meetingRoomId", meetingRoomId));
					postData.Add(new KeyValuePair<string, string>("bookingUserId", userId));
					postData.Add(new KeyValuePair<string, string>("startTime", startTime));
					postData.Add(new KeyValuePair<string, string>("endTime", endTime));
					postData.Add(new KeyValuePair<string, string>("subject", subject));
					postData.Add(new KeyValuePair<string, string>("description", desc));


					var content = new System.Net.Http.FormUrlEncodedContent(postData);

					var url = "http://184.106.114.93/KnockKnock/roomBooking";
					var result = client.PostAsync(url, content).Result;
					if (result.IsSuccessStatusCode)
					{
						try
						{
							var dataString = result.Content.ReadAsStringAsync().Result;
							var contentData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(dataString);
							Debug.WriteLine("DataString: {0}",contentData["status"]);

							if (contentData["status"].ToString() == "OK")
							{
								return true;

							}
							else {
								return false;
							}
						}
						catch (Exception exp)
						{
							Debug.WriteLine("Error: {0}", exp);
							return false;
						}
					}
					else {

						return false;
					}
				}

			}


			catch (Exception exp)
			{
				Debug.WriteLine("Error: {0}", exp);

				return false;
			}

		}


		public List<MettingRoomModel> getMeetingsRooms()//get meeting room list...
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var url = "http://184.106.114.93/KnockKnock/api/MeetingRoom";
					var result = client.GetAsync(url).Result;
					if (result.IsSuccessStatusCode)
					{
						try
						{
							var dataString = result.Content.ReadAsStringAsync().Result;
							var contentData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MettingRoomModel>>(dataString);
							Debug.WriteLine("DataString: " + dataString);
							return contentData;

						}
						catch (Exception exp)
						{
							Debug.WriteLine("Error: {0}", exp);
							return null;
						}
					}
					else {
						return null;
					}
				}

			}

			catch (Exception exp)
			{
				Debug.WriteLine("Error: {0}", exp);
				return null;

			}

		}


		public bool updateUserDetails(string userid, string newName, string newmobilenumber)//update user details...
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					var postData = new List<KeyValuePair<string, string>>();
					postData.Add(new KeyValuePair<string, string>("iD", userid));
					postData.Add(new KeyValuePair<string, string>("name", newName));
					postData.Add(new KeyValuePair<string, string>("mobileNumber", newmobilenumber));

					var content = new System.Net.Http.FormUrlEncodedContent(postData);

					var url = "http://184.106.114.93/KnockKnock/update";
					var result = client.PostAsync(url, content).Result;
					if (result.IsSuccessStatusCode)
					{
						try
						{
							var dataString = result.Content.ReadAsStringAsync().Result;
							var contentData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(dataString);
							Debug.WriteLine("DataString: " + dataString);

							if (contentData.status == "Success")
							{
								SharedVariables.Default.userId = contentData.iD;
								SharedVariables.Default.userName = contentData.name;
								SharedVariables.Default.mobileNumber = contentData.mobileNumber;
								SharedVariables.Default.emailId = contentData.email;
								//SharedVariables.Default.message = contentData.message;
								return true;
							}
							else {
								SharedVariables.Default.message = contentData.message;
								return false;

							}
						}
						catch (Exception exp)
						{
							Debug.WriteLine("Error: {0}", exp);
							return false;
						}
					}
					else {

						return false;
					}
				}

			}


			catch (Exception exp)
			{

				Debug.WriteLine("Error: {0}", exp);

				return false;
			}

		}



*/



	}



}

