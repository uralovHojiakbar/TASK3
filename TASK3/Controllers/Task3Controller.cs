using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("uralovhojiakbar698@gmail.com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public string Get([FromQuery] string x, [FromQuery] string y)
    {
        if (!int.TryParse(x, out int a) ||
            !int.TryParse(y, out int b) ||
            a <= 0 || b <= 0)
        {
            return "NaN";
        }

        return Lcm(a, b).ToString();
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    private int Lcm(int a, int b)
    {
        return a / Gcd(a, b) * b;
    }
}
