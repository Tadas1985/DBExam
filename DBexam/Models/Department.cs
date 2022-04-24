using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBexam.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<Student> Students { get; set; }
        public Department(string name)
        {
            Name = name;
            Lectures = new List<Lecture>();
            Students = new List<Student>();
        }      
    }
}
