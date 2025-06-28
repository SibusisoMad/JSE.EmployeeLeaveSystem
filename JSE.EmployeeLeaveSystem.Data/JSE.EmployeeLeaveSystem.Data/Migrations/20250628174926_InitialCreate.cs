using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JSE.EmployeeLeaveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTeamLead = table.Column<bool>(type: "bit", nullable: false),
                    IsCEO = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicHolidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHolidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionedById = table.Column<int>(type: "int", nullable: true),
                    DateActioned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_ActionedById",
                        column: x => x.ActionedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CellNumber", "Email", "EmployeeNumber", "FullName", "IsCEO", "IsTeamLead", "ManagerId", "Role", "Team" },
                values: new object[] { 1, null, "lindajenkins@acme.com", "0001", "Linda Jenkins", true, false, null, "CEO", "Management" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Annual Leave" },
                    { 2, "Sick Leave" },
                    { 3, "Maternity Leave" },
                    { 4, "Paternity Leave" },
                    { 5, "Compassionate Leave" },
                    { 6, "Unpaid Leave" }
                });

            migrationBuilder.InsertData(
                table: "PublicHolidays",
                columns: new[] { "Id", "Day", "Description", "Month" },
                values: new object[,]
                {
                    { 1, 1, "New Year's Day", "January" },
                    { 2, 21, "Human Rights Day", "March" },
                    { 3, 27, "Freedom Day", "April" },
                    { 4, 1, "Workers' Day", "May" },
                    { 5, 16, "Youth Day", "June" },
                    { 6, 9, "Womans Day", "August" },
                    { 7, 24, "Heritage Day", "September" },
                    { 8, 16, "Day of Reconciliation", "December" },
                    { 9, 25, "Christmas Day", "December" },
                    { 10, 26, "Day of Goodwill", "December" },
                    { 11, 1, "Family Day", "April" },
                    { 12, 18, "Good Friday", "April" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CellNumber", "Email", "EmployeeNumber", "FullName", "IsCEO", "IsTeamLead", "ManagerId", "Role", "Team" },
                values: new object[,]
                {
                    { 2, "+27 55 937 274", "miltoncoleman@amce.com", "0002", "Milton Coleman", false, true, 1, "Manager", "Support" },
                    { 3, "+27 20 915 7545", "colinhorton@amce.com", "0003", "Colin Horton", false, true, 1, "Manager", "Dev" },
                    { 4, "+27 55 979 367", "ellajefferson@acme.com", "2005", "Ella Jefferson", false, false, 3, "Employee", "Dev" },
                    { 5, "+27 20 916 5608", "earlcraig@acme.com", "2006", "Earl Craig", false, false, 3, "Employee", "Dev" },
                    { 6, "+36 55 949 891", "marshamurphy@acme.com", "2008", "Marsha Murphy", false, false, 3, "Employee", "Dev" },
                    { 7, "+27 20 917 1339", "luisortega@acme.com", "2009", "Luis Ortega", false, false, 3, "Employee", "Dev" },
                    { 8, null, "fayedennis@acme.com", "2010", "Faye Dennis", false, false, 3, "Employee", "Dev" },
                    { 9, "+27 20 914 1775", "amyburns@acme.com", "2012", "Amy Burns", false, false, 3, "Employee", "Dev" },
                    { 10, "+27 55 615 463", "darrelweber@acme.com", "2013", "Darrel Weber", false, false, 3, "Employee", "Dev" },
                    { 11, "+27 55 760 177", "charlotteosborne@acme.com", "1005", "Charlotte Osborne", false, false, 2, "Support", "Support" },
                    { 12, "+27 20 918 6908", "mariewalters@acme.com", "1006", "Marie Walters", false, false, 2, "Support", "Support" },
                    { 13, "+27 55 525 585", "leonardgill@acme.com", "1008", "Leonard Gill", false, false, 2, "Support", "Support" },
                    { 14, "+27 20 916 1335", "enriquethomas@acme.com", "1009", "Enrique Thomas", false, false, 2, "Support", "Support" },
                    { 15, null, "omardunn@acme.com", "1010", "Omar Dunn", false, false, 2, "Support", "Support" },
                    { 16, "+27 55 260 127", "deweygeorge@acme.com", "1012", "Dewey George", false, false, 2, "Support", "Support" },
                    { 17, null, "rudylewis@acme.com", "1013", "Rudy Lewis", false, false, 2, "Support", "Support" },
                    { 18, "+27 20 919 4882", "nealfrench@acme.com", "1015", "Neal French", false, false, 2, "Support", "Support" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_ActionedById",
                table: "LeaveRequests",
                column: "ActionedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "PublicHolidays");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LeaveTypes");
        }
    }
}
