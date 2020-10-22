using Microsoft.EntityFrameworkCore.Migrations;

namespace benefits.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    groupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(nullable: true),
                    groupDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.groupId);
                });

            migrationBuilder.CreateTable(
                name: "policy",
                columns: table => new
                {
                    policyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    policyName = table.Column<string>(nullable: true),
                    policyDesc = table.Column<string>(nullable: true),
                    groupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policy", x => x.policyId);
                    table.ForeignKey(
                        name: "FK_policy_groups_groupId",
                        column: x => x.groupId,
                        principalTable: "groups",
                        principalColumn: "groupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "benefit",
                columns: table => new
                {
                    benefitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    benefitName = table.Column<string>(nullable: true),
                    policyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_benefit", x => x.benefitId);
                    table.ForeignKey(
                        name: "FK_benefit_policy_policyId",
                        column: x => x.policyId,
                        principalTable: "policy",
                        principalColumn: "policyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_benefit_policyId",
                table: "benefit",
                column: "policyId");

            migrationBuilder.CreateIndex(
                name: "IX_policy_groupId",
                table: "policy",
                column: "groupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "benefit");

            migrationBuilder.DropTable(
                name: "policy");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}
