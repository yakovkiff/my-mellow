using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyMellow.DbContext.Migrations
{
    public partial class ReOrientTasksDomainAroundTaskFlowMaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskFlow_TaskFlowId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "TaskFlowTemplatePhase");

            migrationBuilder.DropTable(
                name: "TaskPhase");

            migrationBuilder.DropTable(
                name: "TaskFlowTemplate");

            migrationBuilder.DropIndex(
                name: "IX_Task_TaskFlowId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskFlowId",
                table: "Task");

            migrationBuilder.CreateTable(
                name: "TaskFlowMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrderNumber = table.Column<short>(nullable: false),
                    TaskFlowId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFlowMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFlowMap_TaskFlow_TaskFlowId",
                        column: x => x.TaskFlowId,
                        principalTable: "TaskFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskFlowMap_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowMap_TaskFlowId",
                table: "TaskFlowMap",
                column: "TaskFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowMap_TaskId",
                table: "TaskFlowMap",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFlowMap");

            migrationBuilder.AddColumn<short>(
                name: "OrderNumber",
                table: "Task",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "TaskFlowId",
                table: "Task",
                nullable: false,
                defaultValue: 0);

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
                name: "TaskPhase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrderNumber = table.Column<short>(nullable: false),
                    TaskFlowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskPhase_TaskFlow_TaskFlowId",
                        column: x => x.TaskFlowId,
                        principalTable: "TaskFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskFlowTemplatePhase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrderNumber = table.Column<short>(nullable: false),
                    TaskFlowTemplateId = table.Column<int>(nullable: false)
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
                name: "IX_Task_TaskFlowId",
                table: "Task",
                column: "TaskFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowTemplatePhase_TaskFlowTemplateId",
                table: "TaskFlowTemplatePhase",
                column: "TaskFlowTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskPhase_TaskFlowId",
                table: "TaskPhase",
                column: "TaskFlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskFlow_TaskFlowId",
                table: "Task",
                column: "TaskFlowId",
                principalTable: "TaskFlow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
