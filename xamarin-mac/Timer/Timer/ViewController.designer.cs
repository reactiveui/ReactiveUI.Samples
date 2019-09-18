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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField TimeEntryField { get; set; }

		[Outlet]
		AppKit.NSButton TimerButton { get; set; }

		[Outlet]
		AppKit.NSTextField TimerLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (TimeEntryField != null) {
				TimeEntryField.Dispose ();
				TimeEntryField = null;
			}

			if (TimerButton != null) {
				TimerButton.Dispose ();
				TimerButton = null;
			}

			if (TimerLabel != null) {
				TimerLabel.Dispose ();
				TimerLabel = null;
			}

		}
	}
}
