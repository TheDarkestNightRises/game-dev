# Milestone 3 update

## Description
N/A

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
