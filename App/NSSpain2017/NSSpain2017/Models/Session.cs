namespace NSSpain2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Realms;

    public class Session : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Ignored]
        public string Subtitle => "Aenean lobortis efficitur lorem, in interdum erat pellentesque feugiat. Phasellus eu ultrices erat. Nam laoreet ligula ut mauris suscipit lobortis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc id feugiat diam. \n\nDonec mollis felis dolor, vel laoreet magna ultricies ut. Donec porta orci libero, vel pellentesque libero tempus vitae. Morbi condimentum cursus eleifend. Duis efficitur enim ullamcorper, condimentum magna at, iaculis est. Sed tincidunt eleifend lectus, nec dictum nibh. Integer in ipsum sed enim lobortis porttitor eget eget ligula. \n\nMaecenas in sem nibh. Integer magna sem, lacinia vitae mi sed, cursus volutpat elit. Phasellus quis libero nec odio lacinia fringilla.";

        public IList<Speaker> Speakers { get; }

        [JsonProperty(PropertyName = "speaker_name")]
        public string SpeakerName { get; set; }

		[JsonProperty(PropertyName = "speaker_position")]
		public string SpeakerPosition { get; set; }

		[JsonProperty(PropertyName = "start_time")]
		public string StartTime { get; set; }

		[JsonProperty(PropertyName = "end_time")]
		public string EndTime { get; set; }

		[JsonProperty(PropertyName = "duration")]
		public string Duration { get; set; }

		[JsonProperty(PropertyName = "day")]
		public string Day { get; set; }
    }

    public static class SessionExtensions
    {
        public static string FormatSpeaker(this Session session, bool prependMicrophone = false)
        {
            if (string.IsNullOrWhiteSpace(session.SpeakerName))
                return "-";

            var result = session.SpeakerName;

            if (prependMicrophone)
                result = result.Insert(0, "\ud83c\udfa4 ");

            return result;
        }

        public static string FormatDuration(this Session session)
        {
            if (session == null || string.IsNullOrWhiteSpace(session.Duration))
				return string.Empty;

            var result = session.Duration;

            if (char.IsLetter(result, result.Length - 1))
                result = result.Insert(result.Length - 1, " ");

            return result;
        }

		public static string FormatStartTime(this Session session)
		{
			if (session == null)
				return "-";

            var result = session.StartTime.Insert(2, ":");

			return result;
		}
    }
}
