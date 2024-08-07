﻿using Labyrinthian;
using Labyrinthian.Svg;

namespace LabyrinthianDemo.States;

/// <summary>
/// Class, that allows to share maze rendering settings between components.
/// </summary>
public class SvgRendererState
{
	/// <summary>
	/// Default radius of a graph node.
	/// </summary>
	public const float NodeRadius = 4f;

	/// <summary>
	/// Size of a maze cell(in pixels).
	/// </summary>
	public float CellSize { get; set; } = 32f;
	/// <summary>
	/// Width of walls(in pixels)
	/// </summary>
	public float WallsWidth { get; set; } = 2f;
	/// <summary>
	/// Padding of a maze.
	/// </summary>
	public float Padding { get; set; } = 5f;
	/// <summary>
	/// Flag which determines whether to indent SVG elements.
	/// </summary>
	public bool Indent { get; set; } = true;

	/// <summary>
	/// Flag that determines whether maze description should be
	/// included in the output SVG file.
	/// </summary>
	public bool ExportDescription { get; set; } = true;
	/// <summary>
	/// Background fill of a maze.
	/// </summary>
	public SvgFill? BackgroundFill { get; set; }
	/// <summary>
	/// Group of all maze cells.
	/// </summary>
	public SvgGroup? AllCellsGroup { get; set; } = new()
	{
		Fill = SvgColor.Orange,
		Stroke = SvgColor.Orange
	};
	/// <summary>
	/// Group of unvisited cells (used in step-by-step generation).
	/// </summary>
	public SvgGroup? UnvisitedCellsGroup { get; set; } = new()
	{
		Fill = SvgColor.FromHexCode("#111111"),
		Stroke = SvgColor.FromHexCode("#111111"),
		Id = "unvisitedCells"
	};
	/// <summary>
	/// Group of highlighted cells (used in step-by-step generation).
	/// </summary>
	public SvgGroup? HighlightedCellsGroup { get; set; } = new()
	{
		Fill = SvgColor.Gray,
		Stroke = SvgColor.Gray,
		Id = "highlightedCells"
	};
	/// <summary>
	/// Group of a selected cell (used in step-by-step generation).
	/// </summary>
	public SvgGroup? SelectedCellGroup { get; set; } = new()
	{
		Fill = SvgColor.Red,
		Stroke = SvgColor.Red,
		Id = "selectedCell"
	};
	/// <summary>
	/// Group of maze graph nodes.
	/// </summary>
	public SvgGroup? NodesGroup { get; set; } = new()
	{
		Fill = SvgColor.White,
		Stroke = SvgColor.Black,
		StrokeWidth = 1f
	};
	/// <summary>
	/// Group of unvisited nodes (used in step-by-step generation).
	/// </summary>
	public SvgGroup? UnvisitedNodesGroup { get; set; } = new()
	{
		Fill = SvgColor.Gray,
		Stroke = SvgColor.Black,
		Id = "unvisitedNodes"
	};
	/// <summary>
	/// Group of highlighted nodes (used in step-by-step generation).
	/// </summary>
	public SvgGroup? HighlightedNodesGroup { get; set; } = new()
	{
		Fill = SvgColor.Blue,
		Stroke = SvgColor.Black,
		Id = "highlightedNodes"
	};
	/// <summary>
	/// Group of a selected node (used in step-by-step generation).
	/// </summary>
	public SvgGroup? SelectedNodeGroup { get; set; } = new()
	{
		Fill = SvgColor.Red,
		Stroke = SvgColor.Black,
		Id = "selectedNode"
	};
	/// <summary>
	/// Shape of maze graph nodes.
	/// </summary>
	public SvgShape? NodeShape { get; set; } = new SvgCircle()
	{
		R = NodeRadius,
		Id = "node"
	};
	/// <summary>
	/// Flag which determines whether walls should be exported as separate paths.
	/// </summary>
	public bool ExportWallsAsSeparatePaths { get; set; } = false;
	/// <summary>
	/// Path used for displaying maze walls.
	/// </summary>
	public SvgPath? WallsPath { get; set; } = new()
	{
		Fill = SvgFill.None,
		Stroke = SvgColor.Black,
		StrokeWidth = 2f,
		StrokeLinecap = SvgLinecap.Square
	};
	/// <summary>
	/// Path for maze graph edges.
	/// </summary>
	public SvgPath? EdgesPath { get; set; } = new()
	{
		Fill = SvgFill.None,
		StrokeWidth = 1.5f,
		Stroke = SvgColor.Gray
	};
	/// <summary>
	/// Path for maze passages.
	/// </summary>
	public SvgPath? PassagesPath { get; set; } = new()
	{
		Fill = SvgFill.None,
		StrokeWidth = 1.5f,
		Stroke = SvgColor.Red
	};
	/// <summary>
	/// Group for directed edges.
	/// </summary>
	public SvgGroup? DirectedEdgesGroup { get; set; } = new()
	{
		Fill = SvgFill.None,
		StrokeWidth = 1.5f,
		Stroke = SvgColor.Red
	};
	/// <summary>
	/// Get an arrow used for directed edges.
	/// </summary>
	public SvgMarker DirectedEdgeArrowMarker => new()
	{
		Id = "directedEdgeArrow",
		Orient = SvgMarkerOrient.Auto,
		MarkerWidth = 3f,
		MarkerHeight = 4f,
		RefX = NodeRadius / (DirectedEdgesGroup!.StrokeWidth != null ? DirectedEdgesGroup.StrokeWidth.Value.Value : 1) + 2.5f,
		RefY = 1.5f,
		Shape = new SvgPath()
		{
			D = "M0,0 V3 L2.5,1.5 Z",
			Fill = DirectedEdgesGroup.Stroke,
			Stroke = SvgFill.None
		}
	};
	/// <summary>
	/// Path used for a solution.
	/// </summary>
	public SvgPath? SolutionPath { get; set; } = new()
	{
		Fill = SvgFill.None,
		StrokeWidth = 1.5f,
		Stroke = SvgColor.Blue
	};

	// IEnumerable for selected cell of generator
	private static IEnumerable<MazeCell> SelectedCellEnumerable(MazeGenerator generator)
	{
		if (generator.SelectedCell != null)
			yield return generator.SelectedCell;
	}

	/// <summary>
	/// Gets a maze exporter with all settings applied.
	/// </summary>
	/// <param name="generator">Generator that is/was used for maze generation.</param>
	/// <param name="isGenerated">Flag that determines whether maze is generated and ready for pathfinding.</param>
	/// <param name="minify">
	/// When <see langword="true" />, some settings will 
	/// be ignored in order to minify output SVG as much as possible without
	/// touching its appearence.
	/// </param>
	/// <returns>
	/// A maze exporter with all settings applied.
	/// </returns>
	public MazeSvgExporter GetExporter(MazeGenerator generator, bool isGenerated, bool minify = false)
	{
		Maze maze = generator.Maze;
		MazeSvgExporter exporter = new(generator.Maze, CellSize, Padding);
		if (!minify && ExportDescription)
		{
			exporter.Add(MazeDescription.Default);
		}
		if (BackgroundFill != null)
		{
			exporter.Add(Background.Create(BackgroundFill));
		}

		#region Cells
		if (AllCellsGroup != null)
		{
			exporter.Add(Cells.All(AllCellsGroup));
		}
		if (UnvisitedCellsGroup != null)
		{
			exporter.Add(Cells.Selected(
				maze.Cells.Where(c => !generator.VisitedCells[c] && !generator.HighlightedCells[c]),
				UnvisitedCellsGroup));
		}
		if (HighlightedCellsGroup != null)
		{
			exporter.Add(Cells.Selected(
				maze.Cells.Where(c => generator.HighlightedCells[c]),
				HighlightedCellsGroup));
		}
		if (SelectedCellGroup != null)
		{
			exporter.Add(
				Cells.Selected(SelectedCellEnumerable(generator), SelectedCellGroup));
		}
		#endregion

		if (WallsPath != null)
		{
			WallsPath.StrokeWidth = WallsWidth;
			if (ExportWallsAsSeparatePaths)
			{
				exporter.Add(Walls.AsSeparatePaths(null, WallsWidth, WallsPath));
			}
			else
			{
				exporter.Add(Walls.AsOnePath(WallsPath, WallsWidth));
			}
		}

		#region Graph edges
		if (EdgesPath != null)
		{
			exporter.Add(Edges.OfBaseGraph(EdgesPath, false));
		}
		if (PassagesPath != null)
		{
			exporter.Add(Edges.OfPassagesGraph(PassagesPath));
		}
		if (DirectedEdgesGroup != null && 
			generator is IDirectedGraphGenerator directedGraphGenerator)
		{
			var directedEdges = directedGraphGenerator.DirectedMaze.DirectedEdges;
			SvgPath path = new()
			{
				MarkerEnd = DirectedEdgeArrowMarker
			};
			exporter.Add(Edges.Directed(directedEdges, DirectedEdgesGroup, path));
		}
		#endregion

		if (SolutionPath != null && isGenerated)
		{
			exporter.Add(Solutions.All(pathCreator: _ => SolutionPath));
		}

		#region Nodes
		if (NodesGroup != null)
		{
			exporter.Add(Nodes.All(NodeShape, NodesGroup));
		}
		if (UnvisitedNodesGroup != null)
		{
			exporter.Add(Nodes.Selected(
				maze.Cells.Where(c => !generator.VisitedCells[c] && !generator.HighlightedCells[c]),
				NodeShape,
				UnvisitedNodesGroup));
		}
		if (HighlightedNodesGroup != null)
		{
			exporter.Add(Nodes.Selected(
				maze.Cells.Where(c => generator.HighlightedCells[c]),
				NodeShape,
				HighlightedNodesGroup));
		}
		if (SelectedNodeGroup != null)
		{
			exporter.Add(
				Nodes.Selected(SelectedCellEnumerable(generator), NodeShape, SelectedNodeGroup));
		}
		#endregion

		// Add a default export module in a case when user unchecked all modules
		if (!exporter.Any(x => x is not MazeDescription and not Background))
		{
			exporter.Add(Walls.AsOnePath());
		}

		return exporter;
	}
}
