using System;
using System.Collections.Generic;
using System.Text;

namespace Covid
{
    public class Example
    {
        public string objectIdFieldName { get; set; }
        public UniqueIdField uniqueIdField { get; set; }
        public string globalIdFieldName { get; set; }
        public string geometryType { get; set; }
        public SpatialReference spatialReference { get; set; }
        public List<Field> fields { get; set; }
        public bool exceededTransferLimit { get; set; }
        public List<Feature> features { get; set; }
    }
    public class UniqueIdField
    {
        public string name { get; set; }
        public bool isSystemMaintained { get; set; }
    }

    public class SpatialReference
    {
        public int wkid { get; set; }
        public int latestWkid { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string alias { get; set; }
        public string sqlType { get; set; }
        public object domain { get; set; }
        public object defaultValue { get; set; }
        public int? length { get; set; }
    }

    public class Attributes
    {
        public int OBJECTID { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public object Last_Update { get; set; }
        public double? Lat { get; set; }
        public double? Long_ { get; set; }
        public int Confirmed { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public int Active { get; set; }
        public object Admin2 { get; set; }
        public object FIPS { get; set; }
        public string Combined_Key { get; set; }
    }

    public class Feature
    {
        public Attributes attributes { get; set; }
    }

}
