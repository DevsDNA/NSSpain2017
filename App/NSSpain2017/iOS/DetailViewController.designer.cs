// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace NSSpain2017.iOS
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.NSLayoutConstraint ContentViewHeightConstraint { get; set; }

		[Outlet]
		UIKit.UILabel LblSpeakers { get; set; }

		[Outlet]
		UIKit.UILabel LblTitle { get; set; }

		[Outlet]
		UIKit.UIScrollView ScrollView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ContentViewHeightConstraint != null) {
				ContentViewHeightConstraint.Dispose ();
				ContentViewHeightConstraint = null;
			}

			if (LblTitle != null) {
				LblTitle.Dispose ();
				LblTitle = null;
			}

			if (ScrollView != null) {
				ScrollView.Dispose ();
				ScrollView = null;
			}

			if (LblSpeakers != null) {
				LblSpeakers.Dispose ();
				LblSpeakers = null;
			}
		}
	}
}
