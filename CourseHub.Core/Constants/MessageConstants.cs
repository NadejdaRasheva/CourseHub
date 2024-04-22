using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Core.Constants
{
    public class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";
        public const string LengthMessage = "The field {0} must be between {2} and {1} characters";
        public const string FrequencyMessage = "The field {0} must be between {2} and {1}";
        public const string PriceMessage = "The price of the course must be between {1} and {2} leva";
        public const string RatingMessage = "The rating must be between {1} and {2}";
    }
}
