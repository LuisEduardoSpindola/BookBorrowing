﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowing.DATA.Models
{
    public partial class Borrowing
    {
        [Key]
        [Column("idBorrowing")]
        public int IdBorrowing { get; set; }
        [Column("idBorrowingClient")]
        public int IdBorrowingClient { get; set; }
        [Column("idBorrowingBook")]
        public int IdBorrowingBook { get; set; }
        [Column("borrowingDate", TypeName = "datetime")]
        public DateTime BorrowingDate { get; set; }
        [Column("devolutionDate", TypeName = "datetime")]
        public DateTime DevolutionDate { get; set; }
        [Column("returned")]
        public bool Returned { get; set; }
        [StringLength(450)]
        public string IdLibrary { get; set; }
    }
}