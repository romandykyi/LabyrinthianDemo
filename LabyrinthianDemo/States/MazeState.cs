using Labyrinthian;

namespace LabyrinthianDemo.States;

/// <summary>
/// Class, that allows to share a maze between components.
/// </summary>
public class MazeState
{
    private readonly List<Func<Task>> eventHandlers = [];

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
    /// Generator that is used(or was used) for maze generation.
    /// </summary>
    public MazeGenerator? Generator { get; private set; }
    /// <summary>
    /// A flag that determines whether maze was fully generated.
    /// </summary>
    public bool IsGenerated { get; private set; }

    /// <summary>
    /// Updates the state asynchronously without changing a maze.
    /// </summary>
    /// <remarks>
    /// If maze is being generated, then this method will do nothing.
    /// </remarks>
    /// <returns>
    /// A task that represents an asynchronous operation.
    /// </returns>
    public async Task UpdateMazeAsync()
    {
        if (!IsGenerated) return;
        foreach (var handler in eventHandlers)
        {
            await handler.Invoke();
        }
    }

    /// <summary>
    /// Updates the state asynchronously.
    /// </summary>
    /// <param name="maze">State of the maze.</param>
    /// <param name="generator">State of the generator.</param>
    /// <param name="isGenerated">A flag that determines whether maze was fully generated.</param>
    /// <returns>
    /// A task that represents an asynchronous operation.
    /// </returns>
    public async Task UpdateMazeAsync(Maze maze, MazeGenerator generator, bool isGenerated = false)
    {
        Maze = maze;
        Generator = generator;
        IsGenerated = isGenerated;
        foreach (var handler in eventHandlers)
        {
            await handler.Invoke();
        }
    }
}
