namespace NSSpain2017.Droid.Activities
{
	using Android.App;
	using Android.OS;
    using Android.Widget;

    [Activity(Label = "Detail", Theme = "@android:style/Theme.Material.Light")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.detail_activity);

            if (Intent.Extras != null)
            {
				var position = Intent.Extras.GetInt("position");
                var dataProvider = new DataProvider();
                var session = dataProvider.RealmInstance.Find<Session>(position - 1);

                var detailTitleTextView = FindViewById<TextView>(Resource.Id.DetailTitleTextView);
                detailTitleTextView.Text = session.Title;

                var descriptionTextView = FindViewById<TextView>(Resource.Id.DescriptionTextView);
                descriptionTextView.Text = session.Subtitle;

                var speakersTextView = FindViewById<TextView>(Resource.Id.DescriptionSpeakersTextView);
                speakersTextView.Text = session.FormatSpeaker(prependMicrophone: true);
            }
        }
    }
}
