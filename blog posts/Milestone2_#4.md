# Milestone 2 update

## Description

## Level design

### Biomes

### design
## Game Design Swamp
The Slump biome wad added to the game level design. It has some platform and a parallax showing a background of old trees and roots. Moreover, on the scene there are some hazards like water, and enemy slimes. 
![ab687c30c841307d3d204e1f697939cc.png](:/d9aa0e639cb048688f77fbf57b002d6b)

### Icy / Slippery Platforms

Icy platforms were added as part of the snow biome. Once the player steps on these platforms, the player will slip as long as interacts with them. To create the slippery effect we used OnCollisionEnter2D by checking for Player tag. Once the player collides with this type of platform its friction is reduced to a point where its movement will make him slide through this platform. To get back to its original friction, we used the method OnCollisionExit2D so that the Player returns to its original friction once it.

![image-1](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/3778bfc0-4cea-4546-9597-871b35fa97cb)

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/7b7b7bdb-30f3-49b9-b8ef-0960512329b5)

### Parallax

With this new milestone, we have introduced a proper background to our levels, creating the effect of a parallax. Each layer of the background is its layer and acts at a different speed. The parallax will make it seem like certain elements are closer and moving faster, while others appear farther away and move slower, giving our levels a more dynamic feel.

![image-2](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/419f60d9-f422-4afb-b699-5a02a044801f)

To create this effect we calculate the horizontal distance between the camera and the background layer, adjusting the background position accordingly based on 
a specific parallax speed strength. By updating the background-position in relation to the camera movement, the script creates the illusion of a parallax.

## Combat

### Character dash
A new character state was introduced the dash state. By pressing or holding the dash button, the player will be able to instantly dash into a desired 
location or to wait a specific time before dashing so that it can decide on selecting a direction. While holding, the time will slow down around
the player so that the decision time will minimize the impact of the game during that moment. On entering the deshing state the ability to dash once again is disabled, the direction of the dash is set to point to the location of the mouse or of the joystick, the direction arrow is displayed and the time is slowed down.

![image-3](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/987d5b54-c507-42b5-8f26-51ecb51ba27b)

The logic of dashing is that if the player is holding the dash input, it updates the dash direction arrow based on input and executes the dash when the input stops or a maximum holding time is reached. If the player is not holding the dash input, it continues the dash until the dash time duration expires. At the end, the ability is marked as done and the parameters are reset for the next potential dash.

![image-4](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/8b8e10d6-b25c-4ede-aeb4-32704a205250)

In the game, the dash mechanic looks something like this:

### Slimes
The slimes moves horizontally both left and right, jumping. The slime enemy changes its direction when it collides with other objects in the game such as a wall. 
![dff380a79fc68a96d2a0a7e6f33de551.png](:/761b3c9a0165406797f6997d59f06655)
The FlipSprite() method is a private method that is used to change the sprite orientation based on the direction of the slime.
![870f24a5699550a3f7754c8ca863f3ce.png](:/7e49583a7eb5427e8fc49d41aaae4234)

### Birds

### Attack






