using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using CoreGraphics;
using DynamicData;
using Foundation;
using ReactiveUI;
using UIKit;

namespace TestApp.iOS
{
    public class MainViewController : ReactiveTableViewController<ListViewModel>
    {
        public MainViewController()
        {
            ViewModel = new ListViewModel();

            this.WhenActivated(disposable =>
            {
                TableView.Delegate = this;
                TableView.RegisterClassForCellReuse(typeof(BaseCell), BaseCell.Key);

                IObservable<IVirtualRequest> request = Observable.Return(new VirtualRequest(4, 255));

                new SourceList<ListItemViewModel>(ViewModel.ListCollection)
                    .Connect()
                    .Filter(i => i.Group == 0)
                    .Bind(out var topCollection)
                    .Subscribe()
                    .DisposeWith(disposable);

                new SourceList<ListItemViewModel>(ViewModel.ListCollection)
                    .Connect()
                    .Filter(i => i.Group == 1)
                    .Virtualise(request)
                    .Bind(out var dynamicCollection)
                    .Subscribe()
                    .DisposeWith(disposable);

                new SourceList<ListItemViewModel>(ViewModel.ListCollection)
                    .Connect()
                    .Filter(i => i.Group == 2)
                    .Bind(out var bottomCollection)
                    .Subscribe()
                    .DisposeWith(disposable);

                new SourceList<ListItemViewModel>(ViewModel.ListCollection)
                    .Connect()
                    .Filter(i => i.Group == 3)
                    .Bind(out var syncCollection)
                    .Subscribe()
                    .DisposeWith(disposable);

                var sizeHint = 56f;

                var top = new TableSectionInformation<ListItemViewModel, SimpleCell>(topCollection,
                    BaseCell.Key,
                    sizeHint,
                    cell => cell.SetupViews());
                var dynamic = new TableSectionInformation<ListItemViewModel, SimpleCell>(dynamicCollection,
                    BaseCell.Key,
                    sizeHint,
                    cell => cell.SetupViews());
                var bottom = new TableSectionInformation<ListItemViewModel, SimpleCell>(bottomCollection,
                    BaseCell.Key,
                    sizeHint,
                    cell => cell.SetupViews());
                var sync = new TableSectionInformation<ListItemViewModel, SimpleCell>(syncCollection,
                    BaseCell.Key,
                    sizeHint,
                    cell => cell.SetupViews());

                var sectionCollection = new TableSectionInformation<ListItemViewModel>[]
                {
                    top,
                    dynamic,
                    bottom,
                    sync
                };

                var tableSource = new MoreTableSource<ListItemViewModel>(TableView)
                    {Data = sectionCollection};
                TableView.Source = tableSource;
            });
        }
    }
    
    public class SimpleCell : BaseCell {

        UILabel _description;

        UILabel DescriptionLabel {
            get {
                if (_description == null) {
                    _description = new UILabel();
                    _description.TextColor = new UIColor(red: 0.13f, green: 0.19f, blue: 0.29f, alpha: 1.0f);;
                    _description.Font.WithSize(16);
                    _description.Lines = 1;
                }
                return _description;
            }
        }

        protected override void SetupBindings() {
            this.WhenAnyValue(view => view.ViewModel.FullName)
                .BindTo(this,
                    cell => cell.DescriptionLabel.Text);
        }

        public override void SetupViews() {
            ContentView.AddSubview(DescriptionLabel);
        }

        public override void LayoutSubviews() {
            base.LayoutSubviews();

            var width = ContentView.Frame.Width;
            var margin = 8;

            DescriptionLabel.Frame = new CGRect(margin, margin - 1, 200, 24);

        }
    }
    
    public abstract class BaseCell : ReactiveTableViewCell<ListItemViewModel> {

        public BaseCell() {
            SetupViews();
        }

        public BaseCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            // Note: this .ctor should not contain any initialization logic.
        }


        public override void LayoutSubviews() {
            base.LayoutSubviews();
            SetupBindings();
        }

        protected abstract void SetupBindings();

        public abstract void SetupViews();

        public static NSString Key => new NSString("key");
    }
    
     public class MoreTableSource<TViewModel> : ReactiveTableViewSource<TViewModel> {

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath) {
            var viewModel = GetViewModel(indexPath);

            return 56f;
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section) {
            return 6f;
        }

        public override nfloat GetHeightForFooter(UITableView tableView, nint section) {
            if (Data.Count - 1 == section) {
                        return base.GetHeightForFooter(tableView, section);
                //return 66f;
            }
            return 0f;
            return base.GetHeightForFooter(tableView, section);
        }


        ListItemViewModel GetViewModel(NSIndexPath indexPath) {
            var data = Data[indexPath.Section]?.Collection as ReadOnlyObservableCollection<ListItemViewModel>;
            return data?[indexPath.Row];
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var viewModel = GetViewModel(indexPath);
            BaseCell cell;
            cell = new SimpleCell();
            cell.ViewModel = viewModel;
            return cell;
        }

        public MoreTableSource(UITableView tableView)
            : base(tableView) {
        }
    }
    
}