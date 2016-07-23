using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Calc
{
    [Activity(Label = "ComplexCalc")]
    public class ComplexCalc : Activity
    {
        EditText xEditText;
        EditText yEditText;
        EditText modZEditText;
        EditText argZEditText;
        TextView test;

        decimal x;
        decimal y;
        decimal modZ;
        decimal argZ;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ComplexCalc);
            xEditText = FindViewById<EditText>(Resource.Id.xEditText);
            yEditText = FindViewById<EditText>(Resource.Id.yEditText);
            modZEditText = FindViewById<EditText>(Resource.Id.modZEditText);
            argZEditText = FindViewById<EditText>(Resource.Id.argZEditText);
            test = FindViewById<TextView>(Resource.Id.test);

            xEditText.KeyPress += onClick;
            yEditText.KeyPress += onClick;
            modZEditText.KeyPress += onClick;
            argZEditText.KeyPress += onClick;
        }
        public void onClick(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                string tmpA = "0";
                string tmpB = "0";
                EditText edITTMP = (EditText)sender;
                

                if (edITTMP.Id == Resource.Id.xEditText ||
                    edITTMP.Id == Resource.Id.yEditText)
                {
                    if (xEditText.Text != "")
                    {
                        tmpA = xEditText.Text;
                    }
                    if (yEditText.Text != "")
                    {
                        tmpB = yEditText.Text;
                    }
                    x = decimal.Parse(tmpA);
                    y = decimal.Parse(tmpB);
                    modZ = (decimal)Math.Sqrt((double)(x * x + y * y));
                    argZ = (decimal)(Math.Atan2((double)y, (double)x) * (180 / Math.PI));
                    modZEditText.Text = modZ.ToString();
                    argZEditText.Text = argZ.ToString();
                }
                else if (edITTMP.Id == Resource.Id.modZEditText ||
                         edITTMP.Id == Resource.Id.argZEditText)
                {
                    if (modZEditText.Text != "")
                    {
                        tmpA = modZEditText.Text;
                    }
                    if (argZEditText.Text != "")
                    {
                        tmpB = argZEditText.Text;
                    }
                    modZ = decimal.Parse(tmpA);
                    argZ = decimal.Parse(tmpB);
                    x = modZ * (decimal)Math.Cos((double)argZ * Math.PI / 180);
                    y = modZ * (decimal)Math.Sin((double)argZ * Math.PI / 180);
                    xEditText.Text = x.ToString();
                    yEditText.Text = y.ToString();
                }
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
