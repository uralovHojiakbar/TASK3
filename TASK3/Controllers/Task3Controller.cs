using Microsoft.AspNetCore.Mvc;
using System.Numerics;

[ApiController]
[Route("uralovhojiakbar698_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string x, [FromQuery] string y)
    {
        if (!BigInteger.TryParse(x, out var a) ||
            !BigInteger.TryParse(y, out var b) ||
            a <= 0 || b <= 0)
        {
            return Content("NaN", "text/plain");
        }

        var result = Lcm(a, b);
        return Content(result.ToString(), "text/plain");
    }

    private static BigInteger Gcd(BigInteger a, BigInteger b)
    {
        a = BigInteger.Abs(a);
        b = BigInteger.Abs(b);

        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    private static BigInteger Lcm(BigInteger a, BigInteger b)
    {
        return (a / Gcd(a, b)) * b;
    }
}
