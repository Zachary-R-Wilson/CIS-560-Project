namespace TimeBlockPlanner.Pages
{
    public class MetricTimeframeForm
    {
        public int metricTimeframeId { get; set; }
        public string name { get; set; }

        private bool _isDeleted = false;

        public bool IsDeleted => _isDeleted;
    }
}
