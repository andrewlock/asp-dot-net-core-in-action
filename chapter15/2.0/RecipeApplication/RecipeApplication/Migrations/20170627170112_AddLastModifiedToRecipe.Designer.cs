using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RecipeApplication.Data;

namespace RecipeApplication.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170627170112_AddLastModifiedToRecipe")]
    partial class AddLastModifiedToRecipe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeApplication.Data.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<decimal>("Quantity");

                    b.Property<int>("RecipeId");

                    b.Property<string>("Unit");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("RecipeApplication.Data.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsVegan");

                    b.Property<bool>("IsVegetarian");

                    b.Property<DateTimeOffset>("LastModified");

                    b.Property<string>("Method");

                    b.Property<string>("Name");

                    b.Property<TimeSpan>("TimeToCook");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeApplication.Data.Ingredient", b =>
                {
                    b.HasOne("RecipeApplication.Data.Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
