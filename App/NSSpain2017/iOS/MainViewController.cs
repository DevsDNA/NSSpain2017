namespace NSSpain2017.iOS
{
	using System;
    using System.Linq;
    using UIKit;

	public partial class MainViewController : UIViewController
	{
        ScheduleTableViewSource _scheduleDataSource;

        DataProvider _dataProvider;

		public MainViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _dataProvider = new DataProvider();

            _scheduleDataSource = new ScheduleTableViewSource(_dataProvider.Sessions.ToList(), this);

            TableView.Source = _scheduleDataSource;
			TableView.RowHeight = UITableView.AutomaticDimension;
			TableView.EstimatedRowHeight = 80f;
			TableView.ReloadData();

            Title = "NSSpain 2017";
        }
	}
}
