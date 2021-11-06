namespace EncantosSalao.Web.ViewModels.BlogPosts
{
    using EncantosSalao.Web.ViewModels.Common.Pagination;

    public class BlogPostsPaginatedListViewModel
    {
        public PaginatedList<BlogPostViewModel> BlogPosts { get; set; }
    }
}
