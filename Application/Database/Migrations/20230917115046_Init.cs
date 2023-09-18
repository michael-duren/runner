using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Runner.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "difficulty_levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    difficulty = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_difficulty_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "goals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    goal_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "run_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_run_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schedule_phases",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schedule_phases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    remember_token = table.Column<string>(type: "text", nullable: true),
                    email_verified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "template_schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    goal_id = table.Column<int>(type: "integer", nullable: false),
                    difficulty_level_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_schedules", x => x.id);
                    table.ForeignKey(
                        name: "fk_template_schedules_difficulty_levels_difficulty_level_id",
                        column: x => x.difficulty_level_id,
                        principalTable: "difficulty_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_template_schedules_goals_goal_id",
                        column: x => x.goal_id,
                        principalTable: "goals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "journal_notes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_journal_notes", x => x.id);
                    table.ForeignKey(
                        name: "fk_journal_notes_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_goals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    due_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    goal_description = table.Column<string>(type: "text", nullable: true),
                    goal_reason = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    goal_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_goals", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_goals_goals_goal_id",
                        column: x => x.goal_id,
                        principalTable: "goals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_goals_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "template_runs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    week_number = table.Column<int>(type: "integer", nullable: false),
                    day_number = table.Column<int>(type: "integer", nullable: false),
                    distance = table.Column<int>(type: "float", nullable: false),
                    race = table.Column<bool>(type: "boolean", nullable: false),
                    template_schedule_id = table.Column<int>(type: "integer", nullable: false),
                    schedule_phase_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_runs", x => x.id);
                    table.ForeignKey(
                        name: "fk_template_runs_schedule_phases_schedule_phase_id",
                        column: x => x.schedule_phase_id,
                        principalTable: "schedule_phases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_template_runs_template_schedules_template_schedule_id",
                        column: x => x.template_schedule_id,
                        principalTable: "template_schedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    user_goal_id = table.Column<int>(type: "integer", nullable: false),
                    difficulty_level_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_schedules", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_schedules_difficulty_levels_difficulty_level_id",
                        column: x => x.difficulty_level_id,
                        principalTable: "difficulty_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_schedules_user_goals_user_goal_id",
                        column: x => x.user_goal_id,
                        principalTable: "user_goals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_schedules_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "template_run_run_types",
                columns: table => new
                {
                    template_run_id = table.Column<int>(type: "integer", nullable: false),
                    run_type_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_template_run_run_types", x => new { x.template_run_id, x.run_type_id });
                    table.ForeignKey(
                        name: "fk_template_run_run_types_run_types_run_type_id",
                        column: x => x.run_type_id,
                        principalTable: "run_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_template_run_run_types_template_runs_template_run_entry_id",
                        column: x => x.template_run_id,
                        principalTable: "template_runs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_run_entries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    date_scheduled = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_completed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    time = table.Column<double>(type: "double precision", nullable: true),
                    average_pace = table.Column<double>(type: "double precision", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    race = table.Column<bool>(type: "boolean", nullable: false),
                    user_schedule_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_run_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_run_entries_user_schedules_user_schedule_id",
                        column: x => x.user_schedule_id,
                        principalTable: "user_schedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_run_entry_run_type",
                columns: table => new
                {
                    user_run_entry_id = table.Column<int>(type: "integer", nullable: false),
                    run_type_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_run_entry_run_type", x => new { x.user_run_entry_id, x.run_type_id });
                    table.ForeignKey(
                        name: "fk_user_run_entry_run_type_run_types_run_type_id",
                        column: x => x.run_type_id,
                        principalTable: "run_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_run_entry_run_type_user_run_entries_user_run_entry_id",
                        column: x => x.user_run_entry_id,
                        principalTable: "user_run_entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "difficulty_levels",
                columns: new[] { "id", "difficulty" },
                values: new object[,]
                {
                    { 1, "Beginner" },
                    { 2, "Intermediate" },
                    { 3, "Advanced" },
                    { 4, "Pro" }
                });

            migrationBuilder.InsertData(
                table: "goals",
                columns: new[] { "id", "goal_name" },
                values: new object[,]
                {
                    { 1, "5K" },
                    { 2, "10K" },
                    { 3, "Half Marathon" },
                    { 4, "Marathon" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { -2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", null },
                    { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", null }
                });

            migrationBuilder.InsertData(
                table: "run_types",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Non-weight-bearing aerobic activities such as aqua-jogging, swimming, or cycling. Be sure to perform them at conversation effort for 20-40 minutes.", "Cross-training" },
                    { 2, "Very relaxed effort over flat terrain (track or trail or walk the hills on your favorite route)", "Recovery Run" },
                    { 3, "After 2 mile warm-up (very relaxed effort), settle into conversation effort.", "Semi-Long Run" },
                    { 4, "After 2 mile warm-up (very relaxed effort), settle into conversation effort", "Long Run" },
                    { 5, "Find some hills on your route and stay relaxed on the uphills.", "Hilly Run" },
                    { 6, "8G (4-3-1) means go easy for 4 miles, 3 miles at goal pace, 1 mile cool down.", "Goal Pace Run" },
                    { 7, "7(5-1-1) means go easy for 5 miles, 1 mile at long fast pace, 1 mile cool down.", "Long Fast Run" },
                    { 8, "7SF: 6X800 means to perform a track workout of six 800 meter repeats.", "Short fast run" },
                    { 9, "The two workouts are interchangeable. Choose the ONE that fits your schedule.", "Or" },
                    { 10, "You can add this workout to the end of any of the other workouts. It is optional.", "And Optional" }
                });

            migrationBuilder.InsertData(
                table: "schedule_phases",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Endurance" },
                    { 2, "Strength" },
                    { 3, "Speed" },
                    { 4, "Taper" },
                    { 5, "Recovery" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_difficulty_levels_difficulty",
                table: "difficulty_levels",
                column: "difficulty",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_goals_goal_name",
                table: "goals",
                column: "goal_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_journal_notes_user_id",
                table: "journal_notes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_run_types_name",
                table: "run_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_schedule_phases_name",
                table: "schedule_phases",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_template_run_run_types_run_type_id",
                table: "template_run_run_types",
                column: "run_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_runs_schedule_phase_id",
                table: "template_runs",
                column: "schedule_phase_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_runs_template_schedule_id",
                table: "template_runs",
                column: "template_schedule_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_schedules_difficulty_level_id",
                table: "template_schedules",
                column: "difficulty_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_template_schedules_goal_id",
                table: "template_schedules",
                column: "goal_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_goals_goal_id",
                table: "user_goals",
                column: "goal_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_goals_user_id",
                table: "user_goals",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_run_entries_user_schedule_id",
                table: "user_run_entries",
                column: "user_schedule_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_run_entry_run_type_run_type_id",
                table: "user_run_entry_run_type",
                column: "run_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_schedules_difficulty_level_id",
                table: "user_schedules",
                column: "difficulty_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_schedules_user_goal_id",
                table: "user_schedules",
                column: "user_goal_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_schedules_user_id",
                table: "user_schedules",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "journal_notes");

            migrationBuilder.DropTable(
                name: "template_run_run_types");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_run_entry_run_type");

            migrationBuilder.DropTable(
                name: "template_runs");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "run_types");

            migrationBuilder.DropTable(
                name: "user_run_entries");

            migrationBuilder.DropTable(
                name: "schedule_phases");

            migrationBuilder.DropTable(
                name: "template_schedules");

            migrationBuilder.DropTable(
                name: "user_schedules");

            migrationBuilder.DropTable(
                name: "difficulty_levels");

            migrationBuilder.DropTable(
                name: "user_goals");

            migrationBuilder.DropTable(
                name: "goals");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
