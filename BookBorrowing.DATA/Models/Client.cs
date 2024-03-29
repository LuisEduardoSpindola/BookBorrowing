﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowing.DATA.Models
{
    public partial class Client
    {
        [Key]
        [Column("idClient")]
        public int IdClient { get; set; }
        [Required]
        [Column("clientName")]
        [StringLength(150)]
        public string ClientName { get; set; }
        [Required]
        [Column("clientCPF")]
        [StringLength(14)]
        public string ClientCpf { get; set; }
        [Required]
        [Column("adress")]
        [StringLength(100)]
        public string Adress { get; set; }
        [Required]
        [Column("city")]
        [StringLength(25)]
        public string City { get; set; }
        [Required]
        [Column("cellNumber")]
        [StringLength(14)]
        public string CellNumber { get; set; }
        [StringLength(450)]
        public string IdLibrary { get; set; }
    }
}