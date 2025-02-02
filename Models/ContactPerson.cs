﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;

namespace ProjectC.Models
{
    [Table("Persoon", Schema = "dbo")]
    public class ContactPerson
    {
        [Key]
        public int persoonid { get; set; }

        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public string tussenvoegsel { get; set; }
        public string email { get; set; }
        public List<label> labellist = new List<label>();
        public List<klant> klantlist = new List<klant>();
    }
}