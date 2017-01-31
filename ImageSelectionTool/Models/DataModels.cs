using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ImageSelectionTool.Models
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string firstName { get; set; }

        public virtual List<UserImagePreference> UserImagePreferences { get; set; }
    }

    /// <summary>
    /// class to save user preference for Images
    /// </summary>
    public class UserImagePreference {

        /// <summary>
        /// Don't use this guy, this is here for EF only
        /// </summary>
        protected UserImagePreference(){}


        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="preference"></param>
        public UserImagePreference(string imageName, bool preference)
        {
            SetImageName(imageName);
            Preference = preference;
        }

        [Key]
        public int ID { get; set; }

        /// <summary>
        ///image from the gallery folder 
        /// </summary>
        public string ImageName { get; private set; }

        /// <summary>
        /// a public method to set image name. this will ensure our object wont get dirty
        /// </summary>
        /// <param name="imageName"></param>
        public void SetImageName(string imageName)
        {
            //guard clause
            if (string.IsNullOrWhiteSpace(imageName))
            {
                throw new ArgumentNullException("Image Name can't be null/empty");
            }

            ImageName = imageName;
        }

        /// <summary>
        /// User preference for Image
        /// Like - true; Dislike - false
        /// We may change it to an Enum later if there are more options viz. superlike, but it 
        /// all depends on requirements
        /// </summary>
        public bool Preference { get; set; }
        
    }

    public class DBContext : IdentityDbContext<User>
    {
        public DBContext() : base("applicationDB")
        {

        }
        //Override default table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static DBContext Create()
        {
            return new DBContext();
        }

        public DbSet<UserImagePreference> UserImagePreferences { get; set; }

    }

    //This function will ensure the database is created and seeded with any default data.
    public class DBInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            //Create an seed data you wish in the database.
        }
    }
}

