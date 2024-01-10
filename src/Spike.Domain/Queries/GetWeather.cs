using MediatR;
using Spike.Domain.Models;
using Spike.Domain.Services;

namespace Spike.Domain.Queries
{
    public class GetWeather : IRequest<IEnumerable<WeatherForecast>>
    {
        public DateOnly StartDate { get; init; }
    }

    public class GetWeatherHandler : IRequestHandler<GetWeather, IEnumerable<WeatherForecast>>
    {
        private readonly WeatherForecastService weatherForecastService;

        public GetWeatherHandler(WeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;
        }

        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeather request, CancellationToken cancellationToken)
        {
            return await weatherForecastService.GetForecastAsync(request.StartDate);
        }
    }
}
