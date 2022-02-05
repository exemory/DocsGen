using System.Text.RegularExpressions;

namespace Web.Conventions
{
    public class RouteParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            if (value == null)
            {
                return null;
            }

            var str = value.ToString();

            if (str == null)
            {
                return null;
            }

            return Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
