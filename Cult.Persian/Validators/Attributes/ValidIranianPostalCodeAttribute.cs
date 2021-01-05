using System;
using System.ComponentModel.DataAnnotations;

namespace Cult.Persian
{
    /// <summary>
    /// Determines whether the specified value of the object is a valid IranianPostalCode.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public sealed class ValidIranianPostalCodeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        public override bool IsValid(object value)
        {
            if (string.IsNullOrWhiteSpace(value as string))
            {
                return true; // returning false, makes this field required.
            }
            return value.ToString().IsValidIranianPostalCode();
        }
    }
}