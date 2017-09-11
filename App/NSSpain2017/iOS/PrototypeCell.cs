namespace NSSpain2017.iOS
{
	using System;
    using Foundation;
    using UIKit;

	public partial class PrototypeCell : UITableViewCell
	{
        Session _session;

        public static readonly NSString Id = new NSString("PrototypeCell");

		public PrototypeCell (IntPtr handle) : base (handle)
		{
		}

		public Session Session
		{
			get
			{
				return _session;
			}
			set
			{
				_session = value;
				RefreshCell();
			}
		}

		void RefreshCell()
		{
			if (Session == null) return;
			if (LblTitle == null) return;

			LblTitle.Text = Session.Title;
            LblSpeakers.Text = Session.SpeakerName;

            LblStartTime.Text = Session.FormatStartTime();
            LblDuration.Text = Session.FormatDuration();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			RefreshCell();
		}
	}
}
