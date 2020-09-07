using System;
using UIKit;
using Foundation;
using CoreGraphics;
namespace SimpleListApp.TableAdapter
{
    public class MyCustomCell: UITableViewCell
    {
        UILabel headingLbk, subheadingLbl;
        public MyCustomCell(NSString cellId) : base (UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            ContentView.BackgroundColor = UIColor.DarkGray;

            headingLbk = new UILabel() {
                Font = UIFont.FromName("AmericanTypewriter", 17f),
                TextColor = UIColor.White,
                //BackgroundColor = UIColor.Black
            };

            subheadingLbl = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypewriter", 12f),
                TextColor = UIColor.White,
                //TextAlignment = UITextAlignment.Center,
               // BackgroundColor = UIColor.Gray
            };

            ContentView.AddSubviews(new UIView[] { headingLbk, subheadingLbl });

           
        }

        public void UpdateCell(string _headingLbk, string _subheadingLbl)
        {
            headingLbk.Text = _headingLbk;
            subheadingLbl.Text = _subheadingLbl;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            headingLbk.Frame = new CGRect(5, 4, ContentView.Bounds.Width, 25);
            subheadingLbl.Frame = new CGRect(100,22,100,25);
        }

    }
}
