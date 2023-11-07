namespace LabyrinthianDemo.Math;

public static class RandomExtensions
{
	/// <summary>
	/// Returns a random boolean value.
	/// </summary>
	/// <param name="random"><see cref="Random" /> class used for random bool generation.</param>
	/// <param name="weight">Probability of returning <see langword="true" />.</param>
	/// <returns>
	/// A random boolean value.
	/// </returns>
	public static bool Bool(this Random random, double weight = 0.5f)
	{
		return random.NextDouble() <= weight;
	}
}
