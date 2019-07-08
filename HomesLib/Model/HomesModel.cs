using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesLib.Model
{
    public class HomesModel
    {

        public int HomeID { get; set; }

        // [Required(ErrorMessage = "Street Address is Missing, Please Enter a Street Address")]

        public string StreetAddress { get; set; }
        //[Required(ErrorMessage = "City is Missing, Please Enter a City")]

        public string City { get; set; }
        // [Required(ErrorMessage = "State is Missing, Please Enter a State")]

        public string State { get; set; }
        //[Required(ErrorMessage = "Zip is Missing, Please Enter a Zip")]

        public int Zip { get; set; }
        // [Required(ErrorMessage = "Home Information is Missing, Please Enter a Home Info")]

        public string HomeInfo { get; set; }
        // [Required(ErrorMessage = "Price is Missing, Please Enter a Price")]

        public decimal Price { get; set; }
        // [Required(ErrorMessage = "Home Detail One is Missing, Please Enter a Home Detail")]

        public string HomeDetailOne { get; set; }
        //  [Required(ErrorMessage = "Home Detail Two is Missing, Please Enter a Home Detail Two")]


        public string HomeDetailTwo { get; set; }
        // [Required(ErrorMessage = "Home Detail Three is Missing, Please Enter a Street Address")]

        public string HomeDetailThree { get; set; }
        //[Required(ErrorMessage = "Image is Missing, Please Enter a Street Address")]

        public string Image { get; set; }
    }
}
