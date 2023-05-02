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
        public Client()
        {
            Borrowing = new HashSet<Borrowing>();
        }

        [Key]
        [Column("idClient")]
        public int IdClient { get; set; }

        [Required]
        [Column("clientName")]
        [StringLength(150)]
        [Display(Name = "Nome")]
        public string ClientName { get; set; }

        [Required]
        [Column("clientCPF")]
        [StringLength(14)]
        [Display(Name = "CPF")]
        public string ClientCpf { get; set; }

        [Required]
        [Column("adress")]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Adress { get; set; }

        [Required]
        [Column("city")]
        [StringLength(25)]
        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Required]
        [Column("cellNumber")]
        [StringLength(14)]
        [Display(Name = "Telefone")]
        public string CellNumber { get; set; }


        [InverseProperty("IdClientNavigation")]
        public virtual ICollection<Borrowing> Borrowing { get; set; }
    }
}