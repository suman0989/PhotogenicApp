using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Photogenic
{
	public partial class IntroductionPage : CarouselPage
	{
		public ObservableCollection<IntroductionPageModel> carouselModels{get; set;}
		private List<String> images = new List<string>();

		public IntroductionPage()
		{
			InitializeComponent();

			addCarouselImageList();
		
			carouselModels = new ObservableCollection<IntroductionPageModel>();
			for (int i = 0; i < PhotogenicConfiguration.Intro_NumberOfPages; i++){
				IntroductionPageModel carouselModel = new IntroductionPageModel(images[i], "Phtographer's home");
				carouselModels.Add(carouselModel);
			}

			ItemsSource = carouselModels;

		}

		private void addCarouselImageList()
		{
			images.Add("intro1.jpeg");
			//images.Add("intro2.jpeg");
			//images.Add("intro3.jpeg");
			//images.Add("intro4.jpeg");
			images.Add("intro5.jpeg");
			images.Add("intro6.jpeg");
		}
	}
}
