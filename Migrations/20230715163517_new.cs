using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGenerationProjectAssignment_FundRaiser.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSurName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Funding_Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageValue = table.Column<int>(type: "int", nullable: false),
                    PackageReward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_TrackerTrackerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funding_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Project_Tracker",
                columns: table => new
                {
                    TrackerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Tracker", x => x.TrackerId);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FundingGoal = table.Column<int>(type: "int", nullable: false),
                    Status_UpdateStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_projects_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status_Updates",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Project_TrackerTrackerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Updates", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_Status_Updates_Project_Tracker_Project_TrackerTrackerId",
                        column: x => x.Project_TrackerTrackerId,
                        principalTable: "Project_Tracker",
                        principalColumn: "TrackerId");
                    table.ForeignKey(
                        name: "FK_Status_Updates_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funding_Packages_Project_TrackerTrackerId",
                table: "Funding_Packages",
                column: "Project_TrackerTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Funding_Packages_ProjectId",
                table: "Funding_Packages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Tracker_ProjectId",
                table: "Project_Tracker",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_CategoryId",
                table: "projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_Status_UpdateStatusId",
                table: "projects",
                column: "Status_UpdateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_UserId",
                table: "projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Updates_Project_TrackerTrackerId",
                table: "Status_Updates",
                column: "Project_TrackerTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Updates_ProjectId",
                table: "Status_Updates",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funding_Packages_Project_Tracker_Project_TrackerTrackerId",
                table: "Funding_Packages",
                column: "Project_TrackerTrackerId",
                principalTable: "Project_Tracker",
                principalColumn: "TrackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funding_Packages_projects_ProjectId",
                table: "Funding_Packages",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Tracker_projects_ProjectId",
                table: "Project_Tracker",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_Status_Updates_Status_UpdateStatusId",
                table: "projects",
                column: "Status_UpdateStatusId",
                principalTable: "Status_Updates",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Updates_Project_Tracker_Project_TrackerTrackerId",
                table: "Status_Updates");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Updates_projects_ProjectId",
                table: "Status_Updates");

            migrationBuilder.DropTable(
                name: "Funding_Packages");

            migrationBuilder.DropTable(
                name: "Project_Tracker");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Status_Updates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
