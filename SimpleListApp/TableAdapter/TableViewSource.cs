using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace SimpleListApp.TableAdapter
{
    public class TableViewSource : UITableViewSource
    {
        List<string> tableItems;
        Dictionary<string, List<string>> indexTableItems;
        string[] keys;
        public TableViewSource(List<string> _tableItems)
        {

            tableItems = _tableItems;
            indexTableItems = new Dictionary<string, List<string>>();

            foreach (var t in tableItems)
            {
                if (indexTableItems.ContainsKey(t[0].ToString()))
                {
                    indexTableItems[t[0].ToString()].Add(t);
                }
                else
                {
                    indexTableItems.Add(t[0].ToString(), new List<string>() { t });
                }

            }

            keys = indexTableItems.Keys.ToArray();
        }
        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }
      
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            // this tell our source how many rows we need now and in the future
            //return tableItems.Count;

            //using dictionary
            return indexTableItems[keys[section]].Count();

        }

        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return keys;
        }

        public override async void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            await Task.Delay(500);
            tableView.DeselectRow(indexPath, true);
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 165f;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return keys[section];
        }
        /*
        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var view = new UIView(CoreGraphics.CGRect(0, 0, tableView.Bounds.Width, 44f));
        }
        */
        public override string TitleForFooter(UITableView tableView, nint section)
        {
            return "end section";
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // no custom
            //var cell = tableView.DequeueReusableCell("tableViewCell");
            //cell.TextLabel.Text = tableItems[indexPath.Row]; //
            //custom
           
            var cell = tableView.DequeueReusableCell("tableViewCell") as MyCustomCell;
            if (cell == null)
            {
                cell = new MyCustomCell(new Foundation.NSString("tableViewCell"));
            }

            //cell.UpdateCell(tableItems[indexPath.Row], tableItems[indexPath.Row]);
            //using dictionary

            cell.UpdateCell(indexTableItems[keys[indexPath.Section]][indexPath.Row],"Place holder 💀");

            return cell;
        }

    }
}
