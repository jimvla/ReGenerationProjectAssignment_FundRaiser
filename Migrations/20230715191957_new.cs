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
                name: "Project_Tracker",
                columns: table => new
                {
                    TrackerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Tracker", x => x.TrackerId);
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
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageValue = table.Column<int>(type: "int", nullable: false),
                    PackageReward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_TrackerTrackerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funding_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Funding_Packages_Project_Tracker_Project_TrackerTrackerId",
                        column: x => x.Project_TrackerTrackerId,
                        principalTable: "Project_Tracker",
                        principalColumn: "TrackerId");
                });

            migrationBuilder.CreateTable(
                name: "Funding_PackageProject",
                columns: table => new
                {
                    Funding_PackagesPackageId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funding_PackageProject", x => new { x.Funding_PackagesPackageId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_Funding_PackageProject_Funding_Packages_Funding_PackagesPackageId",
                        column: x => x.Funding_PackagesPackageId,
                        principalTable: "Funding_Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundingGoal = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Project_TrackerTrackerId = table.Column<int>(type: "int", nullable: true),
                    Status_UpdateStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Projects_Project_Tracker_Project_TrackerTrackerId",
                        column: x => x.Project_TrackerTrackerId,
                        principalTable: "Project_Tracker",
                        principalColumn: "TrackerId");
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Status_Updates",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Updates", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_Status_Updates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funding_PackageProject_ProjectId",
                table: "Funding_PackageProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Funding_Packages_Project_TrackerTrackerId",
                table: "Funding_Packages",
                column: "Project_TrackerTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Project_TrackerTrackerId",
                table: "Projects",
                column: "Project_TrackerTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Status_UpdateStatusId",
                table: "Projects",
                column: "Status_UpdateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Updates_ProjectId",
                table: "Status_Updates",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funding_PackageProject_Projects_ProjectId",
                table: "Funding_PackageProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Status_Updates_Status_UpdateStatusId",
                table: "Projects",
                column: "Status_UpdateStatusId",
                principalTable: "Status_Updates",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Updates_Projects_ProjectId",
                table: "Status_Updates");

            migrationBuilder.DropTable(
                name: "Funding_PackageProject");

            migrationBuilder.DropTable(
                name: "Funding_Packages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Project_Tracker");

            migrationBuilder.DropTable(
                name: "Status_Updates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
