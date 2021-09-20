namespace A2ZPortal.Core.ViewModel.PropertyDetail
{
    public class ProeprtyDetailByNameVm
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public decimal AreaCovered { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public string PlaceAddress { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
    }
}
