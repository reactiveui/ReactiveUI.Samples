using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using ReactiveUI;

namespace TestApp.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@mipmap/icon",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : ReactiveActivity<ListViewModel>
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_layout);
            
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
            var layoutManager = new LinearLayoutManager(this);
            
            // Get drawable object
            var divider = ContextCompat.GetDrawable(this, Resource.Drawable.divider);
            // Create a DividerItemDecoration whose orientation is Horizontal
            var itemDecoration = new DividerItemDecoration(this, DividerItemDecoration.Horizontal);
            // Set the drawable on it
            itemDecoration.SetDrawable(divider);

            recyclerView.AddItemDecoration(itemDecoration);
            recyclerView.SetLayoutManager(layoutManager);

            ViewModel = new ListViewModel();

            this.WhenActivated(disposable => {
                var adapter = new MoreAdaptor(ViewModel.ListCollection);
                recyclerView.SetAdapter(adapter);
            });
        }
    }
}
