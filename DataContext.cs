using System;

public class DataContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}
	public DbSet<Livre> Livres
	{	get; set; }
	public DataContext():
	{
	}
}
