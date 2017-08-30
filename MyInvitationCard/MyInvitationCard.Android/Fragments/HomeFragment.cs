using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Net.NetworkInformation;
using MyInvitationCard.Droid.com.w3schools.www;
using MyInvitationCard.Droid.com.webservicex.www;
using Android.Support.Design.Widget;

namespace MyInvitationCard.Droid.Fragments
{
    public class HomeFragment : Fragment
    {

        EditText edtxt;
        TextView edtxtResult;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             View view= inflater.Inflate(Resource.Layout.view_home, container, false);
            edtxt = view.FindViewById<EditText>(Resource.Id.editText1);
            edtxtResult = view.FindViewById<TextView>(Resource.Id.result);
            Button btn = view.FindViewById<Button>(Resource.Id.button1);
            btn.Click += Btn_Click;

            //var fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fab.Click += (sender, e) => {
            //    Toast.MakeText(this.Context, "shown toast", ToastLength.Short).Show();
            //};
            return view;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            bool check = NetworkInterface.GetIsNetworkAvailable();
            if (check)
            {
                //TempConvert mTempConvertClient = new TempConvert();
                //mTempConvertClient.FahrenheitToCelsiusAsync(edtxt.Text);
                //mTempConvertClient.FahrenheitToCelsiusCompleted += MTempConvertClient_FahrenheitToCelsiusCompleted;

                GlobalWeather gw = new GlobalWeather();
                gw.GetCitiesByCountryAsync(edtxt.Text);
                gw.GetCitiesByCountryCompleted += Gw_GetCitiesByCountryCompleted;

            }
            else
            {
                return;
            }
        }

        private void Gw_GetCitiesByCountryCompleted(object sender, GetCitiesByCountryCompletedEventArgs e)
        {
            edtxtResult.Text += e.Result;
        }


        //private void MTempConvertClient_FahrenheitToCelsiusCompleted(object sender, FahrenheitToCelsiusCompletedEventArgs e)
        //{
        //    edtxtResult.Text += e.Result;
        //}
    }
}