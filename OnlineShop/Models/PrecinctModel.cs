﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class PrecinctModel
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public int DistrictID { get; set; }

        public int ProvinceID {  get; set; }
    }
}