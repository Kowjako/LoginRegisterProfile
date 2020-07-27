using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileForm
{
    public class User
    {
        public string phone { get; set; }
        public string telegram { get; set; }
        public string facebook { get; set; }
        public string univeristy { get; set; }
        public string fields { get; set; }
        public Bitmap photo { get; set; }
        public User()
        {

        }
        public User(string p, string t, string fb, string u,string f)
        {
            this.phone = p;
            this.telegram = t;
            this.facebook = fb;
            this.univeristy = u;
            this.fields = f;
        }
        public void changePhoto(Bitmap tmp)
        {
            photo = tmp;
        }
    }
}
