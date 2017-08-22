﻿using System;
using System.Drawing;

namespace EPPlus.Core.Extensions.Tests
{
    enum Manufacturers { Opel = 1, Ford, Mercedes };
    class WrongCars
    {
        [ExcelTableColumn(ColumnName = "License plate")]
        public string LicensePlate { get; set; }

        [ExcelTableColumn]
        public Manufacturers Manufacturer { get; set; }

        [ExcelTableColumn(ColumnName = "Manufacturing date")]
        public DateTime ManufacturingDate { get; set; }

        [ExcelTableColumn(ColumnName = "Is ready for traffic?")]
        public bool Ready { get; set; }
    }

    class DefaultMap
    {
        [ExcelTableColumn]
        public string Name { get; set; }

        [ExcelTableColumn]
        public string Gender { get; set; }
    }

    class NamedMap
    {
        [ExcelTableColumn(ColumnName = "Name")]
        public string FirstName { get; set; }

        [ExcelTableColumn(ColumnName = "Gender")]
        public string Sex { get; set; }
    }

    class IndexMap
    {
        [ExcelTableColumn(ColumnIndex = 1)]
        public string Name { get; set; }

        [ExcelTableColumn(ColumnIndex = 3)]
        public string Gender { get; set; }
    }

    enum Genders { MALE = 1, FEMALE = 2 }
    class EnumStringMap
    {
        [ExcelTableColumn(ColumnName = "Name")]
        public string Name { get; set; }

        [ExcelTableColumn(ColumnName = "Gender")]
        public Genders Gender { get; set; }
    }

    enum Classes : byte { Ten = 10, Nine = 9 }
    class EnumByteMap
    {
        [ExcelTableColumn]
        public string Name { get; set; }

        [ExcelTableColumn]
        public Classes Class { get; set; }
    }

    class MultiMap
    {
        [ExcelTableColumn]
        public string Name { get; set; }

        [ExcelTableColumn(ColumnName = "Class")]
        public Classes Class { get; set; }

        [ExcelTableColumn(ColumnName = "Class")]
        public int ClassAsInt { get; set; }
    }

    class DateMap
    {
        [ExcelTableColumn]
        public string Name { get; set; }

        [ExcelTableColumn]
        public Genders Gender { get; set; }

        [ExcelTableColumn(ColumnName = "Birth date")]
        public DateTime BirthDate { get; set; }
    }

    class EnumFailMap
    {
        [ExcelTableColumn]
        public string Name { get; set; }

        [ExcelTableColumn(ColumnName = "Gender")]
        public Classes Gender { get; set; }
    }

    class CarNullable
    {
        [ExcelTableColumn(ColumnName = "Car name")]
        public string Name { get; set; }

        [ExcelTableColumn]
        public int? Price { get; set; }
    }

    class StocksNullable
    {
        [ExcelTableColumn(ColumnIndex = 1)]
        public string Barcode { get; set; }

        [ExcelTableColumn(ColumnIndex = 2)]
        public int? Quantity { get; set; }

        [ExcelTableColumn(ColumnIndex = 3)]
        public DateTime? UpdatedDate { get; set; }
    }

    enum Manufacturers2 { Opel = 1, Ford, Toyota };
    class Cars
    {
        [ExcelTableColumn(ColumnIndex = 1)]
        public string LicensePlate { get; set; }

        [ExcelTableColumn]
        public Manufacturers2 Manufacturer { get; set; }

        [ExcelTableColumn(ColumnName = "Manufacturing date")]
        public DateTime? ManufacturingDate { get; set; }

        [ExcelTableColumn]
        public int Price { get; set; }

        [ExcelTableColumn]
        public Color Color { get; set; }

        [ExcelTableColumn(ColumnName = "Is ready for traffic?")]
        public bool Ready { get; set; }

        public string UnmappedProperty { get; set; }
        public override string ToString()
        {
            return $"{(Color)} {(Manufacturer.ToString())} {(ManufacturingDate?.ToShortDateString())}";
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
