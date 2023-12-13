# ftw-worksample
The focus of the test will be on accuracy of the requirements met, coding techniques and decisions made.
* Assessment will be made regarding how to structure, design and organise the code, readability and quality to determine the OOP skills and how to implement requirements.
* Also good with refactoring the code and have running tests to ensure everything works and the quality of code is high.

## Instructions for the worksample
The test is the following:
Implement a game with the following features

* There are 20 balls in a basket.
* Each game turn a player picks a ball.
* To pick a ball the player pays 10 credits.

### Balltypes
Each ball will give you either a ”win”, ”extra pick” or ”no win” (in case of extra pick, you will draw
another ball with no cost).

* Win<br>
* Extra pick<br>
* no win<br>

### Gameplay features
* From these 20 balls, 5 of them will give you 20 credits (”win” type), 1 of them will give you extra
pick(”extra pick” type) and 14 of them no win (”no win” type).
* After each pick you will place the ball back to the basket. After each win the balance of the
player will get updated with the win amount.

### Rules
* You should be able to run/simulate your game with a specified number of rounds* via a player
with unlimited credits and then calculate the RTP (return to player).
* RTP = ( (number of won credits) / (number of credits that are spent to play the game))*100.
* One round contains the event(s) that you pay for the current picked ball till(not including) the
next paid picked ball. 

##### Example scenarios
* For example you pay for a pick and after the pick the ball turns out to be
an ”extra pick” ball (first event), then you place the ball back and pick another one for free and
turns out that ball is a ”no win” ball(second event), these two events/picks are considered as
one game round. 
* Following scenario is also a game round with one event/pick: Pay for a pick
and pick a ball then the picked ball is a ”win” ball update the balance

---
## Reflections
A fun assignment, ideally with more time I would had liked to do larger refactorings, more tests,
and worked more with IGame interface, so that it would serve as a base blueprint for future games.

Or perhaps have an interface for different types of games and move current public void Simulate(....) which reside in IGame, to an own interface ISimulate.

Yeah, there can be done alot more to further simplify the the code, but overall I like the structure where each game is responsible for it's own game-loop. And to be able from the outside
to simulate statistics without messing around too much with the gamecode.
