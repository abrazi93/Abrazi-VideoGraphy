using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AVGRazor.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set;} = "Razor is awesome!";
        public List<DateTime> Times { get; private set; } = new List<DateTime>();
        public void OnGet()
        {
            for (int i = 0; i < 10; i++)
            {
                Times.Add(DateTime.Now);
            }
            ViewData["Foo"] = "<h1>Hello World</h1>";
        }

        [BindProperty]
        public string Name { get; set; }

        public async Task<IActionResult> OnPostTestAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();   
            }

            Console.WriteLine("Received: " + Name);

            return RedirectToPage("/Index");
        }
    }
}
