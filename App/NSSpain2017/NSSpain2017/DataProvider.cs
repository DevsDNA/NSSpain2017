namespace NSSpain2017
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Realms;

    public class DataProvider
    {
        bool hasToReload = true;

        public DataProvider()
        {
            var config = new RealmConfiguration { SchemaVersion = 4 };
            RealmInstance = Realm.GetInstance(config);

            if(hasToReload)
            {
				CleanRealmDatabase();
				FillRealmDatabase();   
            }
        }

        public IQueryable<Session> Sessions => RealmInstance.All<Session>();
        public Realm RealmInstance { get; set; }

		public Dictionary<string, List<Session>> GetSessionsGrouped()
		{
			var sessionsGrouped = new Dictionary<string, List<Session>>();

			foreach (var session in Sessions)
			{
				if (sessionsGrouped.ContainsKey(session.Day))
					sessionsGrouped[session.Day].Add(session);
				else
				{
					var list = new List<Session>();
					list.Add(session);
					sessionsGrouped.Add(session.Day, list);
				}
			}

			return sessionsGrouped;
		}

        void CleanRealmDatabase()
        {
            using(var trans = RealmInstance.BeginWrite())
            {
                RealmInstance.RemoveAll<Speaker>();
                RealmInstance.RemoveAll<Session>();
                trans.Commit();
            }
        }

		void FillRealmDatabase()
		{

            var jsonString = "{\"sessions\":[{\"title\":\"\ud83c\udfaf Registration\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"0830\",\"end_time\":\"0900\",\"duration\":\"30m\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"Supercharge your iOS development workflow with Buddybuild\",\"speaker_name\":\"Chris Stott Buddybuild\",\"speaker_position\":\"Buddybuild\",\"start_time\":\"0900\",\"end_time\":\"1100\",\"duration\":\"2h\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"☕️ Coffee Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1100\",\"end_time\":\"1130\",\"duration\":\"30m\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"Hands on Implementation of Clean Architecture for iOS Apps\",\"speaker_name\":\"Jorge Ortiz PoWWaU\",\"speaker_position\":\"PoWWaU\",\"start_time\":\"1130\",\"end_time\":\"1330\",\"duration\":\"2h\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"\ud83c\udf7d Lunch Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1330\",\"end_time\":\"1500\",\"duration\":\"1'5h\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"Hands on Implementation of Clean Architecture for iOS Apps\",\"speaker_name\":\"Jorge Ortiz PoWWaU\",\"speaker_position\":\"PoWWaU\",\"start_time\":\"1500\",\"end_time\":\"1600\",\"duration\":\"1h\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"☕️ Coffee Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1600\",\"end_time\":\"1620\",\"duration\":\"20m\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"Framework Oriented Apps\",\"speaker_name\":\"Pedro Piñera SoundCloud & GitDo\",\"speaker_position\":\"SoundCloud & GitDo\",\"start_time\":\"1620\",\"end_time\":\"1830\",\"duration\":\"2h\",\"day\":\"Sep 14 - \ud83d\udc23 Workshops day\"},{\"title\":\"\ud83c\udfaf Registration\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"0800\",\"end_time\":\"0900\",\"duration\":\"1\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Welcome! \ud83c\udf89\ud83e\udd17\",\"speaker_name\":\"Borja Reinares NSSpain & Masscomm\",\"speaker_position\":\"NSSpain & Masscomm\",\"start_time\":\"0900\",\"end_time\":\"0915\",\"duration\":\"15m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"A journey towards Frameworks and Swift\",\"speaker_name\":\"Pedro Piñera SoundCloud & GitDo\",\"speaker_position\":\"SoundCloud & GitDo\",\"start_time\":\"0915\",\"end_time\":\"0950\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Styling iOS apps Swiftly\",\"speaker_name\":\"Agnes Vasarhelyi Ustream\",\"speaker_position\":\"Ustream\",\"start_time\":\"0955\",\"end_time\":\"1030\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Statically-Typed Swifty APIs\",\"speaker_name\":\"Radek Pietruszewski Nozbe\",\"speaker_position\":\"Nozbe\",\"start_time\":\"1035\",\"end_time\":\"1110\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"☕️ Coffee Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1110\",\"end_time\":\"1140\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Designing for testability\",\"speaker_name\":\"Anton Shchukin Badoo\",\"speaker_position\":\"Badoo\",\"start_time\":\"1140\",\"end_time\":\"1215\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"The Future of Functional Testing in iOS: Mobile QA Made Easy\",\"speaker_name\":\"Tripta Gupta CapitalOne\",\"speaker_position\":\"CapitalOne\",\"start_time\":\"1220\",\"end_time\":\"1255\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"From Design to Code\",\"speaker_name\":\"Guillermo Gonzalez Telefonica Innovation\",\"speaker_position\":\"Telefonica Innovation\",\"start_time\":\"1255\",\"end_time\":\"1330\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"\ud83c\udf7d Lunch Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1330\",\"end_time\":\"1500\",\"duration\":\"1'5h\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Architecting your app navigation for easy UI Testing\",\"speaker_name\":\"Alberto Gragera Karumi\",\"speaker_position\":\"Karumi\",\"start_time\":\"1500\",\"end_time\":\"1535\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Developing App-Backends with Swift on the Server\",\"speaker_name\":\"Benedikt Terhechte Indie\",\"speaker_position\":\"Indie\",\"start_time\":\"1540\",\"end_time\":\"1615\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"☕️ Coffee Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1615\",\"end_time\":\"1635\",\"duration\":\"20m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Mixins over Inheritance\",\"speaker_name\":\"Olivier Halligon Niji\",\"speaker_position\":\"Niji\",\"start_time\":\"1635\",\"end_time\":\"1710\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"iOS development uncorked\",\"speaker_name\":\"Chris Stott Buddybuild\",\"speaker_position\":\"Buddybuild\",\"start_time\":\"1715\",\"end_time\":\"1750\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Root causes of complexity in iOS apps\",\"speaker_name\":\"Daniel Martin Jobandtalent\",\"speaker_position\":\"Jobandtalent\",\"start_time\":\"1755\",\"end_time\":\"1830\",\"duration\":\"30m\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"After party! \ud83c\udf89\ud83d\udc83\ud83c\udffd\ud83c\udf77\ud83d\ude0a\ud83c\udf7b\ud83c\udf62\ud83e\uddc0\ud83c\udf56\ud83c\udf73\ud83c\udf77\ud83d\udc83\ud83c\udffd\ud83c\udf8a\ud83d\udc6f\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"2000\",\"end_time\":\"????\",\"duration\":\"\",\"day\":\"Sep 15 - \ud83d\udc25 Conference Day 1\"},{\"title\":\"Building a Better Language App in Swift\",\"speaker_name\":\"Natasha Nazari Kanji Circle & Russian Q&A\",\"speaker_position\":\"Kanji Circle & Russian Q&A\",\"start_time\":\"0915\",\"end_time\":\"0950\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"AB Testing on Mobile\",\"speaker_name\":\"Hector Zarate Spotify\",\"speaker_position\":\"Spotify\",\"start_time\":\"0955\",\"end_time\":\"1030\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Dependence Day: Insurgence\",\"speaker_name\":\"Jorge Ortiz PoWWaU\",\"speaker_position\":\"PoWWaU\",\"start_time\":\"1035\",\"end_time\":\"1110\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"☕️ Coffee Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1110\",\"end_time\":\"1140\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"MVVM + RxSwift + DataControllers\",\"speaker_name\":\"Esteban Torres SoundCloud & CraftKollective\",\"speaker_position\":\"SoundCloud & CraftKollective\",\"start_time\":\"1140\",\"end_time\":\"1215\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Building modern mobile security model in iOS applications\",\"speaker_name\":\"Anastasiia Voitova Stanfy\",\"speaker_position\":\"Stanfy\",\"start_time\":\"1220\",\"end_time\":\"1255\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Lightning Talks\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1255\",\"end_time\":\"1330\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"\ud83c\udf7d Lunch Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1330\",\"end_time\":\"1500\",\"duration\":\"1'5h\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"The Road to CocoaPods 1.0\",\"speaker_name\":\"Samuel Giddins CocoaPods\",\"speaker_position\":\"CocoaPods\",\"start_time\":\"1500\",\"end_time\":\"1535\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Behind the Music: How the SoundCloud iOS app handles streaming music to the masses\",\"speaker_name\":\"Meghan Kane SoundCloud & AutoreleasePool Conf\",\"speaker_position\":\"SoundCloud & AutoreleasePool Conf\",\"start_time\":\"1540\",\"end_time\":\"1615\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"☕️ Coffee Break\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"1615\",\"end_time\":\"1635\",\"duration\":\"20m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Building Fabric.app in Swift\",\"speaker_name\":\"Javier Soto Fabric\",\"speaker_position\":\"Fabric\",\"start_time\":\"1635\",\"end_time\":\"1710\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Extending Xcode\",\"speaker_name\":\"Boris Bügling Contentful\",\"speaker_position\":\"Contentful\",\"start_time\":\"1715\",\"end_time\":\"1750\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Musical Phantoms\",\"speaker_name\":\"Thompson Usiyan\",\"speaker_position\":\"\",\"start_time\":\"1755\",\"end_time\":\"1830\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Bye \ud83d\udc4b\ud83d\ude22\",\"speaker_name\":\"Borja Reinares NSSpain & Masscomm\",\"speaker_position\":\"NSSpain & Masscomm\",\"start_time\":\"1830\",\"end_time\":\"1900\",\"duration\":\"30m\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"},{\"title\":\"Well... maybe it's not over yet! \ud83e\udd17\",\"speaker_name\":\"\",\"speaker_position\":\"\",\"start_time\":\"2030\",\"end_time\":\"????\",\"duration\":\"\",\"day\":\"Sep 16 - \ud83d\udc25 Conference Day 2\"}]}";

            var wrapper = JsonConvert.DeserializeObject<Wrapper>(jsonString);

            RealmInstance.Write(() =>
            {
                int i = 0;
                foreach(var session in wrapper.Sessions)
                {
                    session.Id = i;

                    RealmInstance.Add(session);
                    i++;
                }
            });
		}

    }
}
