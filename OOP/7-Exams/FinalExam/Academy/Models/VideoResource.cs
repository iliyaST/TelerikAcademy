﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;
using System.Globalization;

namespace Academy.Models
{
    public class VideoResource : Resourse
    {
        public VideoResource(ResourseType type, string name, string url) 
            : base(type, name, url)
        {

        }

        public DateTime UploadedOn { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine(string.Format("     - Uploaded on: {0}",
                this.UploadedOn.ToString("yyyy-MM-dd hh:mm:ss " + "tt", CultureInfo.InvariantCulture)));

            return sb.ToString().TrimEnd();
        }
    }
}
