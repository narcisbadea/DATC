using DATC_tema.BLL.Services;
using DATC_tema.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DATC_tema.Controllers;

[ApiController]
[Route("metric")]
public class MetricController : ControllerBase
{
    private readonly IMetricService _metricService;

    public MetricController(IMetricService metricService)
    {
        _metricService = metricService;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostMetric([FromBody] int count)
    {
        var result = await _metricService.PostMetric(new Metric
        {
            CountStudents = count
        });
        return Ok(result);
    }
}
