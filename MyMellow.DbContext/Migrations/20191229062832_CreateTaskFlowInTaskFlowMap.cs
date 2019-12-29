using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyMellow.DbContext.Migrations
{
    public partial class CreateTaskFlowInTaskFlowMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskFlowInTaskFlowMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrderNumber = table.Column<short>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFlowInTaskFlowMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFlowInTaskFlowMap_TaskFlow_ChildId",
                        column: x => x.ChildId,
                        principalTable: "TaskFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskFlowInTaskFlowMap_TaskFlow_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TaskFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowInTaskFlowMap_ChildId",
                table: "TaskFlowInTaskFlowMap",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFlowInTaskFlowMap_ParentId",
                table: "TaskFlowInTaskFlowMap",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFlowInTaskFlowMap");
        }
    }
}
