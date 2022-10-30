using AutoMapper;
using DATC_tema.DAL.Entity;
using DATC_tema.DAL.Repository;

namespace DATC_tema.BLL.Services;

public class MetricService : IMetricService
{
    private readonly IMapper _mapper;
    private readonly IMetricsRepository _metricRepository;

    public MetricService(IMetricsRepository metricRepository, IMapper mapper)
    {
        _metricRepository = metricRepository;
        _mapper = mapper;
    }

    public async Task<bool> PostMetric(Metric metric)
    {
        try
        {
            await _metricRepository.CreateMetric(metric);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
