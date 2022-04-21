using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Models
{
    public class Department
    {
        //[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerat‌ed(System.ComponentM‌​odel.DataAnnotations‌​.Schema.DatabaseGeneratedOp‌​tion.None)]
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
