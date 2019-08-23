using Microsoft.EntityFrameworkCore.Migrations;

namespace ConFusion.Migrations
{
    public partial class ChangedDishId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Dishes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dishes",
                newName: "DishId");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "Category", "Description", "Featured", "Image", "Label", "Name", "Price" },
                values: new object[] { 1, "Main Dish", "Very Good Pizza", false, "pizza.jpg", "New", "Stuffed Crust Pizza", "4.00" });
        }
    }
}
