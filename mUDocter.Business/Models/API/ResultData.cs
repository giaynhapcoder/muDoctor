using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mUDocter.Business.Models.API
{
    public class ResultData
    {
        public ResultData()
        {
            PRICE_SERVICE = 300000;
            ERR_CODE = 0;
            Message = "";
            TotalPages = 0;
        }
        public int TotalPages { get; set; }
        public string Message { get; set; }
        public int ERR_CODE { get; set; }

        public int PRICE_SERVICE { get; set; }

        public int USER_TYPE { get; set; }
        public object DATA { get; set; }
    }
}
