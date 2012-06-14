using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using NWVDNUG.Entities;

namespace NWVDNUG.Data
{
    public class NwvdnugDbContext : DbContext
    {
        //code first asp.net membership
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
		private readonly ObjectContext _objectContext;

		public NwvdnugDbContext() 
        {
            Database.SetInitializer(new CodeFirstContextInit());
            _objectContext = (this as IObjectContextAdapter).ObjectContext;
            _objectContext.SavingChanges += ObjectContext_SavingChanges;
        }

		void ObjectContext_SavingChanges(object sender, EventArgs e)
		{
			var objectContext = sender as ObjectContext;
            foreach (var entity in objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(x => x.Entity is IntEntity).Select(x => x.Entity).Cast<IntEntity>())
			{
                entity.LastModifiedDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
				entity.IsArchived = false;
			}
            foreach (var entity in objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Where(x => x.Entity is IntEntity).Select(x => x.Entity).Cast<IntEntity>())
			{
				entity.LastModifiedDate = DateTime.Now;
			}
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			modelBuilder.Configurations.Add(new MeetingConfiguration());
        }

		public new void SaveChanges()
    	{
    		base.SaveChanges();
    	}
    }
}