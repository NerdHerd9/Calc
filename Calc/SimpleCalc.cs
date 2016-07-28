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
        TextView tv, tvAd;                              //tv - main line (TextView). tvAd - Aditional line
        string a;                                       //a - is the first member of operation
        string b;                                       // b - typing new number
        float[] number = new float[0];                  // massive to archive all numbers to operate
        string oper;

        //any number is typed
        void num(int u)          
        {
            //if (tvAd.Text.EndsWith("^2") == false)
            //{
                if (b.Length < 20)
                {
                    b = b + u.ToString();
                    re();
                }
            //}
        }

        //help func for making new member in NumberArray and cleaning b
        void noper()
        {
            Array.Resize<float>(ref number, number.Length + 1);
            number[number.Length - 1] = float.Parse(b);
            b = string.Empty;
        }

        //any operation button is typed
        void operation(string u)
        {
            if (tvAd.Text.Length == 0)
            {
                tvAd.Text = "0" + u;
                Array.Resize<float>(ref number, number.Length + 1);
                number[number.Length - 1] = 0;
            }
            else
            {
                if (b.Length == 0)
                {
                    //if (tvAd.Text.EndsWith("^2") == false)
                    //{
                        oper = oper.Remove(oper.Length - 1);
                        tvAd.Text = tvAd.Text.Remove(a.Length - 1);
                   // }
                }
                else
                    noper();
                tvAd.Text = tvAd.Text + u;
            }
            a = tvAd.Text;
            oper = oper + u;
        }

        //recalc value of aditional line
        void re()
        {
            tvAd.Text = a + b;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SimpleCalc);

            a = b = oper = "";

            //Adding designers objects to code
            tv = FindViewById<TextView>(Resource.Id.tv);
            tvAd = FindViewById<TextView>(Resource.Id.tvAd);
            Button CE = FindViewById<Button>(Resource.Id.CE);
            Button C = FindViewById<Button>(Resource.Id.C);
            Button back = FindViewById<Button>(Resource.Id.back);
            Button slash = FindViewById<Button>(Resource.Id.slash);
            Button x = FindViewById<Button>(Resource.Id.x);
            Button minus = FindViewById<Button>(Resource.Id.minus);
            Button plus = FindViewById<Button>(Resource.Id.plus);
            Button equal = FindViewById<Button>(Resource.Id.equal);
            Button dot = FindViewById<Button>(Resource.Id.dot);
            Button kurL = FindViewById<Button>(Resource.Id.kurL);
            Button kurR = FindViewById<Button>(Resource.Id.kurR);
            Button root = FindViewById<Button>(Resource.Id.root);
            Button square = FindViewById<Button>(Resource.Id.square);
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
                num(0);   
            };
       
            //Button "C" clicked
            C.Click += (object sender, EventArgs e) =>
            {
                a = b = string.Empty;
                re();
                tv.Text = string.Empty;   
            };
        
            //Button backspace "<-" clicked
            back.Click += (object sender, EventArgs e) =>
            {
              //  if (tvAd.Text.EndsWith("^2"))
              //  {
              //     a = a.Remove(a.Length - b.Length - 4);
              //      re();
              //  }
              //  else
              //  {
                    if (b.Length != 0)
                    {
                        b = b.Remove(b.Length - 1);
                        tvAd.Text = tvAd.Text.Remove(tvAd.Text.Length - 1);
                    }
                    else if (number.Length != 0)
                    {
                        b = number[number.Length - 1].ToString();
                        Array.Resize<float>(ref number, number.Length - 1);
                        a = a.Remove(a.Length - b.Length - 1);
                        tvAd.Text = tvAd.Text.Remove(tvAd.Text.Length - 1);
                        oper = oper.Remove(oper.Length - 1);
                    }
               // }
            };

            //Button "," clicked
            dot.Click += (object sender, EventArgs e) =>
            {
                //if (tvAd.Text.EndsWith("^2") == false)
                //{
                    if (b.Length == 0)
                        b = "0,";
                    else if (b.Contains(",") == false)
                        b = b + ",";
                    re();
                //}
            };

            //Button "CE" clicked
            CE.Click += (object sender, EventArgs e) =>
            {
                b = string.Empty;
                re();
            };

            /* n - operation
             * 0 - none operation
             * 1 - "+"
             * 2 - "-"
             * 3 - "*"
             * 4 - "/"
             */
             // Buttons of operations clicked
            plus.Click += (object sender, EventArgs e) => operation("+");
            minus.Click += (object sender, EventArgs e) => operation("-");
            x.Click += (object sender, EventArgs e) => operation("*");
            slash.Click += (object sender, EventArgs e) => operation("/");
            square.Click += (object sender, EventArgs e) => 
            {
                operation("^");

                /*if (tvAd.Text.Length != 0)
                {
                    if (b.Length == 0)
                    {
                        oper = oper.Remove(oper.Length - 1);
                        tvAd.Text = tvAd.Text.Remove(a.Length - 1);
                        b = number[number.Length - 1].ToString();
                        Array.Resize<float>(ref number, number.Length - 1);
                        a = a.Remove(a.Length - b.Length-1);
                    }
                    a = a + "(" + b + ")^2";
                    oper = oper + "s";
                    tvAd.Text = a;
                    noper();
                    //tvAd.Text = tvAd.Text + u;
                }
               //  a = tvAd.Text;*/
            };
            /*equal.Click += (object sender, EventArgs e) =>
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