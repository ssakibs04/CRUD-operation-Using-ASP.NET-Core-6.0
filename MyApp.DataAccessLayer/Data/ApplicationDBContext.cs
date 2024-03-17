﻿
using Microsoft.EntityFrameworkCore;
using MyApp.Models;


namespace MyAppWeb.DataAccessLayer

{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options)
            :base(options) 
        { 
        
        
        }
        public DbSet<Category>categories { get; set; }
            
        }
   

   }

