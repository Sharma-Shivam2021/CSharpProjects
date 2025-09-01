
using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraints;

// not essentially recommended
public class MonthsCustomConstraints : IRouteConstraint
{


    public bool Match(HttpContext? httpContext,
        IRouter? route,
        string routeKey,
        RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        // check whether the value exists
        if (!values.ContainsKey(routeKey)) // month
        {
            return false; // not a match
        }

        Regex regex = new Regex("^(apr|jul|oct|jan)$");

        string? monthValue = values[routeKey]!.ToString();
        if (regex.IsMatch(monthValue!))
        {
            return true; // its a match
        }
        return false;
    }
}
