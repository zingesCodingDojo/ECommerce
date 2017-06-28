using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goodie",
                columns: table => new
                {
                    GoodieId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GoodieCreated_At = table.Column<DateTime>(nullable: false),
                    GoodieDescription = table.Column<string>(nullable: true),
                    GoodieImageURL = table.Column<string>(nullable: true),
                    GoodieName = table.Column<string>(nullable: true),
                    GoodiePopularity = table.Column<int>(nullable: false),
                    GoodiePrice = table.Column<int>(nullable: false),
                    GoodieQuantity = table.Column<int>(nullable: false),
                    GoodieUpdated_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goodie", x => x.GoodieId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    HamsterAddress = table.Column<string>(nullable: true),
                    HamsterCreated_At = table.Column<DateTime>(nullable: true),
                    HamsterCredits = table.Column<int>(nullable: true),
                    HamsterEmail = table.Column<string>(nullable: true),
                    HamsterFirstName = table.Column<string>(nullable: true),
                    HamsterId = table.Column<string>(nullable: true),
                    HamsterLastName = table.Column<string>(nullable: true),
                    HamsterPassword = table.Column<string>(nullable: true),
                    HamsterPhoneNumber = table.Column<int>(nullable: true),
                    HamsterSecurity = table.Column<int>(nullable: true),
                    HamsterUpdated_At = table.Column<DateTime>(nullable: true),
                    HamsterUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CommentCreated_At = table.Column<DateTime>(nullable: false),
                    CommentDescription = table.Column<string>(nullable: true),
                    CommentPopularity = table.Column<int>(nullable: false),
                    CommentUpdated_At = table.Column<DateTime>(nullable: false),
                    GoodieId = table.Column<int>(nullable: false),
                    HamsterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Goodie_GoodieId",
                        column: x => x.GoodieId,
                        principalTable: "Goodie",
                        principalColumn: "GoodieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_IdentityUser_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HammyBlog",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BlogContent = table.Column<string>(nullable: true),
                    BlogCreated_At = table.Column<DateTime>(nullable: false),
                    BlogUpdated_At = table.Column<DateTime>(nullable: false),
                    HamsterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HammyBlog", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_HammyBlog_IdentityUser_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HammyWishList",
                columns: table => new
                {
                    HammyWishListId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GoodieId = table.Column<int>(nullable: false),
                    HammyWishListCreated_At = table.Column<DateTime>(nullable: false),
                    HammyWishListUpdated_At = table.Column<DateTime>(nullable: false),
                    HamsterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HammyWishList", x => x.HammyWishListId);
                    table.ForeignKey(
                        name: "FK_HammyWishList_Goodie_GoodieId",
                        column: x => x.GoodieId,
                        principalTable: "Goodie",
                        principalColumn: "GoodieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HammyWishList_IdentityUser_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    HamsterId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_IdentityUser_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    HamsterId = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_IdentityUser_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    HamsterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_IdentityUser_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogLike",
                columns: table => new
                {
                    BlogLikeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BlogId = table.Column<int>(nullable: false),
                    HamsterId = table.Column<string>(nullable: true),
                    LikeCreated_At = table.Column<DateTime>(nullable: false),
                    LikeUpdated_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogLike", x => x.BlogLikeId);
                    table.ForeignKey(
                        name: "FK_BlogLike_HammyBlog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "HammyBlog",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogLike_IdentityUser_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogLike_BlogId",
                table: "BlogLike",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogLike_HamsterId",
                table: "BlogLike",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_GoodieId",
                table: "Comment",
                column: "GoodieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_HamsterId",
                table: "Comment",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_HammyBlog_HamsterId",
                table: "HammyBlog",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_HammyWishList_GoodieId",
                table: "HammyWishList",
                column: "GoodieId");

            migrationBuilder.CreateIndex(
                name: "IX_HammyWishList_HamsterId",
                table: "HammyWishList",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "IdentityUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "IdentityUser",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_HamsterId",
                table: "AspNetUserClaims",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_HamsterId",
                table: "AspNetUserLogins",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_HamsterId",
                table: "AspNetUserRoles",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogLike");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "HammyWishList");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HammyBlog");

            migrationBuilder.DropTable(
                name: "Goodie");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
