# Multiplayer Egg Collector (Unity Test)

## About

This is a small Unity project I built as part of a game programmer technical test.

The idea is simple: a player and a few bots run around a map trying to collect eggs. Whoever collects more before time runs out wins.

I focused more on making the core systems work reliably (movement, AI, game loop) rather than polishing visuals.

---

## What’s in the project

### Player

* Controlled with keyboard (WASD / Arrow keys)
* Uses Rigidbody for movement so it doesn't go through walls

### Bots

* Use a simple A* pathfinding setup
* Whenever a new egg spawns, they pick a target and move toward it
* Avoid obstacles using the grid

### Eggs

* Spawn at random positions
* I added a check so they don't spawn inside obstacles
* Destroy immediately when collected for responsiveness

### Score & Game Flow

* Player and bots gain score when collecting eggs
* Score is shown on screen
* After a fixed time, the game ends and a winner is displayed

---

## Networking (simulated)

There’s no real multiplayer backend, but I simulated a client-server flow:

* Player sends position updates
* Server adds a random delay (100–500ms)
* Client receives delayed data

I originally tried a more advanced interpolation approach, but it introduced instability under time pressure, so I switched to a simpler smoothing method to keep movement consistent.

---

## Some decisions I made

* **Separate local and remote player logic**
  Makes it easier to reason about input vs network updates.

* **Keep networking simple**
  The goal here was to show understanding, not to build a full networking stack.

* **Destroy eggs locally**
  Avoided syncing edge cases and kept the game responsive.

* **Map layout**
  I placed a few obstacles to make pathfinding meaningful, but made sure all areas are reachable.

---

## How to run

* Open in Unity 2021.3 LTS (or compatible)
* Open the main scene
* Press Play

Controls:

* Move: WASD / Arrow Keys

---

## Limitations

* No real multiplayer (just simulation)
* No prediction / rollback
* Bot behavior is quite basic
* UI is minimal

---

## If I had more time

* Proper interpolation (snapshot-based)
* Better bot decision making (not just nearest egg)
* Cleaner UI and feedback
* Possibly switch to a real networking solution

---

## Author

Tuan Anh
