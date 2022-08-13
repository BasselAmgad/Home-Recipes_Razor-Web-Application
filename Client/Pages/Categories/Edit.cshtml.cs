using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise3.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        [BindProperty]
        public string Category { get; set; }
        [BindProperty]
        public string NewCategory { get; set; }
        public EditModel(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            Category = "";
            NewCategory = "";
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet(string title)
        {
            Category = title;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("Recipes");
            var request = await client.PutAsync($"categories?category={Category}&newCategory={NewCategory}",null);
            if (request.IsSuccessStatusCode)
                return RedirectToPage("./Index");
            return Page();
        }
    }
}
