using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using QMYoga.Context;
using QMYoga.Models;

namespace QMYoga.Components.Pages
{
    public partial class Categories : ComponentBase
    {
        [Inject]
        public QMYogaContext Context { get; set; }

        public List<Category> _Categories { get; set; }

        private SubCategory selectedSubCategori;

        protected override void OnInitialized()
        {
            _Categories = Context.Categories.Include(static c => c.SubCategories).ToList();
        }

        private void UploadImage()
        {

        }

    }
}
