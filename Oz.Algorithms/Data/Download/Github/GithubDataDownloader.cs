using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Oz.Algorithms.Data.Download.Github
{
    /// <summary>
    /// Downloads Github Usage Data
    /// </summary>
    public class GithubDataDownloader
    {
        private readonly int _startDay;
        private readonly int _startMonth;
        private readonly int _startYear;
        private readonly int _endDay;
        private readonly int _endMonth;
        private readonly int _endYear;
        private readonly string _directory;
        private int _currentYear;
        private int _currentMonth;
        private int _currentDay;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="endDay"></param>
        /// <param name="directory"></param>
        public GithubDataDownloader(int startDay, int startMonth, int startYear, int endDay, int endMonth, int endYear, string directory)
        {
            _startDay = startDay;
            _startMonth = startMonth;
            _startYear = startYear;
            _endDay = endDay;
            _endMonth = endMonth;
            _endYear = endYear;
            _directory = directory;
        }

        public bool Download()
        {
            var result = false;
            for (var i = _startYear; i <= _endYear; i++)
            {
                result = DownloadYear(i);
            }
            return result;
        }

        private bool DownloadYear(int year)
        {
            var result = true;
            var j = 0;
            _currentYear = year;
            if (_startYear == year)
            {
                j = _startMonth;
            }
            for (var i = j; i < 12; i++)
            {
                result &= DownloadMonth(i);
            }
            return result;
        }

        private bool DownloadMonth(int month)
        {
            var result = true;
            var j = 0;
            _currentMonth = month;
            if ((_startYear == _currentYear) && (_startMonth == month))
            {
                j = _startDay;
            }
            for (var i = j; i < 31; i++)
            {
                result &= DownloadDay(i);
            }
            return result;
        }

        private bool DownloadDay(int day)
        {
            var result = true;
            for (var i = 0; i < 24; i++)
            {
                try
                {
                    var webClient = new WebClient();
                    var fileName = "";
                    if (_currentMonth < 10)
                    {
                        if (day < 10)
                        {
                            fileName = _currentYear + "-0" + _currentMonth + "-0" + day + "-" + i + ".json.gz";
                        }
                        else
                        {
                            fileName = _currentYear + "-0" + _currentMonth + "-" + day + "-" + i + ".json.gz";
                        }
                    }
                    else
                    {
                        if (day < 10)
                        {
                            fileName = _currentYear + "-" + _currentMonth + "-0" + day + "-" + i + ".json.gz";
                        }
                        else
                        {
                            fileName = _currentYear + "-" + _currentMonth + "-" + day + "-" + i + ".json.gz";
                        }
                    }
                    webClient.DownloadFile("http://data.githubarchive.org/" + fileName, _directory + "\\" + fileName);

                }
                catch (WebException webex)
                {
                    result = false;
                }
            }
            return result;
        }


    }


}
