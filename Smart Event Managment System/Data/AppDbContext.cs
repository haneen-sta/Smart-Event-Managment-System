using Microsoft.EntityFrameworkCore;
using Smart_Event_Managment_System.Models;

namespace Smart_Event_Managment_System.Data
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\Haneen1;Initial Catalog=SmartEventDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendee { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Registration> Registration { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //event
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().Property(e=>e.Title).IsRequired().HasMaxLength(99);
            modelBuilder.Entity<Event>().Property(e=>e.Description).IsRequired().HasMaxLength(499);
            modelBuilder.Entity<Event>().Property(e=>e.Category).IsRequired().HasMaxLength(49);
            modelBuilder.Entity<Event>().Property(e => e.Capacity).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.EventDate).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.StartTime).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.EndTime).IsRequired();
            //rele
            modelBuilder.Entity<Event>().HasMany(e=>e.Registries).WithOne(e=>e.Event).HasForeignKey(e=>e.EventId).OnDelete(DeleteBehavior.Restrict);
            //organizer
            modelBuilder.Entity<Organizer>().HasKey(o => o.OrganizerId);
            modelBuilder.Entity<Organizer>().Property(o => o.FullName).IsRequired().HasMaxLength(99);
            modelBuilder.Entity<Organizer>().Property(o => o.Email).IsRequired().HasMaxLength(149);
            modelBuilder.Entity<Organizer>().HasIndex(o => o.Email).IsUnique();
            modelBuilder.Entity<Organizer>().Property(o => o.Phone).IsRequired();
           // rele
            modelBuilder.Entity<Organizer>().HasMany(o=>o.Events).WithOne(o=>o.Organizer).HasForeignKey(o=>o.OrganizerId).OnDelete(DeleteBehavior.Restrict);

            //venue
            modelBuilder.Entity<Venue>().HasKey(v => v.VenueId);
            modelBuilder.Entity<Venue>().Property(v=>v.Name).IsRequired().HasMaxLength(99);
            modelBuilder.Entity<Venue>().HasIndex(v=>v.Name).IsUnique();
            modelBuilder.Entity<Venue>().Property(v => v.Location).IsRequired().HasMaxLength(199);
            modelBuilder.Entity<Venue>().Property(v => v.Capacity).IsRequired();
            //rele
            modelBuilder.Entity<Venue>().HasMany(v=>v.Events).WithOne(v=>v.Venue).HasForeignKey(v=>v.VenueId).OnDelete(DeleteBehavior.Restrict);

          //attendee
          modelBuilder.Entity<Attendee>().HasKey(a=>a.AttendeeId);
          modelBuilder.Entity<Attendee>().Property(a => a.FullName).IsRequired().HasMaxLength(99);
          modelBuilder.Entity<Attendee>().HasIndex(a=>a.Email).IsUnique();
          modelBuilder.Entity<Attendee>().Property(a => a.Email).IsRequired().HasMaxLength(149);
          modelBuilder.Entity<Attendee>().Property(a => a.Phone).IsRequired();
            //rele
          modelBuilder.Entity<Attendee>().HasMany(a=>a.Registrations).WithOne(a=>a.Attendee).HasForeignKey(a=>a.AttendeeId).OnDelete(DeleteBehavior.Restrict);

            //registrtion
            modelBuilder.Entity<Registration>().HasKey(r=>r.RegistrationId);
            modelBuilder.Entity<Registration>().Property(r => r.RegistrationDate).IsRequired();
            modelBuilder.Entity<Registration>().Property(r => r.Status).IsRequired().HasMaxLength(29);
            //compused key
            modelBuilder.Entity<Registration>().HasIndex(r=> new { r.EventId, r.AttendeeId }).IsUnique();


            // Data Seeding

            // Organizers
            modelBuilder.Entity<Organizer>().HasData(
                new Organizer
                {
                    OrganizerId = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed.hassan@example.com",
                    Phone = "01012345678"
                },
                new Organizer
                {
                    OrganizerId = 2,
                    FullName = "Mona Ali",
                    Email = "mona.ali@example.com",
                    Phone = "01123456789"
                },
                new Organizer
                {
                    OrganizerId = 3,
                    FullName = "Omar Mohamed",
                    Email = "omar.mohamed@example.com",
                    Phone = "01234567890"
                }
            );


            // Venues
            modelBuilder.Entity<Venue>().HasData(
                new Venue
                {
                    VenueId = 1,
                    Name = "Cairo Conference Hall",
                    Location = "Nasr City, Cairo",
                    Capacity = 500
                },
                new Venue
                {
                    VenueId = 2,
                    Name = "Nile View Hall",
                    Location = "Maadi, Cairo",
                    Capacity = 300
                },
                new Venue
                {
                    VenueId = 3,
                    Name = "Smart Village Auditorium",
                    Location = "Smart Village, Giza",
                    Capacity = 1000
                }
            );

            // Events
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Title = "Technology Conference",
                    Description = "A conference about modern technology and software development.",
                    EventDate = new DateTime(2026, 10, 10),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(14, 0, 0),
                    Category = "Technology",
                    Capacity = 300,
                    OrganizerId = 1,
                    VenueId = 1
                },
                new Event
                {
                    EventId = 2,
                    Title = "Business Summit",
                    Description = "A business event for entrepreneurs and professionals.",
                    EventDate = new DateTime(2026, 10, 15),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    Category = "Business",
                    Capacity = 200,
                    OrganizerId = 2,
                    VenueId = 2
                },
                new Event
                {
                    EventId = 3,
                    Title = "Programming Workshop",
                    Description = "A practical workshop for learning programming skills.",
                    EventDate = new DateTime(2026, 10, 20),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    Category = "Education",
                    Capacity = 100,
                    OrganizerId = 1,
                    VenueId = 3
                },
                new Event
                {
                    EventId = 4,
                    Title = "Digital Marketing Event",
                    Description = "An event discussing digital marketing strategies.",
                    EventDate = new DateTime(2026, 11, 5),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    Category = "Marketing",
                    Capacity = 250,
                    OrganizerId = 3,
                    VenueId = 1
                },
                new Event
                {
                    EventId = 5,
                    Title = "Software Engineering Meetup",
                    Description = "A meetup for software engineers to exchange knowledge.",
                    EventDate = new DateTime(2026, 11, 10),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(14, 0, 0),
                    Category = "Software",
                    Capacity = 150,
                    OrganizerId = 3,
                    VenueId = 2
                }
            );

            // Attendees
            modelBuilder.Entity<Attendee>().HasData(
                new Attendee
                {
                    AttendeeId = 1,
                    FullName = "Haneen Ahmed",
                    Email = "haneen.ahmed@example.com",
                    Phone = "01011111111"
                },
                new Attendee
                {
                    AttendeeId = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara.mohamed@example.com",
                    Phone = "01022222222"
                },
                new Attendee
                {
                    AttendeeId = 3,
                    FullName = "Youssef Ali",
                    Email = "youssef.ali@example.com",
                    Phone = "01033333333"
                },
                new Attendee
                {
                    AttendeeId = 4,
                    FullName = "Nour Khaled",
                    Email = "nour.khaled@example.com",
                    Phone = "01044444444"
                },
                new Attendee
                {
                    AttendeeId = 5,
                    FullName = "Karim Samir",
                    Email = "karim.samir@example.com",
                    Phone = "01055555555"
                },
                new Attendee
                {
                    AttendeeId = 6,
                    FullName = "Mariam Tarek",
                    Email = "mariam.tarek@example.com",
                    Phone = "01066666666"
                }
            );


            // Registrations
            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    RegistrationDate = new DateTime(2026, 9, 1),
                    Status = "Confirmed",
                    EventId = 1,
                    AttendeeId = 1
                },
                new Registration
                {
                    RegistrationId = 2,
                    RegistrationDate = new DateTime(2026, 9, 2),
                    Status = "Confirmed",
                    EventId = 1,
                    AttendeeId = 2
                },
                new Registration
                {
                    RegistrationId = 3,
                    RegistrationDate = new DateTime(2026, 9, 3),
                    Status = "Pending",
                    EventId = 2,
                    AttendeeId = 3
                },
                new Registration
                {
                    RegistrationId = 4,
                    RegistrationDate = new DateTime(2026, 9, 4),
                    Status = "Confirmed",
                    EventId = 3,
                    AttendeeId = 4
                },
                new Registration
                {
                    RegistrationId = 5,
                    RegistrationDate = new DateTime(2026, 9, 5),
                    Status = "Pending",
                    EventId = 3,
                    AttendeeId = 5
                },
                new Registration
                {
                    RegistrationId = 6,
                    RegistrationDate = new DateTime(2026, 9, 6),
                    Status = "Confirmed",
                    EventId = 4,
                    AttendeeId = 6
                },
                new Registration
                {
                    RegistrationId = 7,
                    RegistrationDate = new DateTime(2026, 9, 7),
                    Status = "Confirmed",
                    EventId = 5,
                    AttendeeId = 1
                },
                new Registration
                {
                    RegistrationId = 8,
                    RegistrationDate = new DateTime(2026, 9, 8),
                    Status = "Cancelled",
                    EventId = 5,
                    AttendeeId = 2
                }
            );

        }
    }
}
