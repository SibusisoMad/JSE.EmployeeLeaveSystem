using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSE.EmployeeLeaveSystem.Data.Data
{
    public partial class LeaveRequestStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_RequestLeave
                    @EmployeeId INT,
                    @LeaveTypeId INT,
                    @StartDate DATETIME2,
                    @EndDate DATETIME2,
                    @Reason NVARCHAR(500)
                AS
                BEGIN
                    INSERT INTO LeaveRequests (EmployeeId, LeaveTypeId, StartDate, EndDate, Reason, Status, CreatedAt, UpdatedAt)
                    VALUES (@EmployeeId, @LeaveTypeId, @StartDate, @EndDate, @Reason, 'Pending', SYSDATETIME(), SYSDATETIME())
                END
            ");

           
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_ApproveLeave
                    @LeaveRequestId INT,
                    @ManagerId INT,
                    @Comments NVARCHAR(500)
                AS
                BEGIN
                    UPDATE LeaveRequests
                    SET Status = 'Approved',
                        ActionedById = @ManagerId,
                        DateActioned = SYSDATETIME(),
                        Comments = @Comments,
                        UpdatedAt = SYSDATETIME()
                    WHERE Id = @LeaveRequestId AND Status = 'Pending'
                END
            ");

            
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_RejectLeave
                    @LeaveRequestId INT,
                    @ManagerId INT,
                    @Comments NVARCHAR(500)
                AS
                BEGIN
                    UPDATE LeaveRequests
                    SET Status = 'Rejected',
                        ActionedById = @ManagerId,
                        DateActioned = SYSDATETIME(),
                        Comments = @Comments,
                        UpdatedAt = SYSDATETIME()
                    WHERE Id = @LeaveRequestId AND Status = 'Pending'
                END
            ");

         
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_RetractLeave
                    @LeaveRequestId INT,
                    @EmployeeId INT
                AS
                BEGIN
                    DELETE FROM LeaveRequests
                    WHERE Id = @LeaveRequestId AND EmployeeId = @EmployeeId AND Status = 'Pending'
                END
            ");

            
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_GetEmployeeLeave
                    @EmployeeId INT
                AS
                BEGIN
                    SELECT * FROM LeaveRequests WHERE EmployeeId = @EmployeeId
                END
            ");

            
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_GetManagerSubordinateLeave
                    @ManagerId INT
                AS
                BEGIN
                    SELECT lr.*
                    FROM LeaveRequests lr
                    INNER JOIN Employees e ON lr.EmployeeId = e.Id
                    WHERE e.ManagerId = @ManagerId
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_RequestLeave");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_ApproveLeave");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_RejectLeave");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_RetractLeave");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetEmployeeLeave");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetManagerSubordinateLeave");
        }
    }
}