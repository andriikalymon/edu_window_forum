using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class Like_Dislike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopicUserDislike",
                columns: table => new
                {
                    TopicsDislikeId = table.Column<int>(type: "int", nullable: false),
                    UsersDislikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUserDislike", x => new { x.TopicsDislikeId, x.UsersDislikeId });
                    table.ForeignKey(
                        name: "FK_TopicUserDislike_Topic_TopicsDislikeId",
                        column: x => x.TopicsDislikeId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicUserDislike_User_UsersDislikeId",
                        column: x => x.UsersDislikeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicUserLike",
                columns: table => new
                {
                    TopicsLikeId = table.Column<int>(type: "int", nullable: false),
                    UsersLikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUserLike", x => new { x.TopicsLikeId, x.UsersLikeId });
                    table.ForeignKey(
                        name: "FK_TopicUserLike_Topic_TopicsLikeId",
                        column: x => x.TopicsLikeId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicUserLike_User_UsersLikeId",
                        column: x => x.UsersLikeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicUserDislike_UsersDislikeId",
                table: "TopicUserDislike",
                column: "UsersDislikeId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicUserLike_UsersLikeId",
                table: "TopicUserLike",
                column: "UsersLikeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicUserDislike");

            migrationBuilder.DropTable(
                name: "TopicUserLike");
        }
    }
}
