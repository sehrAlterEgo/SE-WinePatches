# SE-WinePatches
Patching some unimplemented wine calls.


## Build

change the Game Directory in `SpaceEngineersPath.props` and:

```sh
sudo apt install mono-complete
xbuild /p:Configuration=Release
```

## Usage

* copy geoplugin.dll and Harmony0.dll (from bin/release) to your game dir and run
```sh
steam -applaunch 244850 -plugin geoplugin.dll
```
