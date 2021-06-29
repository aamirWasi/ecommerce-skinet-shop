namespace ecommerce_skinet_shop.Infrustructure
{
    public class ProductSpecParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
            }
        }
        public string Sort { get; set; }
        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }

        private string _search;
        private const int _maxPageSize = 50;
        private int _pageSize = 6;
    }
}
