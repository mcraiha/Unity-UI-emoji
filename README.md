**Update:**
[TextMesh Pro](https://www.assetstore.unity3d.com/en/#!/content/84126) is now free, and it will be [integrated to Unity](https://twitter.com/unity3d/status/836625140054179842). So if you want to use Emojis in your Unity project, I would suggest that you use it instead of Unity-UI-emoji.

# Unity-UI-emoji
Show emoji images in Unity UI text

![Emojis](https://github.com/mcraiha/Unity-UI-emoji/blob/master/unity_emoji.png)

[WebGL demo](http://mcraiha.github.io/demos/emoji/)
##Introduction
Since Unity doesn't have build-in emoji support in it, I wanted to test out different approaches for showing emoji in Unity projects.

This one shows emoji via UI Text.

##How to use
Download and import the Unitypackage [unity_emoji_v200.unitypackage](https://github.com/mcraiha/Unity-UI-emoji/blob/master/unity_emoji_v200.unitypackage) to your project. Open showoff scene and press play to see the emojis in action.

Basically you have to have a RawImage with emoji atlas set in the scene (in this case **rawImageToClone** in [ShowOffEmoji.cs](https://github.com/mcraiha/Unity-UI-emoji/blob/master/Assets/Scripts/ShowOffEmoji.cs)) to be used for emoji replacement. After that you can call
```cs
StartCoroutine(this.SetUITextThatHasEmoji(uiText, "⚽ ➕ ❤ = I love football"));
```
to set your uiText.

##How does it work under the hood
1. step, rebuild the input string and replace any emoji (or special char) with (em quad)[https://en.wikipedia.org/wiki/Quad_(typography)] char, e.g. string "my ™ is best" -> "my   is best"
2. step, set UI Text to rebuild text (so emojis are drawn as blank)
3. step, generate new RawImage for each replaced emoji, position those correctly and set correct atlas UVs

##Tips
- If you don't need/want e.g Copyright symbol (a9.png) to be drawn as emoji then you can just remove the file (a9.png) and rebuild the atlas
- You can add/replace PNGs if you need new emojis or custom symbols (rebuild atlas after that)

##Limitations
- You have to get emoji graphics from somewhere. In this case I used those provided by Twitter via their [Twemoji](https://github.com/twitter/twemoji) project. Graphics licensed under CC-BY 4.0 [https://creativecommons.org/licenses/by/4.0/](https://creativecommons.org/licenses/by/4.0/)
- You have to create atlas from those emoji textures ([EmojiAtlasBaker.cs](https://github.com/mcraiha/Unity-UI-emoji/blob/master/Assets/Scripts/EmojiAtlasBaker.cs) does that)
- Every emoji shown requires new RawImage element
- You have to manually adjust RawImage settings (pivot etc.) to make them match your font
- Only supports one pixel size (albeit transform scaling can be used, but in that case pixel accuracy is lost)
- ~~Not all emojis are supported texture wise since current release of Twitter's [Twemoji](https://github.com/twitter/twemoji) project is "only" Unicode 7.0 complete.~~ Twemoji is Unicode 8.0 complete
- Font needs to have (em quad)[https://en.wikipedia.org/wiki/Quad_(typography)] char (or something similar, that draws 1:1 blank)

##Ugly stuff
All emojis that fit into single C# char (e.g. chars like ⚽ ➕ ❤) can be written directly to code but longer ones have to entered as [escape sequences](https://msdn.microsoft.com/en-us/library/aa664669(v=vs.71).aspx).
Certain emojis require 4 chars (like US Flag, **U+1F1FA U+1F1F8**) since it build from 2 emojis (letters U **U+1F1FA** and S **U+1F1F8**).

##Licences
This document, code files and scene file are licenced under Public domain. See [PUBLICDOMAIN](https://github.com/mcraiha/Dithering-Unity3d/blob/master/PUBLICDOMAIN) file.

Emoji textures (in [Assets/Textures/Emojis](https://github.com/mcraiha/Unity-UI-emoji/tree/master/Assets/Textures/Emojis) folder) and [Emoji atlas](https://github.com/mcraiha/Unity-UI-emoji/blob/master/Assets/Textures/Baked/BakedEmojis.png) are licensed under CC-BY 4.0 [https://creativecommons.org/licenses/by/4.0/](https://creativecommons.org/licenses/by/4.0/). All emoji textures are from Twitter's [Twemoji](https://github.com/twitter/twemoji) project.

Roboto font (in [Assets/Fonts/Roboto-Regular.ttf]) is licensed under Apache License, version 2.0 [http://www.apache.org/licenses/LICENSE-2.0.html]. It is from [Google Fonts](https://www.google.com/fonts/specimen/Roboto).
