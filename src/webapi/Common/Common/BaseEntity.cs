using System;
using NetDataAnnotations;

namespace Common
{
    public class BaseEntity : BaseValidate
    {
        public virtual string Id { get; set; }
        public virtual DateTime? CreateTime { get; set; }
    }
}