namespace GoogleConnector.GoogleDtos
{
    using System.Collections.Generic;

    public class GoogleResponseDataDto
    {
        public GoogleResponseDataDto()
        {
            this.results = new List<GoogleImageResultDto>();
        }

        public IEnumerable<GoogleImageResultDto> results { get; set; }

        public GoogleCursorDto cursor { get; set; }
    }
}
