# Change Log
## 30/10/21
 - Adding raycasts to prevent ducks shooting through other ducks
 - Iterating different duck variations
 - Shader experimentation


## 15/10/21
Thanks to some debugging and lots of testing over the course of the past couple of days, I was able to figure out what the issue was: a very persistent WHILE loop that would crash the Unity project and prevent me from opening it again due to the iterations it had been carrying out.

Fortunately I was able to hop back into it after rebooting my laptop a couple of times and replacing the WHILE loop with an IF statement that functioned similarly to how the previous loop functioned; despite this, there were still a couple of issues that I was able to identify by checking to see whether or not the console was printing certain commands. For starters, when I wrote a debug line to output the health bar value upon the player's death, I discovered that it would not actually dip into 0 or below even if the player's health did, which was quite vital because it was the method I had chosen for the ducks to be able to see what health the player was on. This wasn't that hard to fix, as I could simply manually change the value of the health bar if the attack would have taken the player to sub-zero digits.

This led onto another issue - the ducks were not registering when the player health dipped to 0 or below, resulting in a neverending stream of ducks bombarding the player. I chose to circumnavigate this by adding in a delay when the player dies, which enabled the DuckMovement script to read the change and output the appropriate message. I'm pretty sure that this may have been due to the speed at which Unity reads certain functions, with the OnTriggerEnter function being read separately to the regular Update each script has and therefore refilling the player's health before the ducks could identify that there had been a change.

So, huzzah! All-in-all I would say that I am fairly content with the main changes this week. A number of other tweaks have been made to the scripts, namely in terms of tidying them up (par example, moving the actual player movement into its own function rather than keeping it in Update) and I am also making a point of going through and adding comments to scripts so that I don't confuse myself or others who end up looking at them.

With this sorted, my attention is moving more into the realms of how to spice up the core gameplay. While there can be some fun in just running around and shooting at rubber ducks, it will get boring fairly quickly, so I have starting brainstorming several power-ups that can benefit the player while offering new ways of committing rubber duck slaughter. On the other side of things, there are also a couple of duck variants that I have been working on, and if all goes well then they should be ready to show off sometime within the next month or so!

###### TL;DR:
 - Basic player respawn system implemented
 - Added delay to ducks when player respawns
 - Tidied up various scripts
 - Beginning to look at power-ups and new enemies


## 12/10/21
I've dubbed the past couple of weeks the infestation, because OH GOODNESS THERE ARE BUGS EVERYWHERE!

Going into my next stage of development, I thought that a respawn system would be fairly simple to mock up. In theory it really shouldn't: add a function to the script that gets called when the player's health hits anywhere from 0 downwards and reset their position and rotation to that of a spawn point. This proved incredibly easy to do by adding a new GameObject to the scene, adding it to the PlayerMovement script under the guise of a Transform variable, then simply adding in the appropriately-named PlayerRespawn() function and calling it from Update() the moment that the player hits zero health. Perfect.

The trouble came with other considerations, namely making it so that the player would be immune to any duck attacks for a short period after respawning or deactivating the ducks until the player has survived for a couple of seconds after being reborn. For some unknown reason, trying either one of them has forced my project to crash numerous times, the most recent one preventing me from opening the file at all.

Well this sucks, eh?

It also leaves me with a few options. If I can sort out the issue and reopen the project, I will be able to continue working on my project. Otherwise I may have to either start from scratch or abandon the project. Hopefully it won't come to that but in the event that nothing works then it's the only thing I can really do.

So in conclusion, these bugs have been a bit of a bummer, but if I can figure out what's causing them then I should be able to get back on track to make some more progress on it!


## 30/09/21
Well, that didn't take as long as I thought it would. After a couple of days messing around with the code, fixing errors, and adding other little changes, the player is no longer safe - the ducks can attack!

Today's commit has added a couple of new scripts that streamlined the process of attacking for both player and duck alike. Rather than devoting an entire script to all the movements and functions that the ducks can carry out, I created a new script to manage attacks and attached it to the duck prefab that I have created for my project. Each duck now calculates how far it is from the player and how long it has been since it last attacked. If both conditions are met (the duck is close to the player and has not attacked for a couple of seconds) then the DuckMovement script calls an attack function from the attached ShootPlayer script. All this does is spawn in a bullet prefab which will hurtle in the direction that the duck was looking in for a few seconds before either hitting the player and destroying itself or living out its short lifespan before being deleted from the scene.

![Screenshot (73)](https://user-images.githubusercontent.com/44437464/135453677-80454022-469f-4274-bb14-2f53b415f47a.png)
*Code for instantiating the bullet prefab*

![Screenshot (74)](https://user-images.githubusercontent.com/44437464/135453757-08049612-19e3-4c8a-bec5-c68d2d35d30e.png)
*Bullet behaviour script*

However, I soon ran into a problem. Despite all of the code looking exactly as it should and the tags set correctly, the player wasn't taking any damage. Even when I mocked up a health bar and added some UI interaction into the script, the health didn't drop at all. Would if be safe to check that I can be damaged at all? To be sure I added a function for testing wherein the player could press the Control key to damage themselves, and sure enough, it worked just fine. So what was the issue?

Well, it turns out that I made an error on my OnTriggerEnter function, having it set as 2D rather than 3D. Guess it just goes to show that even when you're feeling certain that it should all work smoothly, you can still gloss over the smaller bits of code! With that sorted, everything worked just as intended, with the player being damaged by the bullets and regenerating health after not being hit for a few seconds.

I have also made a key change to the way that the player shoots the ducks. While I did find that being able to see the projectile was quite fun at first, the delight wore off rather quickly. Fortunately this is where I realised I could use a raycast to fire the gun instead. So I removed the old scripts that dealt with having the player fire a bullet and added a new one which retained some properties of the old script - namely, there is still a slight delay between bullets fired. So what I should say is that they retained one property, but hey ho, it feels smoother and it even gave me an excuse to run around the tiny box of a test level in a mad panic before the ducks could kill me.

One last thing I want to talk about is a more detailed log of my progress. From here on in I am going to try and restrict this page to scripting progress only, with a more detailed log either on YouTube or my portfolio. A link will appear here when it finally does go up, but for now I'm afraid you shall just have to wait.

###### TL;DR:
 - Added health system for player
 - Implemented scripts for duck ranged attacks
 - Mocked up initial UI element for player health
 - Fixed bugs in scripts
 - Detailed log is currently in progress
 - Player attack system changed to raycasts


## 28/09/21
Visuals for yesterday's main changes:

![Screenshot (69)](https://user-images.githubusercontent.com/44437464/135065419-dd358c9f-57d1-43e8-877d-93fda434aab7.png)
*Water shader graph (using Brackeys tutorial)*

![Screenshot (71)](https://user-images.githubusercontent.com/44437464/135065433-1889ec96-8eb4-4b26-81e6-fabc9a533c68.png)
*Outline shader graph*

![Screenshot (70)](https://user-images.githubusercontent.com/44437464/135065442-07b9f3df-2608-4f84-9c3f-5ab4b5a765b7.png)

*Outline shader graph applied to duck model*

The error behind the outline shader was also found yesterday evening: the value assigned to the OutlineThickness was too great when used in conjunction with more complex objects that had more vertices. This issue was solved by decreasing it to the lowest positive value, giving off a slight black edge with no extreme visible errors.


## 27/09/21
The duck now has a body!

![Screenshot (68)](https://user-images.githubusercontent.com/44437464/134911654-02299880-c8d7-4e4c-9534-2a370d5287dc.png)

In the initial projection for this month I set myself the goal of simply nailing down the basic movement and thinking through the ideas for the core mechanics. However, I soon grew tiresome of staring at cubes following me around for ages on end, and as such I was able to throw this together.

In doing so I also thought about the art direction for the game. The theme of the game lends itself to a naturally whimsical art style, so after much deliberation I decided to ~~go down the same route as most indie devs and~~ try some low-poly modelling out. I opened Blender and tried my hand at it, eventually coming up with this. All I needed to do was import the .fbx file into Unity, create a prefab with the model, then set up a couple of colliders and boom! All sorted!

With this in mind I also examined some other artistic techniques and ideated upon some shaders for use. Since the game takes place in a bathtub I knew I would have to do some water textures, so I scoured the internet for ideas and stumbled across a very helpful tutorial from Brackeys on how to make a water shader. You can see it [here](https://www.youtube.com/watch?v=Vg0L9aCRWPE&t=33s)! Not only that, I experimented with a shader graph to highlight the edges of certain objects. While it seemed to have a bit of issue on more complex models, it seems to work with simple objects and should be expanded upon.

So what is happening beyond the aesthetic? I am currently working on the script for reducing the player health, it shouldn't take long but it also means configuring when ducks attack (which coincidentally could be the name of a novel: When Ducks Attack). I hope to have the base code for it sorted within the next week, but I anticipate I will also have to make an attack manager to ensure that the player will not be constantly bombarded with a range of fowl-based projectiles.

###### TL;DR:
 - Added model for ducks
 - Experimented with shaders for water and edge detection
 - Currently iterating on other artistic choices
 - Working on duck offensive systems

Stay tuned and hopefully I'll have the duck attack system done soon!


## 22/09/21 (Introduction)
Hello there! My name is Alex and this is a personal project I have been working on for about a month now!

Obligatory backstory: one of my university professors was (and probably still is) obsessed with rubber ducks. He first introduced them to us as a method of helping us understand our programming in a better fashion by having an entity we could explain it to. The bare basis is that breaking the code down to its simplest form should be so simple that even a rubber duck would be able to understand it. So whenever anybody in our class won a quiz or did exceedingly well with some work, we earned a duck.

Unfortunately COVID-19 hit the world halfway through my second year of university and he couldn't give out any rubber ducks anymore. But the joke still lived on, and every time we got a chance we would reference the rubber ducks. It never ended through the rest of our time online, and since I ended uni I only thought it fitting to develop a project that utilised rubber ducks in some fashion. Which is what we have here: this amalgamation of rubber ducks and insanity!

The current state of the game is fairly barebones at the moment. The milestone that I set for the end of this month was to nail down the basic movement for the player and ducks scattered throughout the levels. So far there is a single level which will be used to test that all desired physics and mechanics of the game function as intended - more in-depth and structured levels will be developed following this period. With this in mind, the following criteria have been fulfilled:

 - Basic player movement
 - Basic duck movement
 - Spawning in new ducks
 - Weapon system
 - Duck health

Having achieved these goals, the game development process is entering a second stage of development that will shift to focus on the enemy's side of things. I have set the following goals for myself to achieve within the upcoming month of October:

 - Player health
 - Duck attacks (may find a mix of melee and ranged)
 - Duck varieties/different duck enemies
 - Status effects
 - Player death/respawning/restarting

Finally, the roadmap for future development. While I have not got absolutely everything set out in detail, the current plan for the game state beyond this point will look a little something like this:

 - Pick-ups/items
 - Other weapons
 - Level design
 - Difficulty scaling
 - Boss battles
 - Endgame events/bosses
 - Music(?)

I will be uploading a demo to Itch.io once the game has entered a suitable state for testing. Until then, please do feel free to browse through the scripts that I have inserted into the repository, and do let me know if you have any feedback or suggestions!
