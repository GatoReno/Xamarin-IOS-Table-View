using Foundation;
using SimpleListApp.TableAdapter;
using System;
using System.Collections.Generic;
using UIKit;

namespace SimpleListApp
{
    public partial class ViewController : UIViewController
    {

        List<string> tItems;

        public ViewController(IntPtr handle) : base(handle)
        {
            tItems = new List<string>();
            for (int i = 0; i < 30; i++)
            {
                tItems.Add($"My i value: {i}");
            }

         }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            tableView.Source = new TableViewSource(tItems);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}