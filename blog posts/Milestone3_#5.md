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

