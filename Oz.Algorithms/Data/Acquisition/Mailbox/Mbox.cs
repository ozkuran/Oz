using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oz.Algorithms.Data.Acquisition.Mailbox
{
    /// <summary>
    /// Class for processing MBOX files of Mailboxes
    /// References : [RFC4155] http://tools.ietf.org/pdf/rfc4155.pdf
    /// References : [RFC2822] http://tools.ietf.org/pdf/rfc2822.pdf
    /// References : [RFC822] http://tools.ietf.org/pdf/rfc822.pdf
    /// References : [RFC733] http://tools.ietf.org/pdf/rfc733.pdf
    /// </summary>
    public class Mbox
    {
        private string _filename;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename"></param>
        public Mbox(string filename = "")
        {
            _filename = filename;
        }

        public void ProcessMbox()
        {
            var distinctValues = new HashSet<string>();

            if (_filename == "")
            {
                _filename = @"d:\\data\comp.database.oracle.mbox";
                foreach (var line in File.ReadLines(_filename))
                {
                    var index = line.IndexOf(": ", System.StringComparison.Ordinal);
                    if ((index >= 2) && (index < 30))
                    {
                        distinctValues.Add(line.Substring(0, index - 1));
                    }
                }
                _filename = "";
            }
        }

    }
}

