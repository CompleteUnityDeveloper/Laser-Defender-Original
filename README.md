### Introduction to Laser Defender ###

+ Laser Defender introduction
+ What Laser Defender teaches 
    + Animation basics
    + Using Trigger colliders
    + Introduction to Particle Systems

### Section 6 Game Design Document ###



### Your Laser Defender Assets ###



### Section 6 Notes ###



### Importing The Menu System ###

+ Open our previous game and import the menu system
+ Create a unity package
+ Import package into Laser Defender
+ Alternatively, we can use the unitypackage from the section bundle at the beginning of this section

### A Starship We Can Control ###

+ Find a suitable sprite asset
+ Import into our game
+ Create a Player Controller Script to move it
+ Restrict the movement to the playspace

**Useful Links**  
+ [OpenGameArt.org](OpenGameArt.org)
+ [Kenney · Game development studio, Netherlands · Home](http://kenney.nl/)
+ [Space Shooter Redux](http://kenney.nl/assets/space-shooter-redux)

### Restricting The Player's Position ###

+ How to stop the spaceship from going outside the playspace
+ We will check the position when moving and restrict it to something sensible

### Creating The Enemies ###

+ Creating the enemy prefab
+ Create an EnemySpawner that will generate enemies at runtime
+ Make the EnemySpawner generate a single enemy on start

### Creating Enemy Positions ###

+ Create a position within the EnemyFormation
+ Use **OnDrawGizmos()** to show the position
+ Turn the position into a prefab
+ Change the spawning script to keep track of positions

### Moving The Enemy Formation ###

+ Showing the Formation in the Editor
+ Show all four sides of the formation
+ Move the formation side to side

### Fixing The Formation Movement ###

+ Fix the boundary issue with the formation getting stuck on the edge of the playspace

### Spawning Projectiles ###

+ Player object should spawns laser when [space] is pressed
+ Create a laser prefab
+ We use **Instantiate()** to create a new one
+ We give the projectile velocity

### Shooting Enemies ###

+ Enemies will respond to the projectile hitting them.
+ We use _Kinematic Rigidbody Triggers_ for the enemies
+ On trigger, enemy takes damage according to projectile component
+ Defining the projectile behaviour
+ Detect laser collisions
+ Getting the damage from the lasers

### Enemies Shooting Back ###

+ Enemies will randomly shoot back with a tuneable frequency
+ Make enemies shoot at the player
+ Create enemy projectile
+ Getting hit by the enemy
+ Tuning the frequency

### Controlling Collisions with Layers ###

+ Player shoots itself when firing!
+ Lasers hit each other!
+ We need the player's projectile not to collide with itself or the player
+ We need the enemy projectiles to not collide with enemies or each other

### Detecting Enemies Have Been Destroyed ###

+ We need to know when all enemies are dead
+ We use the childCount property of a transform on the positions - an empty position is a dead enemy
+ We re-spawn the enemies when that happens

### Spawning Enemies One By One ###

+ Learn how to use recursive functions for the first time
+ Make something happen multiple times with a delay between each time

### Enemy Position Animation ###

+ Enemies should animate in, rather than appear
+ Create an Animator and Animation Controller
+ Create states to represent arriving and flying
+ Add the appropriate animation

### Creating A Starfield ###

+ The background looks a little barren
+ Let's add a starfield with parallax effect to give some sense of depth
+ We can use a Particle System to do this.
+ Explore Particle Effects

### Keeping Score ###

+ Requires Some object to keep track of the scores
+ Create the UI for the score
+ We'll create a ScoreKeeper that we attach to the score
+ When an Enemy dies, we'll call the ScoreKeeper

### Sound Effects For Fun And Profit ###

+ Adding sound to your game
+ Will make a huge difference to our game
+ Easy enough to do
+ We'll look at playing sounds independently of an object, so that we can play a death sound for the enemies

### Sprite Rendering Order ###

+ Sprite rendering order changes which sprites are drawn on top
+ Lets missiles from the player be drawn below the ship when instantiated
+ Create appropriate sorting layers
+ Laser defender now with layers

### Polishing The Menu System I ###

+ Replacing the menu style
+ Passing the score to the ends

### Polishing The Menu System II ###

+ Adding our own music to the game
+ Adding a background starfield

**Useful Links**  
+ [OpenGameArt.org](OpenGameArt.org)
+ [Clearside - Home](http://www.clearsidemusic.com/)
+ [Clearside music](http://opengameart.org/users/clearside)

### LD Unity 5 & Web GL Sharing (Optional) ###

+ Upgrade to Unity 5.
+ About Web GL builds.
+ Build for Web GL and share.

### DOWNLOAD Section 6 Unity Project ###

Here is our Unity project at this point in the section. Use it to compare code
/ settings etc if you get stuck. 

Once un-zipped you can use **File > Open Project** in Unity, or browse the folders for any .unity file.

You can get to ALL videos end-state by...

1. Visiting https://github.com/CompleteUnityDeveloper
2. Clicking on the section name.
3. Clicking XX Commits at the top-left (XX will vary)
4. Against the video you want, click the <> button on right.
5. On final page, click Download Zip button.

Good luck!

### Section 6 Wrap Up ###

+ Recap and what's next
+ New in your toolkit
+ Trigger Colliders
+ Sprite Animations
+ Particle Systems
+ Physics Layers
+ Sorting Layers
