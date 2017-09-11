using System;
using System.Collections.Generic;

namespace NSSpain2017.Models
{
    public class SessionsGroup
    {
        public string Day
        {
            get;
            set;
        }

        public IEnumerable<Session> Sessions
        {
            get;
            set;
        }
    }
}
