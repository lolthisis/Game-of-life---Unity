# Game-of-life--Unity
Made with Unity 2018.4.0f1

## Instructions:
```
Open Scene GameOfLife.unity
  
->Calibrate your board using gameManager script on GameObject --Manager--
  -Set the no of rows and cols
  -Set time between each tick(generation)
  -Adjust Percentage of cell starting alive
  
->Press Play
  ->Press on any cell to toggle it's state.
  ->Press randomize to generate random grid.
  ->Press Next Generation for going through generation stepwise.
  ->Press Space or Button on left to Pause/Play in runtime.
```
## Conway's game of life:

The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, alive or dead, (or populated and unpopulated, respectively). Every cell interacts with its eight neighbors, which are the cells that are horizontal, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

Any live cell with fewer than two live neighbors dies, as if by underpopulation.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by overpopulation.
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed; births and deaths occur simultaneously, and the discrete moment at which this happens is sometimes called a tick. Each generation is a pure function of the preceding one. The rules continue to be applied repeatedly to create further generations.

