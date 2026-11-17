
using UnityEngine;
using UnityEditor;
using System;

public static class InvertirAnimacionSpriteEditor
{
    [MenuItem("Tools/Animaciones/Invertir clip de sprites")]
    private static void InvertirClip()
    {
        AnimationClip clip =
            Selection.activeObject as AnimationClip;

        if (clip == null)
        {
            Debug.LogError("Selecciona un clip .anim en Project.");
            return;
        }

        var bindings =
            AnimationUtility.GetObjectReferenceCurveBindings(clip);

        int curvasInvertidas = 0;

        foreach (var binding in bindings)
        {
            var keys =
                AnimationUtility.GetObjectReferenceCurve(
                    clip, binding
                );

            if (keys == null || keys.Length < 2)
                continue;

            float tiempoFinal = keys[keys.Length - 1].time;

            Array.Reverse(keys);

            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].time =
                    tiempoFinal - keys[i].time;
            }

            AnimationUtility.SetObjectReferenceCurve(
                clip,
                binding,
                keys
            );

            curvasInvertidas++;
        }

        if (curvasInvertidas == 0)
        {
            Debug.LogError("No se encontraron fotogramas de sprites.");
            return;
        }

        EditorUtility.SetDirty(clip);
        AssetDatabase.SaveAssets();

        Debug.Log("Animación invertida correctamente: " + clip.name);
    }
}
