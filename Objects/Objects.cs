using System.Collections.Generic;

namespace WhiteUnitySpa.Objects
{
    public class PackageInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjectUrl { get; set; }
        public string UrlForManifest { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string[] Dependencies { get; set; }
        public string Category { get; set; }
        public string Unity { get; set; }
    }


    public class PagingResultBaseDto
    {
        public int Count { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }

    public class PagingResultDto<TItem> : PagingResultBaseDto
    {
        public IEnumerable<TItem> Items { get; set; }
    }
}