using KafkaCalculator.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace KafkaCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public KafkaParameters KafkaParameters { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            KafkaParameters = null;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ViewData["NumberOfPartitions"] = GetNumberOfPartitions();

            if (KafkaParameters.NumberOfBrokers > 0)
            {
                ViewData["MaxNumberOfPartitionsPerBroker"] = GetMaxNumberOfPartitionsPerBroker();
            }

            return Page();
        }

        private object GetMaxNumberOfPartitionsPerBroker()
        {
            return 100 * KafkaParameters.NumberOfBrokers * KafkaParameters.ReplicationFactor;
        }

        private int GetNumberOfPartitions()
        {
            float resultC = 1;
            float resultP = 1;

            if (KafkaParameters.ConsumerThroughput > 0)
            {
                resultC = KafkaParameters.TargetThroughput / KafkaParameters.ConsumerThroughput;
            }

            if (KafkaParameters.ProducerThroughput > 0)
            {
                resultP = KafkaParameters.TargetThroughput / KafkaParameters.ProducerThroughput;
            }

            return (int)Math.Ceiling(Math.Max(resultC, resultP));
        }
    }
}
