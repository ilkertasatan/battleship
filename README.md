## Battleship Game

This is the Battleship game just for one single player. When the game is run, the game itself places a battleship and two destroyers, once ships have been placed, the game prompts you the fire coordinate and the rest is being simulated by the game itself. The game keeps continuing until all ships have been sunk.


### Object Modeling

The game consists of `Game`, `Player`, `GameBoard`, `Grid` and `Ship`.

#### Game

This the main object and it's responsible for starting game calling `Start` method. Once it's been called, ships will be placed randomly.

#### Player

This object is responsible for firing to the given coordinate and also responsible for making a bridge between `Game` and `GameBoard`.

#### GameBoard

This object is responsible for creating a game board and it has grids and ships on itself.

#### Grid

This object is a critical part of the game. Once the game is started, grids are being populated based on the given `row` and `column`. Each ship is placed on a grid based on its size.

#### Ship

This object is also critical. In the game, there are two different types of ships. One is `battleship`, the other one is `Destroyer`. Each has a different size and they can be placed either `horizontal` or `vertical` on the grid.


### Game Structure

I tried to model this exercise like real-life as much as I can. Even though this exercise is a good example of using `Polymorphism`, I tried to eliminate it due to avoid complexity. You will see extension classes instead.
Apart from that, I also tried to separate functionalities by interfaces meaning I followed `Interface Segregation Principle`.


### How To Run

This exercise has been developed by using .NET Core so you must install it before running.

There is a Powershell script inside the project called `run-game`. In any terminal, all you need to do is run this script.

```powershell
.\run-game.ps1
```

Note: If you are using a different OS rather than Windows, please make sure that Powershell core has been installed.

## Conclusion

Thank you for giving me the chance to show what I can do. I hope that you like my solution.
