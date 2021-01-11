using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace App7.Model
{
    [DataContract]
    public class Product
    {
        int _calories;
        int _protein;
        int _fats;
        int _carbohydrates;
        public int ProductId { get; set; }
        public string NameProduct { get; set; }
        public int CalloriesProduct { get => _calories = (_protein * 4) + (_fats * 9) + (_carbohydrates * 4); set => _calories = value; }
        public int ProteinProduct   { get => _protein; set => _protein = value; }
        public int FatsProduct { get => _fats; set => _fats = value; }
        public int CarbohytratesProduct { get => _carbohydrates; set => _carbohydrates = value; }
    }
}
