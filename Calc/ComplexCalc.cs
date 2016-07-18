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
        EditText aEditText;
        EditText bEditText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ComplexCalc);
            aEditText = FindViewById<EditText>(Resource.Id.aEditText);
            bEditText = FindViewById<EditText>(Resource.Id.bEditText);
        }
    }
}