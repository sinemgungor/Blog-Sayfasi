namespace BlogSayfasi_MVC_SinemGungor.Models.VM
{
    public class CategorySelectionVM
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();
    }
}
