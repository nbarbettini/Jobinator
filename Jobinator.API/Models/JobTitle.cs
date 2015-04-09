using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobinator.API.Models
{
    public class JobTitle : IMongoId, IEquatable<JobTitle>
    {
        public ObjectId Id { get; set; } // IMongoId

        [BsonElement("d")]
        public string Description { get; set; }

        [BsonElement("rnd")]
        public double RandomSeed { get; set; }

        [BsonElement("t")]
        public string Title { get; set; }

        [BsonElement("v")]
        public int Votes { get; set; }

        public bool Equals(JobTitle other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (other == null) return false;

            return
                this.Id == other.Id &&
                this.Description == other.Description &&
                this.RandomSeed == other.RandomSeed &&
                this.Title == other.Title &&
                this.Votes == other.Votes;
        }
    }
}
