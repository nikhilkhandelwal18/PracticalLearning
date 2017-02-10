using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//use static 
using static System.Console;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class MappingEngine
    {
        static void Main(string[] args)
        {
            //WriteLine($"  xyz  {{}}   ");

            String pkt = "PSI!CI!<incident_no>!<report_date>!<incident_date>!<FCL_URN>![Custom_Field_MapBookRef]!<stop_datetime>!<patrol_mode>!<type>!<agency>!<status>!<vehicle_count>!<hide_flag>!<alert_level>!<alert_level_text>!<street>!<amg_easting>!<amg_northing>";
            //String pkt = "<xyz_address>!<amg_northing>";
            var pktArr = pkt.Split('!');


            String xmls = "<book> <value> incident_no:int::Incident.Number:int </value>" +
                             "<value> street:varchar(255)::Incident.Address.StreetOne:string </value>" +
                             "<value> amg_easting:varchar(255)::Incident.Address.Position.X:double </value>" +
                             "<value> amg_northing:varchar(255)::Incident.Address.Position.Y:double </value>" +
                           //"<value> mapref:varchar(45)::Incident.MapBookRef:String </value>" +
                           "</book> ";

            //String xmls = "<book> <value> xyz_address:string::Incident.XYZ.StreetOne:string  </value>" +
            //               "</book> ";


            System.IO.StringReader xmlFile = new System.IO.StringReader(xmls);
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);


            Dictionary<string, string> KeyValue = new Dictionary<string, string>();

            Incident inc = new Incident();
            inc.Address = new Address();
            inc.Address.StreetOne = "XYZ";
            inc.Number = "000707-30112016";
            inc.Address.Position = new Coordinate();
            inc.Address.Position.X = 12345;
            inc.Address.Position.Y = 67890;

            //object zipCode = FollowPropertyPath(inc, "Address.StreetOne");
            //object zipCode = FollowPropertyPath(inc, "Number");


            //Custom Field
            //MB - 400 - E21 and SA-46 - B1
            //MB for Map Book or SA for Street Atlas
            //regex : ^.{0,2}\s*-\s*\d*\s*-\s*\w*\s*
            //regex1: ^(SA|MB|sa|mb)\s*-
            Regex regex = new Regex(@"^(SA|MB|sa|mb)\s*-\s*(\d*)\s*-\s*(\w*)\s*");
            Match match = regex.Match("MB - 400 - E21");
            if (match.Success)
            {
                Console.WriteLine("Found Match for {0}", match.Value);
                Console.WriteLine("ID was {0}", match.Groups[1].Value);
                Console.WriteLine("ID was {0}", match.Groups[2].Value);
                Console.WriteLine("ID was {0}", match.Groups[3].Value);
            }



            //Iterate Packet fields
            foreach (string item in pktArr)
            {
                //Condition to check valid field type
                if (item.Contains("<") && item.Contains(">"))
                {
                    //Interpolate string using $
                    Write($"Pkt: {item}");


                    var id = (from DataRow dr in ds.Tables[0].Rows
                              where (string)dr[0] == item.Replace("<", "").Replace(">", "")
                              select dr).FirstOrDefault();

                    var rowValue = (from DataRow dr in ds.Tables[0].Rows
                                    where dr[0].ToString().Contains(item.Replace("<", "").Replace(">", ""))
                                    select dr[0]).FirstOrDefault();

                    if (rowValue != null)
                    {
                        WriteLine($"  Pkt Mapping: {rowValue?.ToString()}");


                        //split mapping as Source :: Destination
                        var mapArr = rowValue?.ToString().Split(new string[] { "::" }, StringSplitOptions.None);


                        string vProp = mapArr[1].Split(':')[0];

                        if (vProp.Contains('.') && vProp.Split('.').Count() <= 2)
                        {
                            int pos = vProp.LastIndexOf(".") + 1;
                            vProp = vProp.Substring(pos, vProp.Length - pos);
                            //var value = (string)inc.GetType().GetProperty(vProp).GetValue(inc, null);
                            var value = FollowPropertyPath(inc, vProp);
                            KeyValue.Add(item, value?.ToString());
                        }
                        else
                        {
                            int pos = vProp.IndexOf(".") + 1;
                            vProp = vProp.Substring(pos, vProp.Length - pos);
                            var value = FollowPropertyPath(inc, vProp);
                            KeyValue.Add(item, value?.ToString());
                        }
                    }
                }
            }

            //Create send packet

            List<string> strArr = new List<string>();

            foreach (string item in pktArr)
            {
                if (item.Contains("<") && item.Contains(">") && KeyValue.ContainsKey(item))
                {
                    strArr.Add(KeyValue[item]);
                }
                //[Custom_Field_MapBookRef]
                else if (item.Contains("[") && item.Contains("]") && item.StartsWith("[Custom_Field_"))
                {
                    if (item.ToUpper().Equals("[Custom_Field_MapBookRef]") && item.Equals("[custom_field_mapbookref]"))
                        strArr.Add("5999-55612");
                    else
                        strArr.Add("CustomValue");
                }
                else
                {
                    if (item.Contains("<") && item.Contains(">"))
                        strArr.Add(string.Empty);
                    else
                        strArr.Add(item);
                }
            }

            Console.ReadLine();
        }


        public static object FollowPropertyPath(object value, string path)
        {
            Type currentType = value.GetType();

            foreach (string propertyName in path.Split('.'))
            {
                PropertyInfo property = currentType?.GetProperty(propertyName);
                value = property?.GetValue(value, null);
                currentType = property?.PropertyType;
            }
            return value;
        }

        //public static object FollowPropertyPath(object value, string path)
        //{
        //    Type currentType = value.GetType();

        //    foreach (string propertyName in path.Split('.'))
        //    {
        //        PropertyInfo property = currentType.GetProperty(propertyName);
        //        value = property.GetValue(value, null);
        //        currentType = property.PropertyType;
        //    }
        //    return value;
        //}

    }

    public class Incident
    {
        public string Number { get; set; }
        public Address Address { get; set; }

        public string MapBookRef { get; set; }

        public Address xyz { get; set; }
    }

    public class Address
    {
        public string StreetOne { get; set; }
        public Coordinate Position { get; set; }

    }



    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

}
