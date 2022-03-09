using System.Reactive;
using ReactiveUI;

namespace WinForms.Reactive.Client.Interactions;

public static class MessageInteractions
{
	public static Interaction<string, Unit> ShowMessage { get; } = new Interaction<string, Unit>();
	public static Interaction<string, bool> AskConfirmation { get; } = new Interaction<string, bool>();
}
