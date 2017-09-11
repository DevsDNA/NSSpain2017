namespace NSSpain2017.Droid.Fragments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Android.Support.V7.Widget;
    using Android.Views;
    using Android.Widget;
    using SectionedRecyclerview.Droid;
    using static Android.Views.View;

    public class Adapter : SectionedRecyclerViewAdapter
    {
        Dictionary<string, List<Session>> dataSet;
        MyClickListener clickListener;

		public Adapter(Dictionary<string, List<Session>> dataSet, MyClickListener clickListener)
		{
			this.dataSet = dataSet;
            this.clickListener = clickListener;
		}

		public override int SectionCount => dataSet?.Count() ?? 0;

		public override int GetItemCount(int p0)
		{
			return dataSet.ElementAt(p0).Value.Count();
		}

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            int layoutRes;

            switch (viewType)
            {
                case ViewTypeHeader:
                    layoutRes = Resource.Layout.session_header;
                    break;
                default:
                    layoutRes = Resource.Layout.session_cell;
                    break;
            }

            var view = LayoutInflater.From(parent.Context).Inflate(layoutRes, parent, false);
            var viewHolder = new ViewHolder(view, clickListener);

            return viewHolder;
		}

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var coords = GetRelativePosition(position);

            switch (holder.ItemViewType)
			{
				case ViewTypeHeader:
                    {
                        var item = dataSet.ElementAt(coords.Section());
                        var actualHolder = holder as ViewHolder;
                        actualHolder.DisableClick();
                        var dayTextView = actualHolder.ItemView.FindViewById<TextView>(Resource.Id.DayTextView);
                        dayTextView.SetText(item.Key, TextView.BufferType.Normal);
                        break;
                    }
				default:
                    {
                        var item = dataSet.ElementAt(coords.Section()).Value[coords.RelativePos()];
                        var actualHolder = holder as ViewHolder;
                        actualHolder.TitleTextView.SetText(item.Title, TextView.BufferType.Normal);
                        actualHolder.StartDateTextView.SetText(item.FormatStartTime(), TextView.BufferType.Normal);
                        actualHolder.DurationTextView.SetText(item.FormatDuration(), TextView.BufferType.Normal);
                        actualHolder.SpeakersTextView.SetText(item.SpeakerName, TextView.BufferType.Normal);
                        break;
                    }
			}
        }

        public override void OnBindHeaderViewHolder(Java.Lang.Object p0, int p1, bool p2)
        {
            // Intentionally blank
        }

        public override void OnBindViewHolder(Java.Lang.Object p0, int p1, int p2, int p3)
        {
			// Intentionally blank
        }
    }
}
