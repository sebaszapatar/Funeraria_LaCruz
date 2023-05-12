
using Funeraria_LaCruz.Shared.Entities;

namespace Funeraria_LaCruz.Shared.Entities
{
    public class FunerariaCategory
    {
        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        public Category Category { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}
