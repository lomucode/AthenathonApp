using System;
using System.Collections.Generic;

#nullable disable

namespace AthAppDB.moduls
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public DateTime Zeit { get; set; }
        public byte[] Bild { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
