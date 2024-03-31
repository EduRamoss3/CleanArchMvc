using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
                "VALUES('Caderno espiral','Caderno espiral 100 fôlhas para estudantes',7.45,50,'caderno1.jpg',1)");
            mB.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
       "VALUES('Estojo escolar','Estojo escolar cinza com fitas amareladas tamanho 50',5.65,70,'estojo1.jpg',1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("DELETE FROM Products");
        }
    }
}
