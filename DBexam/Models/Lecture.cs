using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam.Models
{
    public class Lecture
    {
       
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
      
        public List<Department> Deparetments { get; set; }
        public List<Student> Students { get; set; }
        public Lecture(string name)
        {
            // Id = Guid.NewGuid();
            Name = name;
            Deparetments = new List<Department>();
            Students = new List<Student>(); 

        }

    }
}
