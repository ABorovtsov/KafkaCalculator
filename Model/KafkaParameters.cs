using System.ComponentModel.DataAnnotations.Schema;

namespace KafkaCalculator.Model
{
    public class KafkaParameters
    {
        public float TargetThroughput { get; set; }

        public float ProducerThroughput { get; set; } // throughout that you can achieve on a single partition for production

        public float ConsumerThroughput { get; set; } // throughout that you can achieve on a single partition for production

        public int NumberOfBrokers { get; set; }

        public int ReplicationFactor { get; set; }
    }
}
