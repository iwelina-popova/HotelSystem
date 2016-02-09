﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Room
    {
        private ICollection<BedOptions> bedOptions;

        public Room()
        {
            this.bedOptions = new HashSet<BedOptions>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public RoomType Type { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        [Range(1, 10)]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        //Room Features

        public bool Bathroom { get; set; }

        public bool AirConditiong { get; set; }

        public bool Heating { get; set; }

        public bool TV { get; set; }

        public bool Telephone { get; set; }

        public bool Balcon { get; set; }

        public bool Minibar { get; set; }

        public bool FreeWiFi { get; set; }
        
        //End Room Features

        public virtual ICollection<BedOptions> BedOptions {
            get { return this.bedOptions; }
            set { this.bedOptions = value; }
        }
    }
}