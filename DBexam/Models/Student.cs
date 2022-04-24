using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBexam.Models
{
    public class Student
    {
       
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public Department DP { get; set; }
        public List<Lecture> LecturesList { get; set; }

        public Student(string firstName, string lastName)
        {
            //Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            LecturesList = new List<Lecture>();
        }       
    }
}
