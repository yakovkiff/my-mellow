using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyMellow.DbContext.Migrations
{
    public partial class CreateTaskFlowTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskFlowTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFlowTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskFlowTemplatePhase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TaskFlowTemplateId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrderNumber = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFlowTemplatePhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFlowTemplatePhase_TaskFlowTemplate_TaskFlowTemplateId",
                        column: x => x.TaskFlowTemplateId,
                        principalTable: "TaskFlowTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowTemplatePhase_TaskFlowTemplateId",
                table: "TaskFlowTemplatePhase",
                column: "TaskFlowTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFlowTemplatePhase");

            migrationBuilder.DropTable(
                name: "TaskFlowTemplate");
        }
    }
}
