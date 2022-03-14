using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pablo_Burgos_Ap1_p2.Migrations
{
    public partial class ProductosView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          /*   migrationBuilder.Sql(@"
            create view ProductosDetalle as
            select p.Id, p.Name, avg(r.Stars) as AverageStarRating
            from Productions p inner join Ratings r on p.Id = R.ProductionId
            group by p.Id, p.Name;
            ");
 */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /*  migrationBuilder.Sql(@"
            drop view ProductoDetalle;
            "); */

        }
    }
}
