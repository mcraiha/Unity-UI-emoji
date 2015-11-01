# Unity-UI-emoji
Show emoji images in Unity UI text

![Emojis](https://github.com/mcraiha/Unity-UI-emoji/blob/master/unity_emoji.png)

##Introduction
Since Unity doesn't have build-in emoji support in it, I wanted to test out different approaches for showing emoji in Unity projects.

This one shows emoji via UI Text.

##How to use
Download and import the Unitypackage (unity_emoji_v100.unitypackage) to your project. Open showoff scene and press play to see the emojis in action.

Basically you have to a RawImage with emoji atlas set in the scene (in this case **rawImageToClone** in [ShowOffEmoji.cs](https://github.com/mcraiha/Unity-UI-emoji/blob/master/Assets/Scripts/ShowOffEmoji.cs)) to be used for emoji replacement. After that you can call
```cs
StartCoroutine(this.SetUITextThatHasEmoji(uiText, "⚽ ➕ ❤ = I love football"));
```
to set your uiText.

##Limitations
- You have to get emoji graphics from somewhere. In this case I used those provided by Twitter via their [Twemoji](https://github.com/twitter/twemoji) project. Graphics licensed under CC-BY 4.0 [https://creativecommons.org/licenses/by/4.0/](https://creativecommons.org/licenses/by/4.0/)
- You have to create atlas from those emoji textures ([EmojiAtlasBaker.cs](https://github.com/mcraiha/Unity-UI-emoji/blob/master/Assets/Scripts/EmojiAtlasBaker.cs) does that)
- Every emoji shown requires new RawImage element
- You have to manually adjust RawImage settings (pivot etc.) to make them match your font
- Only supports one pixel size (albeit transform scaling can be used, but in that case pixel accuracy is lost)
- Not all emojis are supported texture wise since current release of Twitter's [Twemoji](https://github.com/twitter/twemoji) project is "only" Unicode 7.0 complete.

##Ugly stuff
All emojis that fit into single C# char (e.g. chars like ⚽ ➕ ❤) can be written directly to code but longer ones have to entered as [escape sequences](https://msdn.microsoft.com/en-us/library/aa664669(v=vs.71).aspx).
Certain emojis require 4 chars (like US Flag, **U+1F1FA U+1F1F8**) since it build from 2 emojis (letters U **U+1F1FA** and S **U+1F1F8**).

##Licences
This document, code files and scene file is licenced under Public domain. See [PUBLICDOMAIN](https://github.com/mcraiha/Dithering-Unity3d/blob/master/PUBLICDOMAIN) file.

Emoji textures (in [Assets/Textures/Emojis](https://github.com/mcraiha/Unity-UI-emoji/tree/master/Assets/Textures/Emojis) folder) and [Emoji atlas](https://github.com/mcraiha/Unity-UI-emoji/blob/master/Assets/Textures/Baked/BakedEmojis.png) are licensed under CC-BY 4.0 [https://creativecommons.org/licenses/by/4.0/](https://creativecommons.org/licenses/by/4.0/). All emoji textures are from Twitter's [Twemoji](https://github.com/twitter/twemoji) project.
