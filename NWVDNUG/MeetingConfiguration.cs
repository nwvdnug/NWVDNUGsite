using System.Data.Entity.ModelConfiguration;
using NWVDNUG.Entities;

namespace NWVDNUG
{
    public class MeetingConfiguration : EntityTypeConfiguration<Meeting>
    {
        public MeetingConfiguration()
        {
            Map(m => m.MapInheritedProperties());

            int columnOrder=1;

            Property(m => m.Id).HasColumnOrder(columnOrder++);
            Property(m => m.StartDateTime).HasColumnOrder(columnOrder++);
            Property(m => m.EndDateTime).HasColumnOrder(columnOrder++);
            Property(m => m.Location).HasColumnOrder(columnOrder++).IsUnicode(false).HasMaxLength(100);
            Property(m => m.Title).HasColumnOrder(columnOrder++).IsUnicode(false).HasMaxLength(30);
            Property(m => m.SpeakerName).HasColumnOrder(columnOrder++).IsUnicode(false).HasMaxLength(100);
            Property(m => m.SpeakerBioLink).HasColumnOrder(columnOrder++).IsUnicode(false).HasMaxLength(256);
            Property(m => m.Notes).HasColumnOrder(columnOrder).IsUnicode(false);
        }

        //configuration.Map(x => { x.ToTable(FormatTableName(entityName), TableSchema); x.MapInheritedProperties(); });
        //primaryIdConfiguration.HasColumnName(entityName + "ID").HasColumnOrder(1);
        //return entityName;

    }
}