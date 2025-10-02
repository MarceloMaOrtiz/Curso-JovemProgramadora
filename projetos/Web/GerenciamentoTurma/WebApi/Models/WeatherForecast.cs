namespace WebApi.Models
{
    public class WeatherForecast
    {

        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public WeatherForecast() { }



        public WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
        {
            this.Date = Date;
            this.TemperatureC = TemperatureC;
            this.Summary = Summary;
        }

    }
}
