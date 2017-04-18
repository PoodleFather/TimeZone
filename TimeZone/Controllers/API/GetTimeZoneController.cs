using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TimeZone.Controllers.API
{
    public class GetTimeZoneController : ApiController
    {
        [HttpGet]
        public DateTime GetTimeZoneNow(string timeZone)
        {
            //http://stackoverflow.com/questions/7908343/list-of-timezone-ids-for-use-with-findtimezonebyid-in-c
            //Eastern Standard Time -- 미국
            //Korea Standard Time -- 한국 일본
            //Singapore Standard Time
            string timeZoneId = "Korea Standard Time";
            if ("us".Equals(timeZone.ToLower())) timeZoneId = "Eastern Standard Time";
            
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
            return localDateTime;
        }
    }
}
