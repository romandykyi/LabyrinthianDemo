using System.ComponentModel.DataAnnotations;

namespace LabyrinthianDemo;

public enum MazeCellSelectionType
{
	Random,
	Newest,
	Latest,
	[Display(Name = "Newest or random(25%|75%)")]
	Newest25OrRandom75,
	[Display(Name = "Newest or random(50%|50%)")]
	Newest50OrRandom50,
	[Display(Name = "Newest or random(75%|25%)")]
	Newest75OrRandom25,
	[Display(Name = "Latest or random(25%|75%)")]
	Latest25OrRandom75,
	[Display(Name = "Latest or random(50%|50%)")]
	Latest50OrRandom50,
	[Display(Name = "Latest or random(75%|25%)")]
	Latest75OrRandom25,
}
