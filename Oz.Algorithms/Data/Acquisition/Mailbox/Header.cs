using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Oz.Algorithms.Data.Acquisition.Mailbox
{
    /// <summary>
    /// Class for the Header's of the Mbox Posts 
    /// </summary>
    public class Header
    {
        /// <summary>
        /// "From "
        /// ID of the message valu
        /// </summary>
        public string Id { get; set; }

        
        /// <summary>
        /// "From: "
        /// Sender of the message
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// "Subject: "
        /// Subject of the message
        /// </summary>
        public string Subject { get; set; }

        
        /// <summary>
        /// "Message-ID: ""
        /// MessageId of the Post
        /// </summary>
        public  string MessageId { get; set; }

        
        /// <summary>
        /// "Date: ""
        /// Date of the Post
        /// </summary>
        public string Date { get; set; }

        public Header()
        {
            Id = "";
            From = "";
            Subject = "";
            MessageId = "";
            Date = "";
        }
    }
}
