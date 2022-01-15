using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DocsGen.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guarantors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicDegree = table.Column<string>(type: "text", nullable: true),
                    AcademicRank = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadsOfSMC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicDegree = table.Column<string>(type: "text", nullable: true),
                    AcademicRank = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadsOfSMC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syllabuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Credits = table.Column<string>(type: "text", nullable: true),
                    TotalHours = table.Column<int>(type: "integer", nullable: true),
                    ClassroomHours = table.Column<int>(type: "integer", nullable: true),
                    LectureHours = table.Column<int>(type: "integer", nullable: true),
                    LabHours = table.Column<int>(type: "integer", nullable: true),
                    PracticalHours = table.Column<int>(type: "integer", nullable: true),
                    CourseProjects = table.Column<byte>(type: "smallint", nullable: true),
                    CourseWork = table.Column<byte>(type: "smallint", nullable: true),
                    RGR = table.Column<byte>(type: "smallint", nullable: true),
                    R = table.Column<byte>(type: "smallint", nullable: true),
                    FormOfControl = table.Column<string>(type: "text", nullable: true),
                    Semester = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicDegree = table.Column<string>(type: "text", nullable: true),
                    AcademicRank = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    KnowledgeBranchId = table.Column<int>(type: "integer", nullable: false),
                    HeadOfSMCId = table.Column<int>(type: "integer", nullable: false),
                    GuarantorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Guarantors_GuarantorId",
                        column: x => x.GuarantorId,
                        principalTable: "Guarantors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specialties_HeadsOfSMC_HeadOfSMCId",
                        column: x => x.HeadOfSMCId,
                        principalTable: "HeadsOfSMC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specialties_KnowledgeBranches_KnowledgeBranchId",
                        column: x => x.KnowledgeBranchId,
                        principalTable: "KnowledgeBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherLoads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    Year = table.Column<byte>(type: "smallint", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    SpecialityId = table.Column<int>(type: "integer", nullable: false),
                    SyllabusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherLoads_Specialties_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherLoads_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherLoads_Syllabuses_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherLoads_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBranches_Code",
                table: "KnowledgeBranches",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_Code",
                table: "Specialties",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_GuarantorId",
                table: "Specialties",
                column: "GuarantorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_HeadOfSMCId",
                table: "Specialties",
                column: "HeadOfSMCId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_KnowledgeBranchId",
                table: "Specialties",
                column: "KnowledgeBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                table: "Subjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLoads_SpecialityId",
                table: "TeacherLoads",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLoads_SubjectId",
                table: "TeacherLoads",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLoads_SyllabusId",
                table: "TeacherLoads",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLoads_TeacherId",
                table: "TeacherLoads",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLoads_Type_Year_TeacherId_SubjectId_SpecialityId",
                table: "TeacherLoads",
                columns: new[] { "Type", "Year", "TeacherId", "SubjectId", "SpecialityId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherLoads");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Syllabuses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Guarantors");

            migrationBuilder.DropTable(
                name: "HeadsOfSMC");

            migrationBuilder.DropTable(
                name: "KnowledgeBranches");
        }
    }
}
