using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smart_Event_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class Dataa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attendee",
                columns: new[] { "AttendeeId", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "haneen.ahmed@example.com", "Haneen Ahmed", "01011111111" },
                    { 2, "sara.mohamed@example.com", "Sara Mohamed", "01022222222" },
                    { 3, "youssef.ali@example.com", "Youssef Ali", "01033333333" },
                    { 4, "nour.khaled@example.com", "Nour Khaled", "01044444444" },
                    { 5, "karim.samir@example.com", "Karim Samir", "01055555555" },
                    { 6, "mariam.tarek@example.com", "Mariam Tarek", "01066666666" }
                });

            migrationBuilder.InsertData(
                table: "Organizer",
                columns: new[] { "OrganizerId", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@example.com", "Ahmed Hassan", "01012345678" },
                    { 2, "mona.ali@example.com", "Mona Ali", "01123456789" },
                    { 3, "omar.mohamed@example.com", "Omar Mohamed", "01234567890" }
                });

            migrationBuilder.InsertData(
                table: "Venue",
                columns: new[] { "VenueId", "Capacity", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 500, "Nasr City, Cairo", "Cairo Conference Hall" },
                    { 2, 300, "Maadi, Cairo", "Nile View Hall" },
                    { 3, 1000, "Smart Village, Giza", "Smart Village Auditorium" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Capacity", "Category", "Description", "EndTime", "EventDate", "OrganizerId", "StartTime", "Title", "VenueId" },
                values: new object[,]
                {
                    { 1, 300, "Technology", "A conference about modern technology and software development.", new TimeSpan(0, 14, 0, 0, 0), new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), "Technology Conference", 1 },
                    { 2, 200, "Business", "A business event for entrepreneurs and professionals.", new TimeSpan(0, 15, 0, 0, 0), new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 11, 0, 0, 0), "Business Summit", 2 },
                    { 3, 100, "Education", "A practical workshop for learning programming skills.", new TimeSpan(0, 13, 0, 0, 0), new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 9, 0, 0, 0), "Programming Workshop", 3 },
                    { 4, 250, "Marketing", "An event discussing digital marketing strategies.", new TimeSpan(0, 16, 0, 0, 0), new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 12, 0, 0, 0), "Digital Marketing Event", 1 },
                    { 5, 150, "Software", "A meetup for software engineers to exchange knowledge.", new TimeSpan(0, 14, 0, 0, 0), new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 10, 0, 0, 0), "Software Engineering Meetup", 2 }
                });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "RegistrationId", "AttendeeId", "EventId", "RegistrationDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 2, 2, 1, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 3, 3, 2, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 4, 4, 3, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 5, 5, 3, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 6, 6, 4, new DateTime(2026, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 7, 1, 5, new DateTime(2026, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 8, 2, 5, new DateTime(2026, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "RegistrationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attendee",
                keyColumn: "AttendeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendee",
                keyColumn: "AttendeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendee",
                keyColumn: "AttendeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attendee",
                keyColumn: "AttendeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attendee",
                keyColumn: "AttendeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attendee",
                keyColumn: "AttendeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Organizer",
                keyColumn: "OrganizerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizer",
                keyColumn: "OrganizerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizer",
                keyColumn: "OrganizerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Venue",
                keyColumn: "VenueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venue",
                keyColumn: "VenueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venue",
                keyColumn: "VenueId",
                keyValue: 3);
        }
    }
}
