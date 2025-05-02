# 🚀 StarCruiser – A Console Space Shooter in C#

**StarCruiser** is a retro-style space shooter built entirely in C# using the console as graphical interface. It features keyboard-controlled ship movement, projectile mechanics, enemies, stars, explosions, and real-time rendering using `Console.SetCursorPosition`.


<img src="https://github.com/DRgreenT/StarCruiser/blob/master/docs/pic1.png">

---

## 🎮 Features

- 🛸 Move your spaceship using arrow keys
- 💥 Shoot enemies with the spacebar
- 🌟 Collect (or dodge) stars for points
- 💣 Explosions and score system
- 🧱 Dynamic console frame and window resizing
- 🔄 Fully self-updating game loop

---

## 🧩 Code Structure

| File                  | Purpose                                                                 |
|-----------------------|-------------------------------------------------------------------------|
| `Program.cs`          | Main game loop, initialization, spawning, rendering and game logic      |
| `Settings.cs`         | Game configuration, window size, speed, debug mode                      |
| `Player.cs`           | Player state (position, score, lives, level)                            |
| `Position.cs`         | Handles movement and collisions of all game objects                     |
| `UserInputHandling.cs`| Captures and processes player input (movement and shooting)             |
| `GameObjects.cs`      | Base class for all interactive elements (stars, enemies, bullets, etc.) |
| `Generator.cs`        | Spawns enemies and stars with random placement and logic                |
| `Grafix.cs`           | Handles ASCII-style drawing, explosions, player graphics and debug info |
| `Colors.cs`           | Provides ANSI color codes for colorful console output                   |

---

## ⚙️ How to Run

1. Clone the repo 
2. Build with Visual Studio targeting **.NET Framework 4.7.2**
3. Run in a real Windows Console (not VS debug console!)

Or [download](https://github.com/DRgreenT/StarCruiser/blob/master/build/StarCruiser.exe) 

Use arrow keys to move and spacebar to shoot

---

## 🖥️ Requirements

- Windows Console environment
- .NET Framework 4.7.2
- Recommended resolution: 120x30 characters

---

## 🗒️ Notes

- Collision detection is basic but functional
- All drawing happens via `Console.SetCursorPosition()`
- Uses simple ASCII/ANSI for visuals and colors
- Game difficulty increases over time

---

## 📌 License

This is a hobby project for learning purposes. Free to use, modify, or expand. No warranty included. Enjoy shooting pixels!

