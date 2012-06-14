using System;
using System.Data.Entity;
using NWVDNUG.Entities;
using NWVDNUG.Membership;

namespace NWVDNUG.Data
{
    //public class CodeFirstContextInit : DropCreateDatabaseIfModelChanges<NwvdnugDbContext>
    //public class CodeFirstContextInit : DropCreateDatabaseAlways<NwvdnugDbContext>
    public class CodeFirstContextInit : CreateDatabaseIfNotExists<NwvdnugDbContext>
    {

        protected override void Seed(NwvdnugDbContext context)
        {

            //CodeFirstSecurity.CreateAccount("Demo", "Demo", "demo@demo.com");
            //CodeFirstSecurity.CreateAccount("MikeScott8", "Neupair1!", "mikescott8@nwvdnug.org");

            //var roleProvider = new CodeFirstRoleProvider();
            //roleProvider.CreateRole("GroupAdmin");
            //roleProvider.AddUsersToRoles(new string[] {"MikeScott8"}, new string[] {"GroupAdmin"});

            context.Meetings.Add(new Meeting
                                     {
                                         IsArchived = false,
                                         Notes = @"The first ever North West Valley .net User Group will be happening this evening. The location is Corner Bakery Cafe, 16222 N 83rd Ave, Peoria, AZ 85382. Social time will start at 6pm with the talk starting about 6:30. 

Being the first meeting this will be pretty low key meeting.

Come hear Joe Guadagno speak on community

Social time will be from 6:-6:30
Joe will start his talk about 6:30

Abstract: Come hear how you can get the most out of the community and how you can be part of the technology community.

Here is part of Joe's bio, if you are unfamiliar with him.
I have been in software development for about 15 years or so. I started out with a small book on QuickBASIC, then moved the Visual Basic for DOS, then Visual Basic for Windows, then Visual Basic .NET and eventually Visual C#. When I am not working at my full time job I donate my time to several community efforts like:
-Being the President of INETA North America.
-President of the South East Valley .NET User Group (SEVDNUG) in Chandler, AZ.

I also help / organize or participate in several community events: 
-Desert Code Camp
-AZGiveCamp",
                                         Location = "Corner Bakery Cafe, 16222 N 83rd Ave, Peoria, AZ 85382",
                                         SpeakerBioLink = "http://www.jose​phguadagno.net/​page/About.aspx",
                                         SpeakerName = "Joe Guadagno",
                                         Title="Our INAUGURAL meeting",
                                         StartDateTime = DateTime.Parse("2/22/2012 18:00"),
                                         EndDateTime = DateTime.Parse("2/22/2012 20:00"),
                                         CreatedDate = DateTime.Now,
                                     });
            context.Meetings.Add(new Meeting
                                     {
                                         IsArchived = false,
                                         Notes = "Orchard Site Building",
                                         Location = "Corner Bakery Cafe, 16222 N 83rd Ave, Peoria, AZ 85382",
                                         SpeakerBioLink = "http://twitter.com/mfcollins3",
                                         SpeakerName = "Michael Collins III",
                                         Title="Orchard Site Building",
                                         StartDateTime = DateTime.Parse("3/28/2012 18:00"),
                                         EndDateTime = DateTime.Parse("3/28/2012 20:00"),
                                         CreatedDate = DateTime.Now,
                                     });
            context.SaveChanges();
        }
    }
}