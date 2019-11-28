using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommunityWebsite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Topic = table.Column<string>(nullable: true),
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnixTimeStamp = table.Column<int>(nullable: false),
                    MessageContent = table.Column<string>(nullable: true),
                    MessageTitle = table.Column<string>(nullable: true),
                    UserNameSignature = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Message_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReplyContent = table.Column<string>(nullable: true),
                    UserNameSignature = table.Column<string>(nullable: true),
                    UnixTimeStamp = table.Column<int>(nullable: false),
                    MessageID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyID);
                    table.ForeignKey(
                        name: "FK_Replies_Message_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Message",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Replies_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserID",
                table: "Message",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_MessageID",
                table: "Replies",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserID",
                table: "Replies",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
