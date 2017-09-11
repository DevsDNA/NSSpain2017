namespace NSSpain2017.Droid.Fragments
{
    using Android.Views;
    using Android.Widget;
    using SectionedRecyclerview.Droid;
    using static Android.Views.View;

    public class ViewHolder : SectionedViewHolder, IOnClickListener
	{
		TextView titleTextView;
		MyClickListener clickListener;
		TextView startDateTextView;
		TextView durationTextView;
		TextView speakersTextView;

		public ViewHolder(View v, MyClickListener clickListener) : base(v)
		{
			this.clickListener = clickListener;

			titleTextView = v.FindViewById<TextView>(Resource.Id.TitleTextView);
			startDateTextView = v.FindViewById<TextView>(Resource.Id.StartDateTextView);
			durationTextView = v.FindViewById<TextView>(Resource.Id.DurationTextView);
			speakersTextView = v.FindViewById<TextView>(Resource.Id.SpeakersTextView);

			v.SetOnClickListener(this);
		}

		public TextView StartDateTextView => startDateTextView;

		public TextView DurationTextView => durationTextView;

		public TextView TitleTextView => titleTextView;

		public TextView SpeakersTextView => speakersTextView;

		internal void DisableClick()
		{
			clickListener = null;
		}

		void IOnClickListener.OnClick(View v)
		{
			clickListener?.OnItemClick(AdapterPosition, v);
		}
	}
}
