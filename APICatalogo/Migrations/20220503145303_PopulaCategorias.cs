using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(Nome, ImagemURL) values ('Bebidas','bebodas.jpg')");
            mb.Sql("INSERT INTO Categorias(Nome, ImagemURL) values ('Lanches','lanches.jpg')");
            mb.Sql("INSERT INTO Categorias(Nome, ImagemURL) values ('Sobremesas','sobremesas.jpg')");

        }

        protected override void Down(MigrationBuilder mb)
        {

            mb.Sql("DELETE FROM Categorias");
                    }
    }
}
