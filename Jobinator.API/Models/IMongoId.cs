using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Jobinator.API.Models
{
    public interface IMongoId
    {
        ObjectId Id { get; set; }
    }
}
