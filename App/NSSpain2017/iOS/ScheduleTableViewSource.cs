namespace NSSpain2017.iOS
{
    using System.Collections.Generic;
    using System.Linq;
    using UIKit;
    
    public class ScheduleTableViewSource : UITableViewSource
    {
		List<Session> Sessions;
        List<string> Sections;

        UIViewController _parentView;

        public ScheduleTableViewSource(List<Session> sessions, MainViewController parentView)
        {
            Sessions = sessions;
            Sections = Sessions.Select(s => s.Day).ToHashSet().ToList();
            _parentView = parentView;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(PrototypeCell.Id, indexPath) as PrototypeCell;

            cell.Session = GetItem(tableView, indexPath);

			return cell;
        }

        public override System.nint RowsInSection(UITableView tableview, System.nint section)
        {
            return Sessions.Count(s => s.Day == TitleForHeader(tableview, section));
        }

        public override System.nint NumberOfSections(UITableView tableView)
        {
            return Sections.Count();
        }

        public override string TitleForHeader(UITableView tableView, System.nint section)
        {
            return Sections[(int)section];
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var detailViewController = (DetailViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("detailViewController");
            detailViewController.Session = GetItem(tableView, indexPath);

            _parentView.NavigationController.PushViewController(detailViewController, true);

            tableView.DeselectRow(indexPath, true);
        }

        Session GetItem(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            return Sessions.Where(s => s.Day == TitleForHeader(tableView, indexPath.Section)).ElementAt(indexPath.Row);
        }
    }
}
