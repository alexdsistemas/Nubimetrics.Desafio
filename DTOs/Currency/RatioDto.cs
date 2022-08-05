#nullable disable
namespace DTOs.Currency
{
    public class RatioDto
    {
        public double Ratio { get; set; }

        public RatioDto(double ratio)
        {
            Ratio = ratio;
        }
    }
}
