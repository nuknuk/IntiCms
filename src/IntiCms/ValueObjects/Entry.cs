using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntiCms.ValueObjects
{
    public class Entry
    {

        public string Slug { get; set; }

        public ICollection<string> Tags { get; set; }

        public string Author { get; set; }

        public DateTime Created { get; set; }

        /// <summary>
        /// UTC date time to start showing this entry
        /// </summary>
        public DateTime? VisibleOn { get; set; }

        [Required]
        public string Body { get; set; }

        public string Summary { get; set; }

        public string Title { get; set; }
    }
}