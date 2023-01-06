using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.Response
{
    public class SearchResultResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExpirationDate { get; set; }
        public string Price { get; set; }
    }
}
