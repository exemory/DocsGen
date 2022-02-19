using System.Text.RegularExpressions;

namespace Web.Conventions
{
    public class RouteParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            var str = value?.ToString();
            
            return str == null ? null : Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
