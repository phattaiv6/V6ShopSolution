﻿using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Data.EF.Enums;

namespace V6Shop.Data.Entities
{
    public class Slide
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }

        public string Image { get; set; }
        public int SortOrder { get; set; }
        public Status Status { set; get; }
    }
}
