# Milestone 1 update
![433266337_769678508436119_6345311170332218933_n (1)](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/ae72f703-6e6c-4104-9b2c-ff3a03179ed3)

In the first milestone of our game, the primary focus was to create a
captivating platformer experience. Games from the MetroidVania genre
have a unique sense of exploration based on the player's ability to
traverse a dangerous environment with different obstacles. Our focus
lies in ensuring that the platforming mechanics are finely tuned for
precision, allowing players to feel in complete control of their
character. This approach allows the player to experience a sense of
accomplishment while performing challenging tracks and moving through
the objectives of the world.

## Player movement

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/0a2faae2-1ff3-433d-b1e7-ab0ee2082fc1)

For our player movement we used a lot of conventional tricks that are
used in other platformers to convey movement. Our player controller uses
different physics to move the player's rigidbody2d. When the player
wants to move, an acceleration is applied in the direction of the
movement input. If the player stopped moving, friction is applied, and
after some time the player will stop. Implementing the jump was a
challenge since making a good jump involves multiple parts in developing
it. After pressing the jump key, the first jump force is applied to the
player and at the apex of the jump gravity is multiplied, making the
player fall faster. By making the player fall faster the landing is
easier to control. After implementing some bounciness materials (like
the mushroom), we realized that our player could reach very high
velocities while jumping. To solve this problem, there is a cap on the
fall of the player, and after the player reaches the maximum fall speed
then a slow fall effect is applied on the player. For better
organizations we put each of the player states in a finite state
machine.

## Platforms

For this milestone, we managed to implement 3 types of platforms. The
player can interact with them to advance through the world or introduce
unexpected challenges, adding a layer of danger to the gameplay
experience.

### Moving Platforms

We added a moving platform to make the player cross the level avoiding
the hazards.\
To successfully move from one side of the obstacles to the other, it is
important to time the movement with the platform that is speeding up
from one side to the other. There are two position points that delimit
the moving platform position on the screen.\
Adding the moving platform on top of the obstacles adds more excitement
and makes the player feel more engaged in the game.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/d7f7cb29-4ef5-4e53-9814-7c9871258df9)


### Falling Platforms

We introduced the concept of falling platform as another layer of
difficulty for the player or as a surprise element. While having the
same appearance as a normal platform, these tricky obstacles are hard to
avoid and require good reflexes. Those platforms are simple objects that
checks for the player tag and once the player collides with them then
they begin falling after a specific number of seconds by changing their
rigid body to a dynamic state. In the end, the platforms are destroyed
to to release memory resources.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/6c3eb03b-eba2-4d4f-b34e-5798eaed926a)


### One-way Platforms

These platforms were added to improve the game design of the levels as
well as the game experience of the player. One-way platforms are usually
one of the must have elements of a platformer and they give a lot more
options of explorations by increasing the layers of a map. To make the
player able to advance and jump through these platforms the Platform
effector 2d component was used. Once the player is on this type of
platform, he can also descend by pressing the down key. To make this
possible the collision between the player and the platform was ignored
while perfoming this action.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/75181b8c-36a9-4e73-a138-d2aa28b5f0d7)


## Hazards Creation

We have added spikes and water to create a challenging game experience
for the player.\
The spikes have a custom physics shape that is used to detect when the
player falls and collide on them.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/b81c88cd-fd11-448e-89fe-68abdf7efb50)


If the player falls on the water or on the spikes, he dies. In order to
avoid these hazards, it is necessary to carefully jump away from them.
If the player dies the camera will shake a little and the character will
slightly jump. This design creates an engaging and challenging gameplay
experience that tests the ability of the player to progress through the
level.

![433266337_769678508436119_6345311170332218933_n](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/6f4565b8-23e7-477c-9e78-c3d2950bc4db)


