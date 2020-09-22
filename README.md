# Tank Wars
This Repository contains the Unity3D project done with C#
## _Dependencies used_
- [Unity3D](https://unity3d.com/get-unity/download)
- [Asset Store](https://assetstore.unity.com/)

### Starting Up
Download Unity Hub, and install Unity Editor (2019.3 or above). Make sure that you select Microsoft Visual Studio and Android Build Support in Add-ons.

### Install Instructions
1. Download the TowerDefence.apk file on your android device and install it
OR
1. Download the project folder
2. Open it in Unity Editor (2019.4.0f1 or above)
3. Connect your android device via USB cable (ensure debugging mode is on)
4. In unity File->Build Settings -> Add all scenes
5. Select your device in Run Device
6. Click Build and Run

### Description
This is a 2D tower defence game. The objective is to defend as long as possible by building defences and killing incoming enemies. As time passes, the number, health and speed of enemies increases, thus making sure that the game remains challenging through out. Every 7th wave is a boss wave, in which giant monsters come, which keep destroying the denfences. The player as total 20 lives, and loses a life every time an enemy reaches the end of the path. The player earns cash over time and by killing enemies, which can be used to setup more defences. There are 7 types of enemies and 7 types of defences, each with a different feature.

### Implementation
##### Controls
The left side of the screen has a shop, and the ground is laid out as a grid. The player picks an item, and touches one of the grid. If the player has sufficient cash, the defence is built at that position.
##### Shooting
Each defence has a fixed range. A C# script is laid on every defence, which executes the following algorithm at fixed intervals of time: if the defence has no target at the instant, it searches for all enemies, calculates distance from them and finds the closest enemy. If this distance is within the range, it sets the target of defence as that enemy. Else if the defence does have a target, it calculates the distance from the target, and if it goes out of range, the target is set to null.

##### Enemy Movement
The path is a sequence of adjacent cells in the grid. At each turn, there is an empty GameObject called waypoint. The destination of enemy is set to be the first waypoint, and when the enemy reaches it, the destination is changed to be the next waypoint. To move the enemy, its given a fixed velocity towards the destination.
##### Animation and Aesthetics
All the animations are sprite sheet based. Each enemy had its own sprite sheet, one for each direction of movement; and the animator plays the correct animation according to the velocity direction of the enemy. The defences are set to rotate according to the enemy position, so that it always points towards its target, and explosion effects are played everytime a bullet hits the enemy. A small gravestone sprite is instantiated where the enemy dies.

##### UI
The UI is simple and minimal, with two buttons in the main menu, and a shop overlay canvas in the gameplay



