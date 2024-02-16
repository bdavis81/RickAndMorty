namespace RickAndMorty.API.DTO
{
    /// <summary>
    /// The API will automatically paginate the responses. You will receive up to 20 documents per page.
    /// 
    /// Each resource contains an info object with information about the response.
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// The length of the response
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// The amount of pages
        /// </summary>
        public int pages { get; set; }

        /// <summary>
        /// Link to the next page (if it exists)
        /// </summary>
        public string next { get; set; }

        /// <summary>
        /// Link to the previous page (if it exists)
        /// </summary>
        public string prev { get; set; }
    }
}
