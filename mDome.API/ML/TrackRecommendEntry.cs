using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.ML
{
        public class TrackPrediction
        {
            public float Score { get; set; }
        }

        public class TrackRecommendEntry
        {
            [KeyType(count: 2000)]
            public uint TrackId { get; set; }

            [KeyType(count: 2000)]
            public uint UserId { get; set; }
            public float Label { get; set; }

    }
}
