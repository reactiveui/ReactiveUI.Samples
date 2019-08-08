using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using TestApp.DataModels;

namespace TestApp
{
    public class ListViewModel : BaseViewModel
    {

        private readonly SourceList<ListItemDataModel> _items = new SourceList<ListItemDataModel>();

        public IObservable<IChangeSet<ListItemViewModel>> ListCollection { get; }
        public IObservable<IChangeSet<ListItemViewModel>> SelectedItems { get; }

        public ListViewModel()
        {

            var navigationSortExpressionComparer = SortExpressionComparer<ListItemDataModel>
                .Ascending(p => p.Group)
                .ThenByAscending(p => p.Order);

//            this.WhenActivated(disposable =>
//            {
            var obs = _items
                .Connect()
                .Sort(navigationSortExpressionComparer)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Transform(
                    model => new
                        ListItemViewModel(model))
                .Publish();

            ListCollection = obs;

            SelectedItems = obs.Filter(x => x.IsSelected);

            obs.Connect();

            _items.AddRange(GetFirstDataSet());

            Task.Run(() =>
            {
                var firstList = GetFirstDataSet();
                _items.EditDiff(firstList);

                Thread.Sleep(5000);
                var nextList = GetSecondList();
                nextList.AddRange(GetFirstDataSet());
                _items.EditDiff(nextList);
            }).ConfigureAwait(false);
//            });
        }

        List<ListItemDataModel> GetFirstDataSet()
        {
            var theList = new List<ListItemDataModel>();
            
            theList.Add(new ListItemDataModel()
            {
                Name = "Pureween",
                Order = 1,
                Group = 2
            });
            
            theList.Add(new ListItemDataModel()
            {
                Name = "Clinton",
                Order = 2,
                Group = 1
            });
            
            theList.Add(new ListItemDataModel()
            {
                Name = "Glenn",
                Order = 1,
                Group = 1
            });

            theList.Add(new ListItemDataModel()
            {
                Name = "Geoff",
                Order = 2,
                Group = 2
            });

            return theList;
        }
        
        List<ListItemDataModel> GetSecondList()
        {
            var theList = new List<ListItemDataModel>();
            theList.Add(new ListItemDataModel()
            {
                Name = "Kent",
                Order = 6,
                Group = 1
            });
            
            theList.Add(new ListItemDataModel()
            {
                Name = "Anais",
                Order = 0,
                Group = 1
            });
            
            theList.Add(new ListItemDataModel()
            {
                Name = "Cody",
                Order = 3,
                Group = 2
            });

            theList.Add(new ListItemDataModel()
            {
                Name = "Geoff",
                Order = 2,
                Group = 2
            });

            return theList;
        }
        
    }
}
