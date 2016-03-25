using UnityEngine;

using System.IO;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
public static class EmojiAtlasBaker  {

    [MenuItem("Emoji/Bake Atlas")]
    private static void BakeEmojiAtlas()
    {
        string pathToEmojis = Application.dataPath + "/Textures/Emojis";
        string pathToEmojiInfo = Application.dataPath + "/EmojiInfo/info.txt";
        string pathToBakedAtlas = Application.dataPath + "/Textures/Baked/BakedEmojis.png";

        string[] emojiFileNames = Directory.GetFiles(pathToEmojis, "*.png");       

        // Load each PNG file as separate Texture2D
        Texture2D[] emojiTextures = new Texture2D[emojiFileNames.Length];

        for (int i = 0; i < emojiFileNames.Length; i++)
        {
            // Create a texture. Texture size does not matter, since
            // LoadImage will replace with with incoming image size.
            Texture2D tex = new Texture2D(2, 2);
            if (!tex.LoadImage(File.ReadAllBytes(emojiFileNames[i])))
            {
                Debug.LogError("Cannot load file " + emojiFileNames[i] + " via tex.LoadImage!!!");
                return;
            }
            emojiTextures[i] = tex;       
        }

        // Create atlas
        Texture2D atlas = new Texture2D(2048, 2048);
        Rect[] rects = atlas.PackTextures(emojiTextures, 1, 2048);

        // Save atlas
        byte[] atlasBytes = atlas.EncodeToPNG();
        File.WriteAllBytes(pathToBakedAtlas, atlasBytes);

        // Save EmojiInfo
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < emojiFileNames.Length; i++)
        {
            sb.AppendLine(Path.GetFileNameWithoutExtension(emojiFileNames[i]) + " " + rects[i].x + " " + rects[i].y + " " + rects[i].width + " " + rects[i].height );
        }
        File.WriteAllText(pathToEmojiInfo, sb.ToString());

        Debug.Log("Baked " + emojiFileNames.Length + " emojis into " + pathToBakedAtlas);
    }
}
#endif
