using System.Text.Json;

namespace Billing.API.Other
{
    /// <summary>
    /// Class for returning Json responses as lowercase propertynames
    /// </summary>
    public class ToLowerPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToLower();
        }
    }
}
