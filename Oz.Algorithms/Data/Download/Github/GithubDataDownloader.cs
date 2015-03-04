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
            for (var i = _startYear; i <= _endYear; i++)
            {
                for (var j = _startMonth; j <= _endMonth; j++)
                {
                    for (var k = _startDay; k <= _endDay; k++)
                    {
                        for (var l = 0; l < 24; l++)
                        {
                            var webClient = new WebClient();
                            var fileName = "";
                            if (j < 10)
                            {
                                if (k < 10)
                                {
                                    fileName = i + "-0" + j + "-0" + k + "-" + l + ".json.gz";
                                }
                                else
                                {
                                    fileName = i + "-0" + j + "-" + k + "-" + l + ".json.gz";
                                }
                            }
                            else
                            {
                                if (k < 10)
                                {
                                    fileName = i + "-" + j + "-0" + k + "-" + l + ".json.gz";
                                }
                                else
                                {
                                    fileName = i + "-" + j + "-" + k + "-" + l + ".json.gz";
                                }
                            }
                            webClient.DownloadFile("http://data.githubarchive.org/" + fileName, _directory + "\\" + fileName);
                        }
                    }

                }
            }
            return false;
        }
    }
}
