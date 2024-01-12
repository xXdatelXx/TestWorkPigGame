# Scenes

## Set
- [Bootstrap](/TestWork.Unity/Assets/_Project/Scenes/Bootstrap/) - game entry point and context(configs, reporting)
- [Meta](/TestWork.Unity/Assets/_Project/Scenes/Meta) - main menu
- [Game](/TestWork.Unity/Assets/_Project/Scenes/Game) - core gameplay
- [Empty](/TestWork.Unity/Assets/_Project/Scenes/Empty) - crutch scene for 100% unloading of all resources of the previous scene.

## Code 
### Initilization
- *Scene name* + Scope - for scene [RRR phase](https://blog.ploeh.dk/2010/09/29/TheRegisterResolveReleasepattern/), with using [VContainer](/TestWork.Documentation/Core/Plugins.md)
- *Scene name* - for scene initilization phase
- [Example](/TestWork.Unity/Assets/_Project/Develop/TestWork/Runtime/Core/Bootstrap)
### Classes
- [IScene](/TestWork.Unity/Assets/_Project/Develop/TestWork/Engine/Unity/Scenes/IScene.cs) - decorator for Unity scene asset
    - [UnityScene](/TestWork.Unity/Assets/_Project/Develop/TestWork/Engine/Unity/Scenes/UnityScene.cs) - Scene SO
    - [UnitySceneWithMemoryAllocate](/TestWork.Unity/Assets/_Project/Develop/TestWork/Engine/Unity/Scenes/UnitySceneWithMemoryAllocate.cs) - for 100% unloading of all resources of the previous scene. 


