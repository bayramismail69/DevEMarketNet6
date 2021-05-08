using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Core.Entities
{
    public class DocumentDbEntity
    {
        public ObjectId Id { get; set; }
    }
}
