Blog post #1 - Roll a ball

repo link: https://github.com/Andrei-Lichi/Roll-a-ball
WebGL link: https://andrei-lichi.github.io/roll-a-ball-webgl/

Description:

Rolling a ball, the player would need to collect all the coins on the map

Movement:
 W - forward
 A - left
 D - right
 S - backward
 Space - jump

Winning condition:
 - collect 11 gold cubes
 - level resets (not implemented yet)


Winning consequences:
 - "Level completed" will be displayed

Losing condition:
 - fall out of map

Losing consequences:
 - gold will be reset
 - the ball will spawn in the initial spawn position
 - gold respawn (not implemented yet)

How was the game created?

1. Setup of the game

The creation of the game begins with creating a new Unity project using a 3D template and a scene for the game. After selecting the template, we added a new plane and named it 'ground,' which will be the field where the ball is going to roll. We moved the ground to origin and increased its size. Next, we created our player, which, in this case, is going to be a ball, by adding a new sphere object to the hierarchy. We moved it to the origin and raised it
a little bit higher to be on top of the ground.

For the last step of setting up the project, we created a folder that will contain two materials, one for the player and one for the ground. We made the ground green to match the color of the grass and the ball blue to differentiate it from the ground. Then, we dragged and dropped those materials directly onto the plane and sphere in the scene view to attach these materials to them.

2. Moving the ball

To make the ball move, we first added a 3D rigid body to the sphere object. Then, we installed the Input System package to be able to add a player input component to the ball. Afterward, we created an Input Action Asset in a new folder called "Input." Following that, we created another folder to hold our scripts and add a PlayerController script in there, attaching it to the ball as a script component.

We began by adding a new function called OnMove, which takes an InputValue as a parameter to determine the ball's movement on the x and y axes. Next, we created another function called FixedUpdate, where we retrieved the horizontal and vertical movement from the input system. We then constructed a new Vector3 with these values and applied it to the ball's rigid body. To modify the ball's speed directly from the inspector, we multiplied the Vector3 by a variable called speed.

3. Fix the camera on the ball

To fix the camera on the ball, we selected the camera that was given by the template and set its Y position to 10 and X rotation to 45 degrees to view the entire ground from above. Then we proceeded to write a CameraController script which would have two variables: the player object and a Vector3 offset where we stored the current offset between the camera and the ball at the beginning of the game. That means that the offset will be set in the Start function. In the LateUpdate function, we set the camera position to be equal to the current ball position + offset. Then the last step was to reference the ball to the camera variable in the player object.

4. Creating walls

To create the walls, we created an empty object called "Walls" which will store the 4 walls of the game (north, east, south, west). They are going to be children of the "Walls" object in the hierarchy. Each wall will be a cube that will be increased in size to match the actual length of the ground but also be taller than the ground. To ease our work once we created a wall, we rotate its position to match the other areas of the ground.

5. Creating the gold & make it colletable

In our case, the gold is a bunch of cube objects. We placed them a bit higher than the ground, made them smaller, and changed their rotation to gain a diamond shape. Then we created a yellow material to resemble a gold coin. Afterward, we created a folder for the gold and made the gold object a prefab. We created an object called "PickUp Parent" in which we will add all our gold prefabs.

To make the gold collectible in the player controller, we added a function called "OnTriggerEvent" that takes a collider as a parameter, which in our case will be the gold prefab. First, we gave our gold prefabs a tag, then we added in the script that if the tag of the collider matches the tag of the gold, we would set the gold active state to false, which will make it disappear. To make it work, we also needed to check the "isTrigger" box so that gold will not be a solid object.

6. Dispalying the gold & winning message

In the player controller, we added a variable called "gold," which we increment each time the OnTrigger event is called. Then we created a TextMeshPro UI Text, moved to a 2D view, and renamed it "gold." We then moved it to the top right corner. In the player controller, we created a TextMeshProUGUI variable and used it to update the text of the gold each time the value is incremented. The last step was to assign the UI Text to the text variable in the player controller.

For the winning message, the approach was the same, but this time for a "you win" message, which will only be displayed if the count reaches the number of gold pieces on the map. To only display the message when this condition is reached, in the start method, we set the active status of this message to false, and then when the condition is reached, we changed it to true.

7. Jump and losing condition

To make a ball jump, we added force to the rigid body of the ball, which is a Vector3 with the z-axis value increased. Then we multiplied that value with a jump speed variable that can be modified from the inspector. To be able to jump only once, we added a method OnTriggerEnter where we checked for the ground id. If the ball touches the ground, the canJump variable becomes true, and the jump force can be applied. Since now the ball can jump, we also have a losing condition: falling out of the map. To deal with this outcome, we checked the y-position of the ball, and if it reaches a smaller value than -40f, then the ball will be returned to the origin, and the score will be reset.





    