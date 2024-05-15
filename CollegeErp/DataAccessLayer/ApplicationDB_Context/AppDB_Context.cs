using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ApplicationDB_Context
{
    public class AppDB_Context : IdentityDbContext<RegisterUser, IdentityRole, string>
    {
        public AppDB_Context(DbContextOptions options) : base(options) { }



        
        public DbSet<FeeStructure> FeeStructures { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<LibraryDetails> LibraryData { get; set; }
        public DbSet<StudentDetails> StudentData { get; set; }
        public DbSet<TeacherDetails> TeacherData { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
     
        public DbSet<Assignment> Assignments { get; set; }



    }
}
