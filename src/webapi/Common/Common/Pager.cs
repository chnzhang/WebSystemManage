using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Common
{
    public class Pager:BaseEntity
    {

        public Pager()
        {

        }
        public Pager(int page, int limits)
        {
            this.Page = page;
            this.Limit = limit;
        }

        public Pager(int page, int limit, IDictionary<string, object> conditions)
        {
            this.Page = page;
            this.Limit = limit;
            this.conditions = conditions;
        }


        private int page;

        [JsonIgnore]
        public int Page
        {
            get
            {
                return page < 1 ? 1 : page;
            }
            set
            {
                page = value;
            }
        }

        private int limit;

       
        [JsonIgnore]
        public int Limit
        {
            get
            {
                return limit <= 0 ? 10 : limit;
            }
            set
            {
                limit = value > 100 ? 100 : value;
            }
        }

        [JsonIgnore]
        public int PageSize { get { return Limit; } }

        [JsonIgnore]
        public int Offset { get { return (Page - 1) * Limit; } }


        private System.Collections.Generic.IDictionary<string, object> conditions;
        public System.Collections.Generic.IDictionary<string, object> Conditions
        {
            get
            {
                if (conditions == null)
                {
                    conditions = new Dictionary<string, object>();
                    return conditions;
                }
                else
                {
                    if (conditions.Keys.Any())
                    {
                        conditions["PageSize"] = PageSize;
                        conditions["Offset"] = Offset;
                    }
                    return conditions;
                }
            }
            set
            {
                conditions = value;
            }

        }
    }

}