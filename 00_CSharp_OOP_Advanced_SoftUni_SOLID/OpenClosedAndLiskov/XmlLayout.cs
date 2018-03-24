using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using OpenClosedAndLiskov.Models;
using OpenClosedAndLiskov.Models.Contracts;

namespace OpenClosedAndLiskov
{
    public class XmlLayout : ILayout
    {
        const string DateFormat = "HH:mm:ss dd-MMM-yyyy";

        private string Format = "<log>" 
            + Environment.NewLine + "\t<date>{0}</date>" 
            + Environment.NewLine + "\t<level>{1}</level>" 
            + Environment.NewLine+ "\t<message>{2}</message>"
            + Environment.NewLine + "</log>";
       

        public string FormatError(IError error)
        {
            return string.Format(Format, error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture), error.Level, error.Message);
        }
    }
}
