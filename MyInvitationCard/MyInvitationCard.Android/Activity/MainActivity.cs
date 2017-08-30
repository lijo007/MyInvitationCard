using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using MyInvitationCard.Droid.Fragments;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using MyInvitationCard.Droid.Activity;

namespace MyInvitationCard.Droid
{
	[Activity (Label = "MyInvitationCard.Android", Theme = "@style/Theme.DesignDemo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity
	{
        Android.Support.V4.Widget.DrawerLayout drawerLayout;
        NavigationView navigationView;
        private Fragment mCurrentFragment = new Fragment();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            drawerLayout = FindViewById<Android.Support.V4.Widget.DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetupDrawerContent(navigationView);
                navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            }
            ShowHome();

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (sender, e) => {
                //Toast.MakeText(this, "shown toast", ToastLength.Short).Show();
                var intent = new Intent(this, typeof(ScanActivity));
                StartActivity(intent);
            };
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var menuItem = e.MenuItem;
            menuItem.SetChecked(!menuItem.IsChecked);
            drawerLayout.CloseDrawers();

            switch (menuItem.ItemId)
            {
                case Resource.Id.nav_home:
                    Toast.MakeText(Application.Context, "Home selected", ToastLength.Long).Show();
                    break;
                case Resource.Id.nav_messages:
                    Toast.MakeText(Application.Context, "Messages selected", ToastLength.Long).Show();
                    break;
                case Resource.Id.nav_about:
                    Toast.MakeText(Application.Context, "About selected", ToastLength.Long).Show();
                    break;
                case Resource.Id.nav_FeedBack:
                    Toast.MakeText(Application.Context, "FeedBack selected", ToastLength.Long).Show();
                    break;
                default:
                    Toast.MakeText(Application.Context, "Something Wrong", ToastLength.Long).Show();
                    break;

            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public void SetupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }

        public void ShowHome()
        {
            navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);
            HomeFragment fragment = new HomeFragment();
            showFragment(fragment);
        }
        private void showFragment(Fragment fragment)
        {
            FragmentManager.BeginTransaction()
                    .Replace(Resource.Id.container, fragment)
                    .Commit();
        }

    }
}


