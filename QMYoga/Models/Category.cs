namespace QMYoga.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<SubCategory> SubCategories { get; set; } = [];
}
