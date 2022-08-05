using DTOs.Busqueda;

namespace ViewModels
{
    public class GetProductsViewModel
    {
        public SearchDto Search { get; private set; }

        public GetProductsViewModel(SearchDto search)
        {
            Search = search;
        }
    }
}
