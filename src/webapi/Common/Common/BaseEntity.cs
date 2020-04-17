using System;
//using NetDataAnnotations;

namespace Common
{
    public class BaseEntity //: BaseValidate
    {
      //  [NetRequired(ErrorMessage = "Id不能为空", Groups = new[] { typeof(BaseModelType.Update) })]
        public virtual string Id { get; set; }
        public virtual DateTime? CreateTime { get; set; }
    }
}