// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in the XCode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UI
{
	[Register ("Modal")]
	partial class Modal
	{
		[Outlet]
		AppKit.NSButton DismissButton { get; set; }

		[Outlet]
		AppKit.NSTextField TimerLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DismissButton != null) {
				DismissButton.Dispose ();
				DismissButton = null;
			}

			if (TimerLabel != null) {
				TimerLabel.Dispose ();
				TimerLabel = null;
			}

		}
	}
}
