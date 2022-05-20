using System;
using System.Collections.Generic;

#nullable disable

namespace Kutuphane_MVC_EF.Models
{
    public partial class Turler
    {
        public Turler()
        {
            Kitaplars = new HashSet<Kitaplar>();
            Yazarlars = new HashSet<Yazarlar>();
        }

        public int Id { get; set; }
        public string TurAd { get; set; }

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
        public virtual ICollection<Yazarlar> Yazarlars { get; set; }
    }
}
