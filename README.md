# SnakeAI
## Download and Run
To run the program you will need [Visual studio](https://visualstudio.microsoft.com/)
## Snake
### Neural Network
Each snake contains a neural network. The neural network has an input layer of 6 neurons, 2 hidden layers of 8 neurons, and one output layer of 3 neurons. 
### Vision
The snake can see in 3 directions (Forward, Left and Right). In each of these directions the snake looks for 2 things:
* Is there a food?
* Is the naxt block in this direction is a wall or its own body?
3 x 2 = 24 inputs. The 4 outputs are simply the directions the snake can move.
## Evolution
### Natural Selection
Each generation a population of 12 snakes is created. For the first generation, all of the neural nets in each of the snakes
are initialized randomly. Once the entire population is dead, a fitness score is calculated for each of the snakes. Using these
fitness scores, some of the best snakes are selected to reproduce.In reproduction two snakes are selected and the neural
nets of each are crossed and then the resulting child is mutated.
### Fitness
A snake's fitness is simply how much food he ate during the game.
### Crossover & Mutation
When two snakes are selected for reproduction, what happens is that the snakes brains are crossed with
each other. What this means is that part of one parents brain is mixed with part of the second parents and
the resulting brain is assigned to the child. After the crossover both of the parents are continuing to the next generation.
## Save & Load
Models can be saved and loaded in order continue training them later. The weights for each connection are saved in a txt file.
