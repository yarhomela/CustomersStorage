using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerStorage.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class spSearchSortingPagingCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name='spSearchSortingPagingCustomers')
                BEGIN 
                execute('
                CREATE PROCEDURE [dbo].[spSearchSortingPagingCustomers]
                    @searchWord NVARCHAR(max),
                    @sortingBy int = 2,
                    @byAscending bit = 1,
                    @page int = 1,
	                @pageSize int = 10

                AS SET NOCOUNT ON
                SELECT *
                INTO #CustomersSample
                FROM [Customers] 
                WHERE [IsRemoved] = 0 AND 
                ([Name] Like(''%'' + @searchWord + ''%'')
                OR [CompanyName] Like(''%'' + @searchWord + ''%'')
                OR [Phone] Like(''%'' + @searchWord + ''%'')
                OR [Email] Like(''%'' + @searchWord + ''%''));

                SELECT * FROM #CustomersSample
                ORDER BY 
	                CASE WHEN @byAscending = 1 AND @sortingBy = 2 THEN [Name] END ASC,
	                CASE WHEN @byAscending = 1 AND @sortingBy = 3 THEN [CompanyName] END ASC,
	                CASE WHEN @byAscending = 1 AND @sortingBy = 4 THEN [Phone] END ASC,
	                CASE WHEN @byAscending = 1 AND @sortingBy = 5 THEN [Email] END ASC,
	                CASE WHEN @byAscending = 0 AND @sortingBy = 2 THEN [Name] END DESC,
	                CASE WHEN @byAscending = 0 AND @sortingBy = 3 THEN [CompanyName] END DESC,
	                CASE WHEN @byAscending = 0 AND @sortingBy = 4 THEN [Phone] END DESC,
	                CASE WHEN @byAscending = 0 AND @sortingBy = 5 THEN [Email] END DESC
                OFFSET @pageSize*(@page-1) ROWS FETCH NEXT @pageSize ROWS ONLY;
                SELECT (COUNT(*)/@pageSize + 1) AS PagesCount FROM #CustomersSample;
                ')
                END
                ";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
