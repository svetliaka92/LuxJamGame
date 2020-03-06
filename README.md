# LuxJamGame
<b>A game made for the game jam named LuxJam</b>

<h2>Theme: </h2>
<h3> Light and shadow </h3>

Engine to use: Unity, version 2019.3.4f1, with the universal render pipeline. 
Trello board: https://trello.com/b/IGeFcJW2/jams

The player will spawn at a place under a light post, and will have to follow a path of light posts to reach the end of the level. 

While in shadow the player will gain points in a shadow meter, and if 100 is reached, the player dies, having to return back to level 1.
There will be light shards spread throughout the environment (around the posts, on the path between them, etc.), and will decrease the shadow meter on use. Small shards do -25 shadow, medium -50, and large -100.

On player death the position will be remembered for the next run, and a light shard will be spawned at that position.

4 levels for now, maybe expand if time.

The player will have an inventory (3 slots for the light shards, responding to the alpha numbers 1-3).
