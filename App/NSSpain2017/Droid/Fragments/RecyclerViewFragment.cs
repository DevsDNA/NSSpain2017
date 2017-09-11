namespace NSSpain2017.Droid
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Support.V7.Widget;
    using Android.Views;
    using NSSpain2017.Droid.Activities;

    public class RecyclerViewFragment : Fragment, MyClickListener
    {
		const string TAG = "RecycleViewFragment";
		
        DataProvider _dataProvider;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			_dataProvider = new DataProvider();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.recyclerview_fragment, container, false);
            rootView.SetTag(rootView.Id, TAG);

            var recyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            var layoutManager = new LinearLayoutManager(Activity);
            recyclerView.SetLayoutManager(layoutManager);
            var sessionsGrouped = _dataProvider.GetSessionsGrouped();
            var adapter = new Fragments.Adapter(sessionsGrouped, this);
            recyclerView.SetAdapter(adapter);

            return rootView;
        }

        void MyClickListener.OnItemClick(int position, View v)
        {
			var intent = new Intent(Activity, typeof(DetailActivity));
            intent.PutExtra("position", position);
			StartActivity(intent);
        }
    }

	public interface MyClickListener
	{
		void OnItemClick(int position, View v);
	}
}
