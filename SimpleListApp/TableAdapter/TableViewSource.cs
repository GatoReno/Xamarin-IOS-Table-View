using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SimpleListApp.TableAdapter
{
    public class TableViewSource : UITableViewSource
    {
        List<string> tableItems;
        public TableViewSource(List<string> _tableItems)
        {

            tableItems = _tableItems;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("tableViewCell");
            cell.TextLabel.Text = tableItems[indexPath.Row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            // this tell our source how many rows we need now and in the future
            return tableItems.Count;
        }
    }
}
