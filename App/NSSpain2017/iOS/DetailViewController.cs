namespace NSSpain2017.iOS
{
	using System;
    using System.Linq;
    using MXParallaxHeaderNamespace;
    using UIKit;

	public partial class DetailViewController : UIViewController
	{
        
		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

        public Session Session { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if(Session != null)
            {
				LblTitle.Text = Session.Title;
                LblSpeakers.Text = Session.FormatSpeaker(prependMicrophone: true);
            }

            var headerViewController = (HeaderViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("headerViewController");

            var parallaxHeader = ScrollView.GetParallaxHeader();

            parallaxHeader.View = headerViewController.View;
            parallaxHeader.Height = 250;
            parallaxHeader.Mode = MXParallaxHeaderMode.Fill;
            parallaxHeader.MinimumHeight = 0;

            ContentViewHeightConstraint.Constant = 1000;
        }
	}
}
