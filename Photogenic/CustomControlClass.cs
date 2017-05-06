using System;
using Xamarin.Forms;
using Plugin.Controls.FloatingLabelEntry.ExtendedControls;

namespace Photogenic
{
	public class PhotoGenicEntry:ExtendedEntry
	{
		public PhotoGenicEntry()
		{
			
			PickerDisplayMember = "Password";
		}
	}
}
