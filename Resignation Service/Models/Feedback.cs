
using System.Collections.Generic;

namespace Resignation_Service.Models
{
    /// <summary>
    /// Class for feed back
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        public int intId { get; set; }

        /// <summary>
        /// Gets or sets the questions
        /// </summary>
        public string txtQuestion { get; set; }

        /// <summary>
        /// Gets or sets the questions
        /// </summary>
        public List<string> txtOptions { get; set; }
    }
}
