namespace NSSpain2017.Droid.Activities
{
    using Android.App;
    using Android.OS;

    [Activity(Label = "NSSpain 2017", MainLauncher = true, Icon = "@mipmap/icon",
              Theme = "@android:style/Theme.Material.Light")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main_activity);

            if (savedInstanceState == null)
            {
                var transaction = FragmentManager.BeginTransaction();
                var fragment = new RecyclerViewFragment();
                transaction.Replace(Resource.Id.MainFrameLayout, fragment);
                transaction.Commit();
            }
        }
    }
}

