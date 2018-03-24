using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OpenClosedAndLiskov.Models.Contracts;

namespace OpenClosedAndLiskov.Models
{
    public class SimpleLayout : ILayout
    {
        //error.Datetime - error.Level - error.Message
        private const string Format = "{0} - {1} - {2}";

        //month/day/year hour/minute/seconds am_pm
        private const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            return string.Format(Format, error.DateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture), error.Level, error.Message);
        }
    }
}
