using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobinator.API.Models
{
    public class JobTitleCategorized : IMongoId, IEquatable<JobTitleCategorized>
    {
        public ObjectId Id { get; set; } // IMongoId

        [BsonElement("uid")]
        public Guid UserId { get; set; }

        [BsonElement("tid")]
        public string TitleId { get; set; }

        [BsonElement("t")]
        public string Title { get; set; }

        [BsonElement("cat")]
        public string Category { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; }

        [BsonElement("votes")]
        public List<Vote> Votes { get; set; }

        public bool Equals(JobTitleCategorized other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (other == null) return false;

            return
                this.Id == other.Id &&
                this.UserId == other.UserId &&
                this.TitleId == other.TitleId &&
                this.Category == other.Category &&
                this.Tags == other.Tags;
            // TODO
        }
    }
}
