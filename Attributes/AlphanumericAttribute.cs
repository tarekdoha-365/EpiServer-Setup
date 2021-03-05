using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EpiServer_Setup.Attributes
{
    public class AlphanumericAttribute : DataTypeAttribute
    {
        private static readonly Regex ValidationRegex = new Regex(@"^[a-z][a-z0-9]{5,19}?$", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

        public AlphanumericAttribute() : base(DataType.EmailAddress)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            return ((value is string input) && (ValidationRegex.Match(input).Length > 0));
        }
    }
}