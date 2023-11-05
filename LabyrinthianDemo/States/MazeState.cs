using Labyrinthian;

namespace LabyrinthianDemo.States;

/// <summary>
/// Class, that allows to share a maze between components.
/// </summary>
public class MazeState
{
	private readonly List<Func<Task>> eventHandlers = new();

	/// <summary>
	/// Event that is invoked when maze is updated.
	/// </summary>
	public event Func<Task> StateChanged
	{
		add => eventHandlers.Add(value);
		remove => eventHandlers.Remove(value);
	}

	/// <summary>
	/// Current state of the maze.
	/// </summary>
	public Maze? Maze { get; private set; }

	/// <summary>
	/// Update a maze state asynchronously.
	/// </summary>
	/// <param name="maze">State of the maze.</param>
	/// <returns>
	/// A task that represents an asynchronous operation.
	/// </returns>
	public async Task UpdateMazeAsync(Maze? maze)
	{
		Maze = maze;
		foreach (var handler in eventHandlers)
		{
			await handler.Invoke();
		}
	}
}
