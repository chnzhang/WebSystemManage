using System;

namespace Common
{
    public class BaseEntity
    {       
        public virtual string Id { get; set; }
        public virtual DateTime? CreateTime { get; set; }
    }
}