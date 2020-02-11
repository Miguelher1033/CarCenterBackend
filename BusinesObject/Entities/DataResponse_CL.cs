using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesObject.Entities
{
  public class DataResponse_CL<T> where T : class
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<T> Results { get; set; }
    }

}
