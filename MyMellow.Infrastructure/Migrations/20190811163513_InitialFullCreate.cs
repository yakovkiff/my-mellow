using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyMellow.Infrastructure.Migrations
{
    public partial class InitialFullCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Task",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
                name: "Directory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directory_Directory_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Directory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    StartAt = table.Column<DateTime>(nullable: false),
                    EndAt = table.Column<DateTime>(nullable: true),
                    RepeatEvery = table.Column<TimeSpan>(nullable: true),
                    AlertByEmail = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskFlow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFlow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ParentId = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMap_Task_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskMap_Task_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DirectoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Directory_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Directory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TaskId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSchedule_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskSchedule_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagDirectoryMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DirectoryId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagDirectoryMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagDirectoryMap_Directory_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Directory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagDirectoryMap_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagTaskMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TaskId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTaskMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagTaskMap_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTaskMap_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskPhase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TaskFlowId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrderNumber = table.Column<short>(nullable: false)
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
                name: "NoteSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NoteId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteSchedule_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteSchedule_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagNoteMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NoteId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagNoteMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagNoteMap_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagNoteMap_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskFlowId",
                table: "Task",
                column: "TaskFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_Directory_ParentId",
                table: "Directory",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_DirectoryId",
                table: "Note",
                column: "DirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSchedule_NoteId",
                table: "NoteSchedule",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSchedule_ScheduleId",
                table: "NoteSchedule",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TagDirectoryMap_DirectoryId",
                table: "TagDirectoryMap",
                column: "DirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TagDirectoryMap_TagId",
                table: "TagDirectoryMap",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagNoteMap_NoteId",
                table: "TagNoteMap",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_TagNoteMap_TagId",
                table: "TagNoteMap",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagTaskMap_TagId",
                table: "TagTaskMap",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagTaskMap_TaskId",
                table: "TagTaskMap",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMap_ChildId",
                table: "TaskMap",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMap_ParentId",
                table: "TaskMap",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskPhase_TaskFlowId",
                table: "TaskPhase",
                column: "TaskFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSchedule_ScheduleId",
                table: "TaskSchedule",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSchedule_TaskId",
                table: "TaskSchedule",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskFlow_TaskFlowId",
                table: "Task",
                column: "TaskFlowId",
                principalTable: "TaskFlow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskFlow_TaskFlowId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "NoteSchedule");

            migrationBuilder.DropTable(
                name: "TagDirectoryMap");

            migrationBuilder.DropTable(
                name: "TagNoteMap");

            migrationBuilder.DropTable(
                name: "TagTaskMap");

            migrationBuilder.DropTable(
                name: "TaskMap");

            migrationBuilder.DropTable(
                name: "TaskPhase");

            migrationBuilder.DropTable(
                name: "TaskSchedule");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "TaskFlow");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Directory");

            migrationBuilder.DropIndex(
                name: "IX_Task_TaskFlowId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskFlowId",
                table: "Task");
        }
    }
}
