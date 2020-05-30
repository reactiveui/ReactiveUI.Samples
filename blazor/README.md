# ReactiveUI Blazor Samples

1. [Server Side Example](ServerSideExample) - Blazor on the Server uses SignalR maintain client connections and is fully supported by Microsoft.  This sample implements ReactiveUI Viewmodels over the standard Microsoft template.

2. [Client Side Example](ClientSideExample) - Blazor running in the browser via WASM is now fully supported!  This sample implements ReactiveUI Viewmodels over the standard Microsoft template.

3. [AspNetCore Hosted](HostedExample) - This is Blazor running in the browser via WASM.  The wasm-based SPA is hosted by an AspNetCore site.  This sample implements ReactiveUI Viewmodels over the standard Microsoft template.

You can follow the [Blazor tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/build-your-first-blazor-app?view=aspnetcore-3.1&tabs=visual-studio) on MSDN to get started. Heavily based on [@akourbat's work](https://github.com/akourbat/SampleRazorComponentsApp).

All samples now work with VS and VS Code debugging, although please bear in mind for Client and Hosted - ie, `wasm`-based, you'll need to start the project in debug mode **before** adding your breakpoints!
