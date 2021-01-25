using SQLite;
namespace INCIreader
{
    public class Ingredient
    {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            [MaxLength(100), Unique, NotNull]
            public string Name { get; set; }
            [MaxLength(15)]
            public string Type { get; set; }
            [MaxLength(10)]
            public string Harshness { get; set; }
            [MaxLength(15)]
            public string Vegan { get; set; }
            [MaxLength(15)]
            public string CG { get; set; }
            [MaxLength(250)]
            public string Notes { get; set; }
            
    }
}
