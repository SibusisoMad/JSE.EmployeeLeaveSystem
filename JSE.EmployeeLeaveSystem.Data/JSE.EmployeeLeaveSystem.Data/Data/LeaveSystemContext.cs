using JSE.EmployeeLeaveSystem.Model;
using JSE.EmployeeLeaveSystem.Model.Enum;
using Microsoft.EntityFrameworkCore;

namespace JSE.EmployeeLeaveSystem.Data.Data
{
    public class LeaveSystemContext : DbContext
    {
        public LeaveSystemContext(DbContextOptions<LeaveSystemContext> options) : base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();

        public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
        public DbSet<PublicHoliday> PublicHolidays => Set<PublicHoliday>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
        .Property(e => e.Role)
        .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Team)
                .HasConversion<string>();

            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.Status)
                .HasConversion<string>();


            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Requester)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.ActionedBy)
                .WithMany()
                .HasForeignKey(lr => lr.ActionedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Subordinates)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType { Id = 1, Name = "Annual Leave" },
                new LeaveType { Id = 2, Name = "Sick Leave" },
                 new LeaveType { Id = 3, Name = "Maternity Leave" },
                 new LeaveType { Id = 4, Name = "Paternity Leave" },
                 new LeaveType { Id = 5, Name = "Compassionate Leave" },
                 new LeaveType { Id = 6, Name = "Unpaid Leave" });



            modelBuilder.Entity<Employee>().HasData(

              new Employee { Id = 1, EmployeeNumber = "0001", FullName = "Linda Jenkins", Email = "lindajenkins@acme.com", Team = Team.Management, Role = EmployeeRole.CEO, IsTeamLead = false, IsCEO = true },
              new Employee { Id = 2, EmployeeNumber = "0002", FullName = "Milton Coleman", Email = "miltoncoleman@amce.com", CellNumber = "+27 55 937 274", Team = Team.Support, Role = EmployeeRole.Manager, IsTeamLead = true, IsCEO = false, ManagerId = 1 },
              new Employee { Id = 3, EmployeeNumber = "0003", FullName = "Colin Horton", Email = "colinhorton@amce.com", CellNumber = "+27 20 915 7545", Team = Team.Dev, Role = EmployeeRole.Manager, IsTeamLead = true, IsCEO = false, ManagerId = 1 },


              new Employee { Id = 4, EmployeeNumber = "2005", FullName = "Ella Jefferson", Email = "ellajefferson@acme.com", CellNumber = "+27 55 979 367", Team = Team.Dev, Role = EmployeeRole.Employee, ManagerId = 3 },
              new Employee { Id = 5, EmployeeNumber = "2006", FullName = "Earl Craig", Email = "earlcraig@acme.com", CellNumber = "+27 20 916 5608", Team = Team.Dev, Role = EmployeeRole.Employee, ManagerId = 3 },
              new Employee { Id = 6, EmployeeNumber = "2008", FullName = "Marsha Murphy", Email = "marshamurphy@acme.com", CellNumber = "+36 55 949 891", Team = Team.Dev, Role = EmployeeRole.Employee, ManagerId = 3 },
              new Employee { Id = 7, EmployeeNumber = "2009", FullName = "Luis Ortega", Email = "luisortega@acme.com", CellNumber = "+27 20 917 1339", Team = Team.Dev, Role = EmployeeRole.Employee, ManagerId = 3 },
              new Employee { Id = 8, EmployeeNumber = "2010", FullName = "Faye Dennis", Email = "fayedennis@acme.com", Team = Team.Dev, Role = EmployeeRole.Employee, ManagerId = 3 },
              new Employee { Id = 9, EmployeeNumber = "2012", FullName = "Amy Burns", Email = "amyburns@acme.com", Team = Team.Dev, CellNumber = "+27 20 914 1775", Role = EmployeeRole.Employee, ManagerId = 3 },
              new Employee { Id = 10, EmployeeNumber = "2013", FullName = "Darrel Weber", Email = "darrelweber@acme.com", CellNumber = "+27 55 615 463", Team = Team.Dev, Role = EmployeeRole.Employee, ManagerId = 3 },


              new Employee { Id = 11, EmployeeNumber = "1005", FullName = "Charlotte Osborne", Email = "charlotteosborne@acme.com", CellNumber = "+27 55 760 177", Team = Team.Support, Role = EmployeeRole.Support, ManagerId = 2 },
              new Employee { Id = 12, EmployeeNumber = "1006", FullName = "Marie Walters", Email = "mariewalters@acme.com", CellNumber = "+27 20 918 6908", Team = Team.Support, Role = EmployeeRole.Support, ManagerId = 2 },
              new Employee { Id = 13, EmployeeNumber = "1008", FullName = "Leonard Gill", Email = "leonardgill@acme.com", CellNumber = "+27 55 525 585", Team = Team.Support, Role = EmployeeRole.Support, ManagerId = 2 },
              new Employee { Id = 14, EmployeeNumber = "1009", FullName = "Enrique Thomas", Email = "enriquethomas@acme.com", CellNumber = "+27 20 916 1335", Team = Team.Support, Role = EmployeeRole.Support, ManagerId = 2 },
              new Employee { Id = 15, EmployeeNumber = "1010", FullName = "Omar Dunn", Email = "omardunn@acme.com", Team = Team.Support, Role = EmployeeRole.Support, ManagerId = 2 },
              new Employee { Id = 16, EmployeeNumber = "1012", FullName = "Dewey George", Email = "deweygeorge@acme.com", Team = Team.Support, CellNumber = "+27 55 260 127", Role = EmployeeRole.Support, ManagerId = 2 },
              new Employee { Id = 17, EmployeeNumber = "1013", FullName = "Rudy Lewis", Email = "rudylewis@acme.com", Team = Team.Support, Role = EmployeeRole.Support, ManagerId = 2 },
              new Employee { Id = 18, EmployeeNumber = "1015", FullName = "Neal French", Email = "nealfrench@acme.com", CellNumber = "+27 20 919 4882", Team = Team.Support, Role = EmployeeRole.Support, ManagerId = 2 }
          );

            modelBuilder.Entity<PublicHoliday>().HasData(
                new PublicHoliday { Id = 1, Day = 1, Month = "January", Description = "New Year's Day" },
                new PublicHoliday { Id = 2, Day = 21, Month = "March", Description = "Human Rights Day" },
                new PublicHoliday { Id = 3, Day = 27, Month = "April", Description = "Freedom Day" },
                new PublicHoliday { Id = 4, Day = 1, Month = "May", Description = "Workers' Day" },
                new PublicHoliday { Id = 5, Day = 16, Month = "June", Description = "Youth Day" },
                new PublicHoliday { Id = 6, Day = 9, Month = "August", Description = "Womans Day" },
                new PublicHoliday { Id = 7, Day = 24, Month = "September", Description = "Heritage Day" },
                new PublicHoliday { Id = 8, Day = 16, Month = "December", Description = "Day of Reconciliation" },
                new PublicHoliday { Id = 9, Day = 25, Month = "December", Description = "Christmas Day" },
                new PublicHoliday { Id = 10, Day = 26, Month = "December", Description = "Day of Goodwill" },
                new PublicHoliday { Id = 11, Day = 1, Month = "April", Description = "Family Day" },
                new PublicHoliday { Id = 12, Day = 18, Month = "April", Description = "Good Friday" }
                );
        }

        public async Task RequestLeaveAsync(int employeeId, int leaveTypeId, DateTime startDate, DateTime endDate, string reason)
        {
            await Database.ExecuteSqlRawAsync(
                "EXEC sp_RequestLeave @p0, @p1, @p2, @p3, @p4",
                employeeId, leaveTypeId, startDate, endDate, reason);
        }

        // sp_ApproveLeave
        public async Task ApproveLeaveAsync(int leaveRequestId, int managerId, string comments)
        {
            await Database.ExecuteSqlRawAsync(
                "EXEC sp_ApproveLeave @p0, @p1, @p2",
                leaveRequestId, managerId, comments);
        }

        // sp_RejectLeave
        public async Task RejectLeaveAsync(int leaveRequestId, int managerId, string comments)
        {
            await Database.ExecuteSqlRawAsync(
                "EXEC sp_RejectLeave @p0, @p1, @p2",
                leaveRequestId, managerId, comments);
        }

       
        public async Task RetractLeaveAsync(int leaveRequestId, int employeeId)
        {
            await Database.ExecuteSqlRawAsync(
                "EXEC sp_RetractLeave @p0, @p1",
                leaveRequestId, employeeId);
        }

        public async Task<List<LeaveRequest>> GetEmployeeLeaveAsync(int employeeId)
        {
            return await LeaveRequests
                .FromSqlRaw("EXEC sp_GetEmployeeLeave @p0", employeeId)
                .ToListAsync();
        }

       
        public async Task<List<LeaveRequest>> GetManagerSubordinateLeaveAsync(int managerId)
        {
            return await LeaveRequests
                .FromSqlRaw("EXEC sp_GetManagerSubordinateLeave @p0", managerId)
                .ToListAsync();
        }
    }
}
