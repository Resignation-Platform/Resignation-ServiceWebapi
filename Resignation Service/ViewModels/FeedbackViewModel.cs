using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resignation_Service.ViewModels
{
    public class FeedbackViewModel
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        public int FeedbackId { get; set; }

        /// <summary>
        /// Gets or sets the questions
        /// </summary>
        public string FeedbackQuestion { get; set; }

        /// <summary>
        /// Gets or sets the questions
        /// </summary>
        public List<string> Options { get; set; }
    }
}
