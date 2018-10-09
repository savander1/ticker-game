# ticker-game

[![Build status](https://ci.appveyor.com/api/projects/status/p8eftpux4q962kkh?svg=true)](https://ci.appveyor.com/project/savander1/ticker-game)

## Building 
This project uses [Cake](https://cakebuild.net) to build and test which makes building the project very easy.

### Windows
From a Command Prompt, enter
```
powershell ./Build.ps1 -Target Build
```
or from Powershell 
```
./Build.ps1 -Target Build
```

### OSX and Linux
From a Terminal shell, enter 
```
./Build.ps1
```

This would be a good chance to use pub/sub model. The game engine could be constantly raising and lowering values and announcing values to the logic classes.