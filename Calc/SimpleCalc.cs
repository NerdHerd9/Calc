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
    [Activity(Label = "SimpleCalc")]
    public class SimpleCalc : Activity
    {
    /*    float a;                                       //value to count
        TextView tv, tvAd;                              //tv - main line (TextView). tvAd - Aditional line
        int count = 1;                                  //to avoid typing more than 12 symbols
        int n = 0;                                      //number of operation to do
        bool t = false;                                 //to clean in right way and time main line
        bool r = false;                                 //to clean aditional line
        bool sysMes = false;
        string s;

        //for multiple operations
        void swith()
        {
            tvAd.Text = tvAd.Text + tv.Text;           //Adding to the aditional line
            //string s;
            switch (n)
            {
                case 0:
                    a = System.Convert.ToSingle(tv.Text);           //in case of the first oparetion (not multiple)
                    break;
                case 1:
                    a = a + System.Convert.ToSingle(tv.Text);       //in case of "+" operation   
                    tv.Text = a.ToString();
                    break;
                case 2:
                    a = a - System.Convert.ToSingle(tv.Text);       //in case of "-" operation
                    tv.Text = a.ToString();
                    break;
                case 3:
                    a = a * System.Convert.ToSingle(tv.Text);       //in case of "*" operation
                    if (a.ToString()=="бесконечность")
                    {
                        //tvAd.Text = string.Empty;
                       // sysMes = true;
                        t = true;
                        tv.Text = "Too much";
                        count = 0;
                    }
                    else
                        tv.Text = a.ToString();
                    break;
                case 4:
                    if (System.Convert.ToDecimal(tv.Text) != 0)     //in case of "/" operation
                    {
                        a = a / System.Convert.ToSingle(tv.Text);
                        s = Math.Round(a).ToString();    
                        tv.Text = Math.Round(a, 12 - s.Length).ToString();  //rounding the result
                    }
                    else
                    {
                        tv.Text = "error";                          // can't divide by 0
                        count = 0;
                       // sysMes = true;
                        t = true;                                   //to clean main line with next symbol                    
                    }
                    break;
            }
        }

        //what we do when some operation is selected (u - number of operation)
        void operation(int u)
        {
            /*if (sysMes==true)
            {
                tv.Text = string.Empty;
                tvAd.Text = string.Empty;
                tvAd.Text = tvAd.Text + tv.Text;
                r = false;
                sysMes = false;
            }
            
            if (tv.Text != "" && tv.Text!="-")
            {
                if (r != true)
                    swith();
                else
                {
                    tvAd.Text = string.Empty;
                    tvAd.Text = tvAd.Text + tv.Text;
                    r = false;
                }
                t = true;
                n = u;
                a = System.Convert.ToSingle(tv.Text);
                switch (n)
                {
                    case 1:
                        tvAd.Text = tvAd.Text + " + ";
                        break;
                    case 2:
                        tvAd.Text = tvAd.Text + " - ";
                        break;
                    case 3:
                        tvAd.Text = tvAd.Text + " * ";
                        break;
                    case 4:
                        tvAd.Text = tvAd.Text + " / ";
                        break;
                }
            }
            else if (u==2)
                tv.Text = "-";
        }

        //When some number is typed (u - number)
        void num(int u)
        {
            if (t == true)                          //have to clean main line if it is nessesary (t == true)
            {
                tv.Text = string.Empty;
                count = 0;
                t = false;
            }

            if (tv.Text == "0")                     //if main line is just "0" replace it
                tv.Text = u.ToString();
            else if (count != 12)                   //don't allow user to type more than 12 symbols
            {
                tv.Text = tv.Text + u.ToString();
                count++;
            }
        }
*/
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SimpleCalc);

            //Adding designers objects to code
            //tv = FindViewById<TextView>(Resource.Id.tv);
            //tvAd = FindViewById<TextView>(Resource.Id.tvAd);
            Button CE = FindViewById<Button>(Resource.Id.CE);
            Button C = FindViewById<Button>(Resource.Id.C);
            Button back = FindViewById<Button>(Resource.Id.back);
            Button slash = FindViewById<Button>(Resource.Id.slash);
            Button x = FindViewById<Button>(Resource.Id.x);
            Button minus = FindViewById<Button>(Resource.Id.minus);
            Button plus = FindViewById<Button>(Resource.Id.plus);
            Button equal = FindViewById<Button>(Resource.Id.equal);
            Button dot = FindViewById<Button>(Resource.Id.dot);
            Button b1 = FindViewById<Button>(Resource.Id.b1);
            Button b2 = FindViewById<Button>(Resource.Id.b2);
            Button b3 = FindViewById<Button>(Resource.Id.b3);
            Button b4 = FindViewById<Button>(Resource.Id.b4);
            Button b5 = FindViewById<Button>(Resource.Id.b5);
            Button b6 = FindViewById<Button>(Resource.Id.b6);
            Button b7 = FindViewById<Button>(Resource.Id.b7);
            Button b8 = FindViewById<Button>(Resource.Id.b8);
            Button b9 = FindViewById<Button>(Resource.Id.b9);
            Button b0 = FindViewById<Button>(Resource.Id.b0);
/*
            //connecting actions of clicking to numbers with special func
            b1.Click += (object sender, EventArgs e) => num(1);
            b2.Click += (object sender, EventArgs e) => num(2);
            b3.Click += (object sender, EventArgs e) => num(3);
            b4.Click += (object sender, EventArgs e) => num(4);
            b5.Click += (object sender, EventArgs e) => num(5);
            b6.Click += (object sender, EventArgs e) => num(6);
            b7.Click += (object sender, EventArgs e) => num(7);
            b8.Click += (object sender, EventArgs e) => num(8);
            b9.Click += (object sender, EventArgs e) => num(9);
            b0.Click += (object sender, EventArgs e) =>
            {
                if (t == true)
                {
                    tv.Text = string.Empty;
                    count = 0;
                    t = false;
                }
                if (tv.Text != "0" && count != 12)
                {
                    tv.Text = tv.Text + "0";
                    count++;
                }
            };

            //Button "C" clicked
            C.Click += (object sender, EventArgs e) =>
            {
                n = 0;
                tv.Text = string.Empty;
                tvAd.Text = string.Empty;
                count = 0;
            };

            //Button backspace "<-" clicked
            back.Click += (object sender, EventArgs e) =>
            {
                if (count != 0)
                {
                    tv.Text = tv.Text.Remove(count - 1);
                    count--;
                }
            };

            //Button "," clicked
            dot.Click += (object sender, EventArgs e) =>
            {
                if (tv.Text == "")
                {
                    tv.Text = "0";
                    count = 1;
                }
                if (tv.Text.Contains(",") == false)
                {
                    tv.Text = tv.Text + ",";
                    count++;
                }
            };

            //Button "CE" clicked
            CE.Click += (object sender, EventArgs e) =>
            {
                tv.Text = string.Empty;
                count = 0;
            };

            /* n - operation
             * 0 - none operation
             * 1 - "+"
             * 2 - "-"
             * 3 - "*"
             * 4 - "/"
             */
             // Buttons of operations clicked
           /* plus.Click += (object sender, EventArgs e) => operation(1);
            minus.Click += (object sender, EventArgs e) => operation(2);
            x.Click += (object sender, EventArgs e) => operation(3);
            slash.Click += (object sender, EventArgs e) => operation(4);
            equal.Click += (object sender, EventArgs e) =>
            {
                swith();
                tvAd.Text = tvAd.Text + " = ";
                t = true;
                r = true;
                n = 0;
            };*/
        }
    }
}