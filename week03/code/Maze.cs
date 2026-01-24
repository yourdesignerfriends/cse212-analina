/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        // Get the list of allowed movements for my current position.
        var moves = _mazeMap[(_currX, _currY)];
        // Check if I am allowed to move left (index 0).
        bool canMoveLeft = moves[0];
        // If I cannot move left, it means there is a wall.
        if (!canMoveLeft)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // If the movement is allowed, update my position by moving one space to the left.
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        // Get the list of allowed movements for my current position.
        var moves = _mazeMap[(_currX, _currY)];
        // Check if I am allowed to move right (index 1).
        bool canMoveRight = moves[1];
        // If I cannot move right, it means there is a wall.
        if (!canMoveRight)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // If the movement is allowed, update my position by moving one space to the right.
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        // Get the list of allowed movements for my current position.
        var moves = _mazeMap[(_currX, _currY)];
        // Check if I am allowed to move up (index 2).
        bool canMoveUp = moves[2];
        // If I cannot move up, it means there is a wall above me.
        if (!canMoveUp)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // If the movement is allowed, update my position by moving one space up.
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        // Get the list of allowed movements for my current position.
        var moves = _mazeMap[(_currX, _currY)];
        // Check if I am allowed to move down (index 3).
        bool canMoveDown = moves[3];
        // If I cannot move down, it means there is a wall below me.
        if (!canMoveDown)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // If the movement is allowed, update my position by moving one space down.
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}