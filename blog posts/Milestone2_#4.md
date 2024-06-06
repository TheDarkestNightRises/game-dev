# Milestone 2 update

## Description
In this milestone, our main focus was on creating a coherent level design that can elevate the gameplay portion of the game as well as introducing combat. Players can now explore diverse biomes such as the murky Swamp and the frosty Ice areas, encountering new challenges and hazards along the way. Additionally, new enemies and combat mechanics were introduced like player attacks, dashes, and different enemies.

## Level design
For the level design, we made four biomes in total. Each biome represents a different location related to nature with its own unique identity. The desert represents an arid area with dunes and sand as well as mummies and pyramids. The Swamp biome has some platforms, and a parallax showing a background of old trees and roots. Moreover, on the scene there are some hazards like water and enemy slimes. The ice zones contain ice slides as well as snow polar bears and other Nordic creatures.
While designing the levels we added different platforming sections that should challenge the player.

## Swamp Platform
![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/1a6c6676-234e-4100-9b95-150d4abe8873)

The swamp level features an immersive environment with trees playing a prominent role in its design.
Ladders serve as the primary means of vertical navigation, allowing players to traverse the various levels within the swamp.
Moving platforms present a dynamic challenge, requiring precise timing and coordination. Some platforms break upon player contact, adding another layer of strategy and difficulty.
Collectible coins are scattered throughout the level, providing players with additional objectives to pursue.
Players will encounter enemies such as Tartars and green monsters, each necessitating unique strategies to defeat.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/17dbf4b5-b3ed-43bc-9486-5f1c5ef0cbfa)



### Icy / Slippery Platforms

Icy platforms were added as part of the snow biome. Once the player steps on these platforms, the player will slip as long as interacts with them. To create the slippery effect we used OnCollisionEnter2D by checking for Player tag. Once the player collides with this type of platform its friction is reduced to a point where its movement will make him slide through this platform. To get back to its original friction, we used the method OnCollisionExit2D so that the Player returns to its original friction once it.

![image-1](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/3778bfc0-4cea-4546-9597-871b35fa97cb)

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/7b7b7bdb-30f3-49b9-b8ef-0960512329b5)

### Parallax

With this new milestone, we have introduced a proper background to our levels, creating the effect of a parallax. Each layer of the background is its layer and acts at a different speed. The parallax will make it seem like certain elements are closer and moving faster, while others appear farther away and move slower, giving our levels a more dynamic feel.

![image-2](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/419f60d9-f422-4afb-b699-5a02a044801f)

To create this effect we calculate the horizontal distance between the camera and the background layer, adjusting the background position accordingly based on 
a specific parallax speed strength. By updating the background-position in relation to the camera movement, the script creates the illusion of parallax.

![1](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/a6f75388-c6ca-4667-84de-45251ee3c2cb)

## Combat

### Character dash
A new character state was introduced the dash state. By pressing or holding the dash button, the player will be able to instantly dash into a desired 
location or to wait a specific time before dashing so that it can decide on selecting a direction. While holding, the time will slow down around
the player so that the decision time will minimize the impact of the game during that moment. On entering the deshing state the ability to dash once again is disabled, the direction of the dash is set to point to the location of the mouse or of the joystick, the direction arrow is displayed and the time is slowed down.

![image-3](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/987d5b54-c507-42b5-8f26-51ecb51ba27b)

The logic of dashing is that if the player is holding the dash input, it updates the dash direction arrow based on input and executes the dash when the input stops or a maximum holding time is reached. If the player is not holding the dash input, it continues the dash until the dash time duration expires. At the end, the ability is marked as done and the parameters are reset for the next potential dash.

![image-4](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/8b8e10d6-b25c-4ede-aeb4-32704a205250)

In the game, the dash mechanic looks something like this:

![2](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/6da1d67d-71b4-4cc6-a8ce-b24e2959321f)

## Bats
![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/4ecf29ee-34ea-4bb0-af25-b942cb5a0955)
Alongside the existing challenges, the swamp level features three bats that introduce an additional element of gameplay.
These bats exhibit coordinated behavior, following the player's movements throughout the level. Players must adapt their navigation strategies to keep track of the bats' location while managing other environmental obstacles.
Engaging with the bats requires precise timing and planning, as they may attempt to evade or outmaneuver the player, adding complexity and interest to the gameplay experience.

## Snail
![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/2e48a42c-12e3-4d0b-9385-3abf4fa7c97b)
In addition to other challenges, the swamp level incorporates snails that contribute to the overall gameplay.
These snails move at a slow and steady pace, forcing players to adjust their timing and movement strategies accordingly.
Some snails may leave slippery trails, introducing additional hazards that players must navigate around to maintain traction and progress through the level.
Engaging with the snails and their trails requires careful observation and planning, encouraging players to adapt their approach based on the unique characteristics of these creatures.

## Bloat

![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/db85cfdb-6975-4c63-bc10-dfb4fd98b51f)
The swamp level includes green monsters that resemble cold bloats, adding another layer of challenge.
These monsters can shoot acid at players, necessitating quick reactions and strategic movement to avoid damage.
Players must maintain distance and use cover to protect themselves from acid attacks while engaging and defeating the green monsters.
The monsters' unique abilities encourage players to adapt their combat strategies and develop new tactics to overcome the threat.


### Birds
When designing birds in the game, we aimed for the unnatural movement of flight. Birds should be able to avoid obstacles as well as fly upwards towards the player, creating the illusion of the player being hunted down. To achieve this uncanny movement, we used the A* pathfinding library that can create paths based on 2d layers, similar to how NavMesh works. By setting the velocity of the bird as well as how much a bird should stay idle in one position, the bird keeps flying from one point to another but not reaching it instantly. The target is the player and the bird doesn't automatically know where the player is, but after a few seconds, the bird becomes aware of the location of the player. Overall this method of creating enemy pathfinding can help with different animals in our game, creating different patterns for grounded enemies as well.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/451d2af9-8e22-4209-8376-13fc4eb5eaa1)

### Melee attack

The player should be able to attack other enemies by using his axe, as well as perform combos. For this code to be reusable, a new attack state was created. The player has a weapon in his hand that contains an animator controller. Once the player starts attacking by using the input key for attack, the attack animator takes over the main one. The attack state remembers how many attacks the player has done, and calls the animator to animate the next one in the sequence. At the moment the player has a 3x hit combo with his axe, creating a dynamic combat. The player is also able to move a little during his attacks to change the direction of his attack. Each attack can be animated to contain a hitbox where the player's axe should hit. 

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/ec2d1894-d651-46ee-8039-700de7e0fb68)




