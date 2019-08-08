using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DynamicData;
using ReactiveUI;
using ReactiveUI.AndroidSupport;
using ControlFetcherMixin = ReactiveUI.AndroidSupport.ControlFetcherMixin;

namespace TestApp.Droid
{
    public class MoreAdaptor : ReactiveRecyclerViewAdapter<ListItemViewModel>
    {
        public MoreAdaptor(IObservable<IChangeSet<ListItemViewModel>> backingList) : base(backingList)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view3 = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.standard_cell, parent, false);
            var holder = new MoreStandardViewHolder(view3);
            return holder;
        }
        
        class MoreStandardViewHolder : ReactiveRecyclerViewViewHolder<ListItemViewModel> {

            [WireUpResource]
            public TextView MoreStandardText { get; set; }

            public MoreStandardViewHolder(View view)
                : base(view) {
                this.WireUpControls();

                this.OneWayBind(this.ViewModel, viewModel => viewModel.FullName,
                    thisView => thisView.MoreStandardText.Text,
                    view.Context);
            }
        }
        
    }
}