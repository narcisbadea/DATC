using DATC_tema.DAL.Entity;

namespace DATC_tema.BLL.Services
{
    public interface IMetricService
    {
        Task<bool> PostMetric(Metric metric);
    }
}