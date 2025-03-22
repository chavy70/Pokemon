using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}

		public DbSet<Pokemons> Pokemons { get; set; }
		public DbSet<Ability> Ability { get; set; }
		public DbSet<AbilityInfo> AbilityInfo { get; set; }
		public DbSet<Form> Form { get; set; }
		public DbSet<GameIndex> GameIndex { get; set; }
		public DbSet<Move> Move { get; set; }
		public DbSet<MoveInfo> MoveInfo { get; set; }
		public DbSet<MoveLearnMethod> MoveLearnMethod { get; set; }
		public DbSet<Species> Species { get; set; }
		public DbSet<Sprites> Sprites { get; set; }
		public DbSet<Stat> Stat { get; set; }
		public DbSet<StatInfo> StatInfo { get; set; }
		public DbSet<Pokemon.Models.Type> Type { get; set; }
		public DbSet<TypeInfo> TypeInfo { get; set; }
		public DbSet<VersionGroup> VersionGroup { get; set; }
		public DbSet<VersionGroupDetail> VersionGroupDetail { get; set; }
		public DbSet<VersionInfo> VersionInfo { get; set; }
	}
}
