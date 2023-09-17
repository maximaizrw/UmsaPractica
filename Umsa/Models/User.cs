﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Umsa.DTOs;

namespace Umsa.Models
{
    public class User
    {

        public User(RegisterDTO dto)
        {
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            Clave = dto.Clave;
        }

        public User(RegisterDTO dto, int id)
        {
            Id = id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            Clave = dto.Clave;
        }

        public User()
        {
        }

        [Column("codUsuario")]
        public int Id { get; set; }
        [Required]
        [Column("user_firstName", TypeName = "VARCHAR(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column("user_lastName", TypeName = "VARCHAR(100)")]
        public string LastName { get; set; }
        [Required]
        [Column("user_email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }
        [Required]
        [Column("user_clave", TypeName = "VARCHAR(50)")]
        public string Clave { get; set; }
    }
}
