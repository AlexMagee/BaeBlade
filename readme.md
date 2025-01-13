# Branch Configuration
## Main Branch:
- This is the stable version of the game.
- Only tested, functional, and integrated features should be merged here.
- Everyone should pull from this branch regularly to stay up-to-date.
- *Main branch should only be used to create stable releases after a successful test.*
## Feature Branches:
- **Environment Branch (environment)**: For the environment artist to work on scenes, level design, lighting, and other environment-related tasks.
- **Mechanics Branch (mechanics)**: For the programmer to develop game mechanics and scripts.
- **Props Branch (props)**: For the prop artist to work on 3D models, textures, and animations.
## Testing Branch:
- The **testing branch** is to periodically merge environment, mechanics, and props branches. This branch allows the team to test the game with the latest changes without affecting the stable main branch.
- Alex will manage the testing branch and will merge relevant commits to create a snapshot version for testing.
