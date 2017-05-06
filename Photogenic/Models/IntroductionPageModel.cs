using System;
namespace Photogenic
{
	public class IntroductionPageModel
	{
		public string carouselImage { get; set; }
		public string carouselInformation { get; set; }

		public  IntroductionPageModel(string img, String infoText)
		{
			carouselImage = img;
			carouselInformation = infoText;
		}
	}
}
