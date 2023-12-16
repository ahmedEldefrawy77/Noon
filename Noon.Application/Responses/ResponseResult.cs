using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Responses
{
    public class ResponseResult
    {
        public bool Status {  get; set; }
        public int ErrorNumber { get; set; }
        public string Response { get; set; }
        public ResponseResult(string message)
        {
            
          Status = false;
            ErrorNumber = 500;
            Response = message; 
        }
        public ResponseResult(Exception ex)
        {
            Status = false;
            ErrorNumber = 401;
            Response = ex.Message;

        }
    }
}
