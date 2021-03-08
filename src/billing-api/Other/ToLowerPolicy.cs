using System.Text.Json;

namespace Billing.API.Other
{
    public class ToLowerPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToLower();
        }
    }
}
