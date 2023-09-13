using Microsoft.Extensions.Hosting;

namespace EntityFrameworkCoreExample.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
