using DATC_tema.DAL.Entity;

namespace DATC_tema.DAL.Repository
{
    public interface IMetricsRepository
    {
        Task CreateMetric(Metric metric);
    }
}