using RdlcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RdlcWebApp.DAL
{
    public class StudentDAL
    {
        public List<Student> GetStudent()
        {
            List<Student> list = new List<Student>();
            var objStudent = new Student();
            objStudent.Id = 1;
            objStudent.Name = "Shikder";
            objStudent.Uni = "RU";
            list.Add(objStudent);

            return list;
        }
    }
}