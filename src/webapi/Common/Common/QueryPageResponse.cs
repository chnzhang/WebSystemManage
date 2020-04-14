using System;

namespace Common
{
    public class QueryPageResponse
    {
        public QueryPageResponse()
        {

        }

        public QueryPageResponse(Pager page)
        {
            Size = page.PageSize;
            Current = page.Page;
        }

        public int Total { get; set; }
        public int Size { get; set; }
        public int Current { get; set; }
        public int Pages
        {
            get
            {
                decimal d = (decimal)Total / Size;
                return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(d)).ToString());
            }
        }

        public object Records { get; set; }
        public bool SearchCount { get { return Total > 0; } }

    }
}