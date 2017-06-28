using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ECommerce.Models;

namespace ECommerce.Migrations
{
    [DbContext(typeof(HammyContext))]
    partial class HammyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("ECommerce.Models.BlogLike", b =>
                {
                    b.Property<int>("BlogLikeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("HamsterId");

                    b.Property<DateTime>("LikeCreated_At");

                    b.Property<DateTime>("LikeUpdated_At");

                    b.HasKey("BlogLikeId");

                    b.HasIndex("BlogId");

                    b.HasIndex("HamsterId");

                    b.ToTable("BlogLike");
                });

            modelBuilder.Entity("ECommerce.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CommentCreated_At");

                    b.Property<string>("CommentDescription");

                    b.Property<int>("CommentPopularity");

                    b.Property<DateTime>("CommentUpdated_At");

                    b.Property<int>("GoodieId");

                    b.Property<string>("HamsterId");

                    b.HasKey("CommentId");

                    b.HasIndex("GoodieId");

                    b.HasIndex("HamsterId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ECommerce.Models.Goodie", b =>
                {
                    b.Property<int>("GoodieId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("GoodieCreated_At");

                    b.Property<string>("GoodieDescription");

                    b.Property<string>("GoodieImageURL");

                    b.Property<string>("GoodieName");

                    b.Property<int>("GoodiePopularity");

                    b.Property<int>("GoodiePrice");

                    b.Property<int>("GoodieQuantity");

                    b.Property<DateTime>("GoodieUpdated_At");

                    b.HasKey("GoodieId");

                    b.ToTable("Goodie");
                });

            modelBuilder.Entity("ECommerce.Models.HammyBlog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogContent");

                    b.Property<DateTime>("BlogCreated_At");

                    b.Property<DateTime>("BlogUpdated_At");

                    b.Property<string>("HamsterId");

                    b.HasKey("BlogId");

                    b.HasIndex("HamsterId");

                    b.ToTable("HammyBlog");
                });

            modelBuilder.Entity("ECommerce.Models.HammyWishList", b =>
                {
                    b.Property<int>("HammyWishListId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GoodieId");

                    b.Property<DateTime>("HammyWishListCreated_At");

                    b.Property<DateTime>("HammyWishListUpdated_At");

                    b.Property<string>("HamsterId");

                    b.HasKey("HammyWishListId");

                    b.HasIndex("GoodieId");

                    b.HasIndex("HamsterId");

                    b.ToTable("HammyWishList");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");

                    b.HasDiscriminator<int>("Type").HasValue(0);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("HamsterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("HamsterId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("HamsterId");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("HamsterId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("HamsterId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("HamsterId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ECommerce.Models.Hamster", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser");

                    b.Property<string>("HamsterAddress");

                    b.Property<DateTime>("HamsterCreated_At");

                    b.Property<int>("HamsterCredits");

                    b.Property<string>("HamsterEmail");

                    b.Property<string>("HamsterFirstName");

                    b.Property<string>("HamsterId");

                    b.Property<string>("HamsterLastName");

                    b.Property<string>("HamsterPassword");

                    b.Property<int>("HamsterPhoneNumber");

                    b.Property<int>("HamsterSecurity");

                    b.Property<DateTime>("HamsterUpdated_At");

                    b.Property<string>("HamsterUserName");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ECommerce.Models.BlogLike", b =>
                {
                    b.HasOne("ECommerce.Models.HammyBlog", "HammyBlog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Models.Hamster", "Hamster")
                        .WithMany("BlogLike")
                        .HasForeignKey("HamsterId");
                });

            modelBuilder.Entity("ECommerce.Models.Comment", b =>
                {
                    b.HasOne("ECommerce.Models.Goodie", "Goodie")
                        .WithMany("Comment")
                        .HasForeignKey("GoodieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Models.Hamster", "Hamster")
                        .WithMany("Comment")
                        .HasForeignKey("HamsterId");
                });

            modelBuilder.Entity("ECommerce.Models.HammyBlog", b =>
                {
                    b.HasOne("ECommerce.Models.Hamster", "Hamster")
                        .WithMany("HammyBlog")
                        .HasForeignKey("HamsterId");
                });

            modelBuilder.Entity("ECommerce.Models.HammyWishList", b =>
                {
                    b.HasOne("ECommerce.Models.Goodie", "Goodie")
                        .WithMany("HammyWishList")
                        .HasForeignKey("GoodieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Models.Hamster", "Hamster")
                        .WithMany("HammyWishList")
                        .HasForeignKey("HamsterId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ECommerce.Models.Hamster")
                        .WithMany("Claims")
                        .HasForeignKey("HamsterId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ECommerce.Models.Hamster")
                        .WithMany("Logins")
                        .HasForeignKey("HamsterId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ECommerce.Models.Hamster")
                        .WithMany("Roles")
                        .HasForeignKey("HamsterId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
