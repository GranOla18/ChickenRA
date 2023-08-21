# ChickenRA
AR Project for postgraduate course. This project has two main purposes: image tracking and plane detection with AR Foundation.

## Main Menu
Here the user can select wether it wants to test the **AR marker based** game or the **plane detection** game.

## Image Tracking
This was used to have an AR marker based functionality. The [Marker](https://github.com/GranOla18/ChickenRA/tree/main/Assets/Art/Images) can be found in Assets/Art/Images/Poio.jpg. When the marker is found it instances a "map" (assembled with [low-poly nature pack](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153)) where the player's (a [chicken](https://assetstore.unity.com/packages/3d/characters/animals/meshtint-free-chicken-mega-toon-series-151842)) movement can be controlled with a [joystick](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631). The chicken needs to get to the [nest](https://assetstore.unity.com/packages/3d/props/low-poly-bird-nests-229812), but by doing so the enemy (a mushroom from the nature pack) will appear in the map and will try to catch the chicken. If the player gets hit by the enemy it will be **Game Over**. For winning, the chicken must shoot 3 rocks to the mushroom and defeat it.

## Plane Detection
The main difference with the Image Tracking functionality is that, instead of looking for the marker, the game/app will start detecting planes in the environment with the help of AR Foundation Plane Manager. When any plane is detected the user can touch over any of the planes and an instance of the map will be created with a raycast function and it will have the same functionality that the map in the Image Tracking. 
