# Othello (Riversi) Game with A* Search Algorithm
[Riversi](https://en.wikipedia.org/wiki/Reversi) is a strategy board game for two players, played on an 8×8 unchecked board. There are sixty-four identical game pieces called disks (often spelled "discs"), which are light on one side and dark on the other. Players take turns placing disks on the board with their assigned color facing up. During a play, any disks of the opponent's color that are in a straight line and bounded by the disk just placed and another disk of the current player's color are turned over to the current player's color.

The object of the game is to have the majority of disks turned to display your color when the last playable empty square is filled. [1]
The popularity of [Riversi](https://en.wikipedia.org/wiki/Reversi) which is another widely known name for [Othello](https://en.wikipedia.org/wiki/Reversi) can often be attributed to the complex strategies it employs. Advanced mathematics has been used to analyze the varying permutations and algorithms that result when looking into the game more deeply. For a more commonplace overview, a focus on three key elements can help players to develop a certain amount of strategy to their approach. These are the use of corners and edges, and deliberately restricting movement possibilities for their opponent. 
These 4 positions on the board are often seen as the essential aim of the game. Once a player is in possession of the corner pieces their pieces are static and control of the board belongs to them. This is true to a certain degree, certainly if two opposite corner pieces are taken at the right time in such a way that all the edge pieces in between also become static then a very strong advantage is gained. [2]

The complexity of possible moves toward the final solution in this game is great. Finding a path goal state from initial state might take great time for an average computer. In order to be able to find a solution to Othello game and determine the best move for the agent I am going to use a search strategy namely [A* Search Algorithm](https://en.wikipedia.org/wiki/A*_search_algorithm) ([heuristic](https://en.wikipedia.org/wiki/Heuristic_(computer_science))). A* is an informed search strategy or heuristic search strategy which can use some information to determine its way through goal state. [3]
     
## Authors
[**Oğuz Ceylan**](https://github.com/oguzc)

## References
* [1]	"Reversi." Wikipedia. Accessed January 04, 2017. https://en.wikipedia.org/wiki/Reversi.
* [2]	"Othello Strategy." Othello. Accessed January 04, 2017. http://www.othelloonline.org/othello-strategy.php.
* [3]	Russell, Stuart J., and Peter Norvig. Artificial Intelligence: A Modern Approach. Englewood Cliffs, NJ: Prentice Hall, 1995.
