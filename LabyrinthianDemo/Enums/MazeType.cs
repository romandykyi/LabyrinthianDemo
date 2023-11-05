using System.ComponentModel.DataAnnotations;

namespace LabyrinthianDemo;

public enum MazeType
{
	Orthogonal,
	[Display(Name = "Theta(circular)")]
	Theta,
	[Display(Name = "Triangular Delta")]
	TriangularDelta,
	[Display(Name = "Rectangular Delta")]
	RectangularDelta,
	[Display(Name = "Hexagonal Delta")]
	HexagonalDelta,
	[Display(Name = "Rectangular Sigma")]
	RectangularSigma,
	[Display(Name = "Hexagonal Sigma")]
	HexagonalSigma,
	Upsilon,
	[Display(Name = "Alternative Upsilon")]
	AlternativeUpsilon
}
