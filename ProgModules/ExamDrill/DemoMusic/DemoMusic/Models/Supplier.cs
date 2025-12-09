using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMusic.Models {
    // костыль из-за отсутствия 3НФ
    public partial class Supplier {
        public int Id { get; set; }

        public string? Name { get; set; }

        public override string ToString() => Name ?? "";
    }
}
