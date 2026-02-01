using Microsoft.AspNetCore.Mvc;
using System.Numerics;

[ApiController]
[Route("uralovhojiakbar698_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)
    {
        if (!IsNaturalDigitsOnly(x) || !IsNaturalDigitsOnly(y))
            return Content("NaN", "text/plain");

        // endi aniq raqamlar ekanini bilamiz
        var a = BigInteger.Parse(x!);
        var b = BigInteger.Parse(y!);

        var result = Lcm(a, b);
        return Content(result.ToString(), "text/plain");
    }

    private static bool IsNaturalDigitsOnly(string? s)
    {
        if (string.IsNullOrEmpty(s)) return false;

        // faqat raqamlar bo'lsin
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c < '0' || c > '9') return false;
        }

        // natural: 0 bo'lmasin
        // "0", "00", "000" ham NaN bo'ladi
        for (int i = 0; i < s.Length; i++)
            if (s[i] != '0') return true;

        return false;
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
        => (a / Gcd(a, b)) * b;
}
