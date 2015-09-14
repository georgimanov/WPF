using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleConnector.GoogleDtos
{
    public class GoogleCursorDto
    {
        public GoogleCursorDto()
        {
            this.pages = new List<GoogleCursorPageDto>();
        }

        public IEnumerable<GoogleCursorPageDto> pages { get; set; } 
        public string estimatedResultCount { get; set; }
        public string currentPageIndex { get; set; }
        public string moreResultsUrl { get; set; }
    }
}
