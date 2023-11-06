using Labyrinthian;

namespace LabyrinthianDemo.Extensions;

public static class MazeGeneratorExtensions
{
	/// <summary>
	/// Generates a maze step-by-step asynchronously.
	/// </summary>
	/// <remarks>
	/// This method calls <see cref="Task.Run" /> for each maze generation step.
	/// </remarks>
	public static async IAsyncEnumerable<Maze> GenerateStepByStepAsync(this MazeGenerator generator)
	{
		using IEnumerator<Maze> enumerator = generator.GenerateStepByStep()
			.GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return await Task.Run(() => enumerator.Current);
		}
	}
}
