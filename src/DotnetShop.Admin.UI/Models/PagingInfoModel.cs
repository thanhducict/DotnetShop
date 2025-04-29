namespace DotnetShop.Admin.UI.Models
{
    public class PagingInfoModel
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
