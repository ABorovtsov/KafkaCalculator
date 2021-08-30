using System.ComponentModel.DataAnnotations;

namespace KafkaCalculator.Model
{
    public class KafkaParameters
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public float TargetThroughput { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public float ProducerThroughput { get; set; } // throughout that you can achieve on a single partition for production

        [Range(0, int.MaxValue, ErrorMessage = "Only zero or positive number allowed")]
        public float ConsumerThroughput { get; set; } // throughout that you can achieve on a single partition for production

        [Range(0, int.MaxValue, ErrorMessage = "Only zero or positive number allowed")]
        public int NumberOfBrokers { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only zero or positive number allowed")]
        public int ReplicationFactor { get; set; }
    }
}
