using System.ComponentModel.DataAnnotations;

namespace KafkaCalculator.Model
{
    public class KafkaParameters
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Display(Name = "Target throughput")]
        public float TargetThroughput { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Display(Name = "Producer throughput")]
        public float ProducerThroughput { get; set; } // throughout that you can achieve on a single partition for production

        [Range(0, int.MaxValue, ErrorMessage = "Only zero or positive number allowed")]
        [Display(Name = "Consumer throughput")]
        public float ConsumerThroughput { get; set; } // throughout that you can achieve on a single partition for production

        [Range(0, int.MaxValue, ErrorMessage = "Only zero or positive number allowed")]
        [Display(Name = "Number of brokers")]
        public int NumberOfBrokers { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only zero or positive number allowed")]
        [Display(Name = "Replication factor")]
        public int ReplicationFactor { get; set; }
    }
}
