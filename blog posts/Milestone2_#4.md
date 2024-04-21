# Milestone 2 update

## Description

## Level design

### Biomes

### design

### Icy / Slippery Platforms

Icy platforms were added as part of the snow biome. Once the player steps on these platforms, the player will slip as long as interacts with them. To create the slippery effect we used OnCollisionEnter2D by checking for Player tag. Once the player collide with this type of platform its friction is reduced to a point where its movement will make him slide thorough this platform. To get back to its original friction, we used the method OnCollisionExit2D so that the Player returns to its original friction once it touches something else.
![OnCollisionEnter2D](image.png)
![OnCollisionExit2D](image-1.png)

### Parallax

With this new milestone we have introduced a proper background to our levels, creating the effect of a parallax. Each layer of the background being its own layer and acting with a different speed. The parallax will make it seem like certain elements are closer and moving faster, while others appear farther away and move slower, giving our levels a more dynamic feel.
![Parallax implementation](image-2.png)
To create this effect we calculate the horizotanl distacen between the camera and the background layer, adjustign the background position accordingly based on 
a specific parallax speed strength. By updatign the background position in relation to the camerae movement, the script create the illusion of a parallax
![Parallax effect](<2024-04-21 22-40-57.gif>)

## Combat

### Character dash
A new character state was introduced, the dash state. By pressing or holding the dash button, the player will be able to instantly dash into a desired 
location or to wait a specific time before dashing so that it can take the decision of selecting a direction. While holding, the time will slow down around
the player so that the decision time will minimize the impact of the game during that moment. On entering the deshing state the ability to dash once again is disabled, the direction of the dash is set to point the location of the mouse or of the joystick, the direction arrow is displayed and the time is slowed down.
![OnEnter Dash](image-3.png)
The logic of dashing is that if the player is holding the dash input, it updates the dash direction arrow based on input and executes the dash when the input stops or a maximum holding time is reached. If the player is not holding the dash input, it continues the dash until the dash time duration expires. At the end the ability is marked as done and the parameters are reseted for the next potential dash
![Dash logic](image-4.png)
In the game the dash mechanic looks something like this:
![Dash overview](<2024-04-21 23-03-41.gif>)
### Slimes

### Birds

### Attack






