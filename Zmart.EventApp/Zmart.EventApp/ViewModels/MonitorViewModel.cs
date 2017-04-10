using Acr;
using Estimotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zmart.EventApp.ViewModels
{
    class MonitorViewModel : LifecycleViewModel
    {

        public MonitorViewModel()
        {
            this.Refresh = new Command(() => {
                this.IsRefreshing = true;
                this.LoadData();
                this.IsRefreshing = false;
            });
        }


        public override void OnActivate()
        {
            base.OnActivate();
            this.LoadData();
            EstimoteManager.Instance.RegionStatusChanged += this.OnBeaconRegionStatusChanged;
        }


        public override void OnDeactivate()
        {
            base.OnDeactivate();
            EstimoteManager.Instance.RegionStatusChanged -= this.OnBeaconRegionStatusChanged;
        }


        async void OnBeaconRegionStatusChanged(object sender, BeaconRegionStatusChangedEventArgs e)
        {
            await Task.Delay(500); // let data get logged on App.cs first
            this.LoadData();
        }


        private void LoadData()
        {
            this.List = App
                .Data
                .BeaconPings
                .OrderByDescending(x => x.DateCreated)
                .ToList()
                .Select(x => new MonitoredViewModel(x));
            this.OnPropertyChanged("List");
        }


        public ICommand Refresh { get; }


        private bool refreshing;
        public bool IsRefreshing
        {
            get { return this.refreshing; }
            private set { this.SetProperty(ref this.refreshing, value); }
        }


        public IEnumerable<MonitoredViewModel> List { get; private set; }
    }
}
