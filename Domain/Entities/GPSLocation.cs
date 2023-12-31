﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GPSLocation : BaseEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual Airport Airport { get; set; }

        public GPSLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
