﻿
namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using FurnitureManufacturer.Interfaces;
    using System.Linq;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> listOfFurnitures;

        public Company(string name, string registrationNumber)
        {
            this.listOfFurnitures = new List<IFurniture>();
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.listOfFurnitures;
            }
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty, null");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Name cannot be less than 5 symbols");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 10)
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols" +
                        "and cannot be null or empty");
                }

                if (!ContainsOnlyDigits(value))
                {
                    throw new ArgumentException("Registration number must contain only digits");
                }

                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.listOfFurnitures.Add(furniture);
        }

        public string Catalog()
        {
            return "Catalog";
        }

        public IFurniture Find(string model)
        {
            //IFurniture furniture = null;

            //foreach (var furnitureInCollection in listOfFurnitures)
            //{
            //    if (string.Compare(furnitureInCollection.Model, model, true) == 0)
            //    {
            //        return furnitureInCollection;
            //    }
            //}

            //return null;

            return listOfFurnitures.FirstOrDefault(f =>
            f.Model.ToLower() == model.ToLower());
        }

        public void Remove(IFurniture furniture)
        {
            this.listOfFurnitures.Remove(furniture);
        }

        private bool ContainsOnlyDigits(string text)
        {
            foreach (var ch in text)
            {
                if (!Char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
