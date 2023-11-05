using System.ComponentModel.DataAnnotations;

namespace LabyrinthianDemo;

public enum GenerationAlgorithm
{
	[Display(Name = "Aldous Broder")]
	AldousBroder,
	[Display(Name = "Binary tree")]
	BinaryTree,
	[Display(Name = "Depth-first search")]
	DepthFirstSearch,
	[Display(Name = "Edge-based Prim's algorithm")]
	EdgeBasedPrim,
	[Display(Name = "Growing tree")]
	GrowingTree,
	[Display(Name = "Hunt and Kill")]
	HuntAndKill,
	[Display(Name = "Kruskal's algorithm")]
	Kruskal,
	[Display(Name = "Prim's algorithm")]
	Prim,
	[Display(Name = "Customizable Recursive backtracker")]
	RecursiveBacktracker,
	[Display(Name = "Recursive division")]
	RecursiveDivision,
	[Display(Name = "Sidewinder")]
	Sidewinder,
	[Display(Name = "Wilson's algorithm")]
	Wilson
}
