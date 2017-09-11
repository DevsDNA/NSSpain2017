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
	[Register ("PrototypeCell")]
	partial class PrototypeCell
	{
		[Outlet]
		UIKit.UILabel LblDuration { get; set; }

		[Outlet]
		UIKit.UILabel LblSpeakers { get; set; }

		[Outlet]
		UIKit.UILabel LblStartTime { get; set; }

		[Outlet]
		UIKit.UILabel LblTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblTitle != null) {
				LblTitle.Dispose ();
				LblTitle = null;
			}

			if (LblSpeakers != null) {
				LblSpeakers.Dispose ();
				LblSpeakers = null;
			}

			if (LblStartTime != null) {
				LblStartTime.Dispose ();
				LblStartTime = null;
			}

			if (LblDuration != null) {
				LblDuration.Dispose ();
				LblDuration = null;
			}
		}
	}
}
