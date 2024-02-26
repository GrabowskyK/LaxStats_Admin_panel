using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaxStats_Admin_panel.Model.DTO
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Born { get; set; }
        public int ShirtNumber { get; set; }
        public int TeamId { get; set; }
    }
}
