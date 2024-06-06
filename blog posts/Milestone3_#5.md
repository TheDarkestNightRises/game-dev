# Milestone 3 update

## Description
N/A

## Enemy AI
![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/89553ce8-2e9f-4d72-9b9d-69988f99f62f)

Similar to the player, the enemy AI is made using a state machine. The enemy first starts in the move phase where they wander around the platform before a ledge is detected, making them turn arround so that they don't fall. At certain intervals they change their transition to idle. If an enemy spots the character then they go into the pursue state, while they move faster towards the enemy. If somehow the player jumps over the enemy or if the enemy loses track of its target then they go into investigate mode, where they try to turn arround and find the player. The enemies have a certain attack range and if they are close to the player they start attacking. The attack state is invoked by playing the attack animation which contains triggers for when the attack has finished. If the attack has finished and the player is in the radius of the attack(represented by a circle) then they will take damage. If their health bar is depleted, the enemy drops the coins as well as dissabling their rigidbody so that the player cannot attack anymore. For a nice touch, the sprite of the enemy sits on the ground for a few seconds, after which is destroyed. If there are a lot of enemies on the map an object pool could be used , but on each level there are arround 2-3 enemies.
Separating the enemy into multiple states made a lot of the code easier to handle because the logic of the states are isolated. Many of the enemies in the game behave in the same way, so inheritance was used by creating a base entity class as well as base states. Adding animations or vfx was easy since the animator can invoke different animations for the enemy current state. This approach can also be more performant since the enemy is only in one state at a time , and doesn't have to check the conditions for other states. 

## Shader Graph
![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/04ce6ade-6413-4f5c-ad47-f9e4e01646ae)
Shader graph is a tool that enables developers to build shaders using a visual scripting languange. As a simple example , a wind shader graph was built, one that sways the sprite in a certain direction. We can change the position of the sprite in a random position using a noise gradient. This noise gradient is added on the x position of the sprite by spliting the position of the sprite and combining it back later with the original values. For the bottom of the sprite be grounded in the world, a UV map was used and multiplied with the random noise created by the random noise. Paramaters where also added for the wind strength and the wind speed to change how the sprite looks for different materials. The wind speed controls the scale of the gradient noise , while the wind strength multiplies the output of the noise.By combining all of this a nice effect is created where the sprites move back and forth making the world a bit more dynamic.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/91905169/40ca2d9c-4ad0-4556-a3fe-a2719c969f42)

## Hp bar

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/1beb22d7-8334-41dd-a348-ac1110afac6e) 

The hp bar was made as an UI Slider element that would subscribe to the OnPlayerHealthChanged event which triggers each time the player hp changes.
The visual representation of the HP bar is calculated as a percentage between the current health and the max health of the player.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/42a5253e-cd9b-46ec-92c2-6d48342beccb)

## Loot & Collect

The loot was made using an array of GameObjects which is instantiated in a for loop once an enemy dies. To apply the looting to all the enemies the array 
was inserted in the entity base class from which each enemy could have its loot. The spawn of the loot was calculated based on the position of the enemy 
by adding its height to create a smooth splash drop.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/1d0dc95d-e1f3-47f7-a786-729ca1ea0063)

To be able to loot the coins, the OnTriggerEnter2D method was used so that when the player collides with a coin the Coin Gameobject would be added to the 
game session's current gold. After that, the coin object is destroyed. For the coins to be collected by the player, but at the same time to collide with each other
2 box colliders were added to the coin object: one with "Is Trigger" checked for them to be collectible and one without so that they would have a collision.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/cfdc176a-c85d-446b-99fe-4ab11731a333)

## Shop

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/edbfaef3-c4e9-4fc8-a247-44018fb88b39)

The shop is a game object that has two scripts. The first script "Shop interactions" is used to track the position of the player in relation to the shop. Once the player
is in the range of the shop, the shop becomes interactable and by pressing the "open shop" button, the player would be able to buy from the 3 displayed options.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/18b9bf6b-719e-45b6-a266-7fba09d327ac)

The second script which is the buying script has a reference to the game session and one to the player. Each time a purchase is made the game session gold is decreased. Since the
options of the shops are: increase damage, increase max health, or heal, a reference to the player was made to change those variables from the player data.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/e9561ed7-54fa-42d5-be4a-53d447e1ad27)

## UI Menus

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/474585e1-0d60-41c4-ab16-ff452bf76650)

Each menu was created using canvas elements. To assign functionality to the buttons each menu comes with a MenuManager from where the transition between the menus is made
with the help of the scene manager. The sliders have their slide handler for a separate implementation. 

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/9037af17-de51-4121-9155-620c60fc2522)

## Snow biome

The snow biome was added to the game consisting of icy platforms, snow mountains parallax background, frost enemies, and a brand-new thematic!

![image](https://github.com/TheDarkestNightRises/game-dev/assets/93666980/0aed04bb-5973-45f1-b0a6-9001b4b5665a)


## Rain
![Unity_c4Lf6BTgrg](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/13b6b219-9c11-41b5-9a53-7583b0125345)

Rain effects can also serve as a narrative tool to set the mood of a scene, amplifying the emotional weight of a moment or emphasizing a sense of urgency or tension. Additionally, rain can contribute to a tranquil and calming atmosphere in a peaceful setting.
Finally, to really bring the game world to life, we added dynamic rain effects. By combining Unity's particle system with C# scripting, I created a realistic weather system that reacts to player actions and provides an additional layer of depth to the game. 

![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/5f480fa3-b35d-4c96-8e7b-1453921c6c46)

First, I set the duration of the rain effect to 5, ensuring a continuous rainfall throughout the scene. I enabled looping to maintain this consistent rain effect and utilized the pre-warm feature to gradually introduce the rain, creating a natural progression in intensity.
I chose a light blue, semi-transparent color for the raindrops to mimic the appearance of real-world rain while maintaining a visually appealing aesthetic. To further enhance the rain effect, I adjusted the emission settings to control the rate and volume of raindrops, creating a more dense or sparse rainfall as desired.
For the shape of the raindrops, I selected an elongated, tapered form to accurately represent the appearance of falling rain. To create a more dynamic effect, I applied a velocity over lifetime setting, which causes the raindrops to accelerate as they fall, simulating the effect of gravity.
Lastly, I implemented a color over lifetime setting to introduce subtle variations in the hue and transparency of individual raindrops over time. This creates a more organic and visually interesting rain effect, ensuring a polished and immersive experience for players.



## Pendulum

![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/254947c2-0cec-4bff-8222-0c0f5a3c1914)

Incorporating a pendulum in game design can have a profound impact on user experience, as I've seen firsthand. It can create interactive and engaging gameplay mechanics while enhancing the visual appeal of the game. In my experience, players appreciate innovative elements that add excitement and immersion to their gaming experience. Ultimately, integrating a pendulum into a game can offer a unique and memorable experience for players while also inspiring designers to push boundaries in their creations.

![ac63957bf9ee4eda3659b0f72c798d06](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/bcd97ab9-9163-4919-9faf-71e7bc38d514)

ChangeMoveDir: This method updates the movingClockwise flag by checking the pendulum's current rotation against the specified leftAngle and rightAngle values. It ensures that the pendulum swings back and forth between these angles by toggling the movingClockwise flag when the pendulum reaches either angle limit. This enables the swinging motion of the pendulum by alternating its direction of rotation.
If the pendulum's rotation (transform.rotation.z) is greater than the rightAngle, the pendulum should swing counter-clockwise, so the method sets movingClockwise to false.
If the pendulum's rotation is less than the leftAngle, the pendulum should swing clockwise, so the method sets movingClockwise to true.
Move: This method controls the pendulum's movement by updating its angular velocity based on the movingClockwise flag. The method is called every frame in the Update method, ensuring continuous movement.
The method first calls ChangeMoveDir to update the movingClockwise flag if necessary.
If movingClockwise is true, the method sets the angularVelocity of the Rigidbody2D (rb2d) to the moveSpeed, making the pendulum rotate clockwise.
If movingClockwise is false, the method sets the angularVelocity to the negative moveSpeed, making the pendulum rotate counter-clockwise.
Together, these methods create the swinging motion of the pendulum by alternating its rotation direction between clockwise and counter-clockwise based on its current rotation angle.


## Canon
![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/99625460-4692-4f41-aa2f-c9f6272e1ac2)

Implementing a cannon in game design can significantly impact the user experience.It adds a dynamic and interactive element to the gameplay, inviting players to experiment with different strategies and engage more deeply with the game environment. Players often appreciate the excitement and challenge that powerful elements like cannons bring.

![c2e26b890d1eea69e2f86859aa15d533](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/f8aeec3f-b202-4f1a-a026-1ca011aa306b)

Attack: This method executes the gun trap's attack sequence. It first resets the cooldownTimer to 0, allowing a new attack cycle to begin. Then, it retrieves an available fireball object from the fireballs array using the FindFireball method and sets its position to the firePoint location. After positioning the fireball, it activates the fireball's EnemyBullet component by calling its ActivateBullet method, effectively launching the projectile. Lastly, it triggers the "Fire" animation in the gun trap's Animator by calling Anim.SetTrigger("Fire"), providing visual feedback for the attack.
FindFireball: This method searches the fireballs array for an inactive fireball object that can be used in the attack. It iterates through the array using a for loop and checks if each fireball object is inactive in the game's hierarchy (!fireballs[i].activeInHierarchy). If an inactive fireball is found, the method returns its index. If no inactive fireballs are found, the method returns 0, which corresponds to the first fireball object in the array, ensuring there's always a projectile available for the attack.


## Dialogue UI 

![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/22fd2c3a-aff7-4fc7-ba72-946af437608e)

Dialog UI is an important aspect of game design, as it impacts players' experience by influencing how they perceive and interact with the game. It's important to design a dialog UI that is intuitive, visually appealing, and supports the game's narrative and overall theme. In the game, the dialogue UI is a crucial element for guiding players towards their ultimate objective of finding keys to advance to subsequent levels. Dialogues have been strategically integrated into the gameplay to convey essential hints and information about key locations, thus supporting the player's progression through the game. In doing so, the dialogue UI enhances the user experience by ensuring players are well-informed and engaged while providing a sense of direction and accomplishment as they navigate through different levels.

![00396c7e6711324ec5311810e4c62502](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/9f48e6d1-c702-47f8-bb4b-958dd2fe483a)

the DisplayNextDialogueLine method, handles the display of dialogue lines in the game.
The method first checks if there are any remaining lines in the dialogue queue (lines.Count == 0). If not, it ends the dialogue by calling the EndDialogue method and returns. Otherwise, it retrieves the next DialogueLine object from the queue (lines.Dequeue()) and stores it in the currentLine variable.
The method then updates the characterIcon sprite and characterName text to reflect the current speaking character. It stops any existing coroutines (StopAllCoroutines()) to prevent any conflicts with the typing animation.
Finally, it calls StartCoroutine(TypeSentence(currentLine)) to initiate the typing effect for the current dialogue line, gradually displaying the text character by character.
The rest of the script manages the overall dialogue system, including setting up the singleton instance, starting a new dialogue, and ending the dialogue when there are no more lines to display.

![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/20ce1de5-6ec5-4ea0-973d-8170587df2f8)

the DialogueTrigger class, which handles initiating dialogue when the player enters a trigger area.
The DialogueTrigger script contains a public Dialogue variable (dialogue) that can be assigned in the Unity editor.
The TriggerDialogue method calls the StartDialogue method of the DialogueManager singleton (DialogueManager.Instance.StartDialogue(dialogue)) to start displaying the dialogue lines from the assigned dialogue variable.
The OnTriggerEnter2D method is an important Unity callback that detects when another object enters the trigger area. In this case, it checks if the object's tag is "Player" (collision.tag == "Player"). If it is, the TriggerDialogue method is called, initiating the dialogue sequence.
The rest of the code consists of serializable classes (DialogueCharacter, DialogueLine, and Dialogue) used to structure and organize dialogue data within the Unity editor, making it easier for game designers to create and manage character dialogues.


## Doors

![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/a1c9f333-bfdf-4fcc-80b1-327ec7ae8bef)

The incorporation of doors in the game serves as a vital component in enhancing both user experience and gameplay. These doors are not just static objects; they play a dynamic role in facilitating smooth transitions between levels. Defeating monsters and collecting the floating keys adds a layer of challenge and accomplishment to the gameplay, making the unlocking of doors an exhilarating experience for players. The moment a key approaches the door, it unlocks and opens, signifying progress and achievement. This innovative gameplay mechanic not only encourages exploration but also contributes to a heightened sense of immersion and engagement for players, highlighting the importance of well-designed and unique elements in elevating the overall user experience.
![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/e19e9271-728e-43ac-a83f-2e2c8f21e3bf)
The OnTriggerEnter2D method listens for any 2D collider entering the area defined by this script's collider. If the collider that enters has the "Player" tag...
It checks whether the player is already following a key. If so...
It updates the followTarget of the key that the player is following to be the door's transform (essentially, it tells the key that it should follow the door now).
It sets the waitingToOpen boolean to true, which is then used in the Update method to wait until the player is close enough to the door before opening it.

## Key
![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/d367bd73-9b67-4f64-bb64-8529fcd994ef)
![image](https://github.com/TheDarkestNightRises/game-dev/assets/85575367/c1789d83-326e-4b72-97f9-7c6546b5251a)

Inside the Update method, the script checks if the key is currently following a target (isFollowing). If it is, the script updates the position of the key object using Vector3.Lerp to interpolate between its current position and the target's position. The followSpeed variable determines how quickly the key moves toward the target, and Time.deltaTime ensures the movement is based on real-time.
The OnTriggerEnter2D method is also significant, as it sets up the following behavior when the player enters the key's trigger area. It finds the PlayerScript component on the player object and assigns the key's followTarget to the player's keyFollowPoint. Then, it sets isFollowing to true and assigns the current key object to the player's followingKey variable, establishing the connection between the key and the player.

So there you have it, a quick peek into our game development journey using C# and Unity. We hope our experiences inspire you to explore new possibilities in your own game development endeavors. Happy coding, and see you next time!

