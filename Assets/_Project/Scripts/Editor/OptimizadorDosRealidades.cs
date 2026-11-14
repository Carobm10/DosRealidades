#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

// Guarda este archivo en Assets/Editor/OptimizadorDosRealidades.cs
// Herramienta de importacion: NO modifica los PNG originales.
public class OptimizadorDosRealidades : EditorWindow
{
    [Serializable]
    private class Respaldo
    {
        public string ruta;
        public bool overridden;
        public int maxTextureSize;
        public int format;
        public int compressionQuality;
        public bool crunchedCompression;
        public int textureCompression;
    }

    [Serializable]
    private class BaseRespaldos
    {
        public List<Respaldo> elementos = new List<Respaldo>();
    }

    private const string RutaRespaldo = "ProjectSettings/DosRealidades_AndroidTexturasBackup.json";
    private bool recorrerTodoAssets = true;
    private bool incluirTexto = false;
    private int calidad = 75;
    private int maxSize = 2048;
    private int cantidad;
    private int excluidas;
    private string estado = "Pulsa Analizar para ver cuantas texturas se cambiarian.";

    private static readonly string[] PalabrasSensibles =
    {
        "historieta", "historia", "nota", "dialogo", "dialogue", "texto", "text",
        "comic", "comicstrip", "instruccion", "tutorial", "letter", "carta",
        "tipografia", "font", "letra", "ui_text"
    };

    [MenuItem("Herramientas/Dos Realidades/Optimizar texturas Android")]
    private static void Abrir()
    {
        GetWindow<OptimizadorDosRealidades>("Optimizar Android").minSize = new Vector2(420, 300);
    }

    private void OnGUI()
    {
        GUILayout.Label("Dos Realidades - Texturas Android", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(
            "Optimiza en lote los ajustes de importacion de sprites para Android (ASTC 6x6). " +
            "No edita ni reduce los PNG originales. Crea respaldo de los ajustes anteriores.",
            MessageType.Info);

        recorrerTodoAssets = EditorGUILayout.ToggleLeft("Examinar todos los sprites de Assets", recorrerTodoAssets);
        if (!recorrerTodoAssets)
            EditorGUILayout.HelpBox("Selecciona una carpeta o texturas en Project antes de pulsar Analizar.", MessageType.None);

        incluirTexto = EditorGUILayout.ToggleLeft("Incluir historietas, notas y texturas con texto (NO recomendado)", incluirTexto);
        maxSize = EditorGUILayout.IntPopup("Tamano maximo Android", maxSize,
            new[] { "1024", "2048", "4096" }, new[] { 1024, 2048, 4096 });
        calidad = EditorGUILayout.IntSlider("Calidad importacion", calidad, 0, 100);

        EditorGUILayout.Space(10);
        if (GUILayout.Button("1. Analizar (sin cambiar nada)", GUILayout.Height(32)))
            Analizar();
        if (GUILayout.Button("2. Optimizar sprites Android", GUILayout.Height(32)))
            Optimizar();
        if (GUILayout.Button("Restaurar ajustes previos de Android", GUILayout.Height(27)))
            Restaurar();

        EditorGUILayout.Space(8);
        EditorGUILayout.LabelField("Sprites candidatos: " + cantidad + " | Excluidos por texto: " + excluidas);
        EditorGUILayout.HelpBox(estado, MessageType.None);
        EditorGUILayout.HelpBox(
            "La primera reimportacion puede consumir espacio y tiempo. Ejecuta SOLO cuando Unity no este compilando y tengas espacio libre suficiente. " +
            "ASTC requiere dispositivos Android compatibles; prueba en tus celulares.", MessageType.Warning);
    }

    private List<string> Candidatos()
    {
        var rutas = new List<string>();
        var vistos = new HashSet<string>();
        string[] carpetas;
        if (recorrerTodoAssets)
        {
            carpetas = new[] { "Assets" };
        }
        else
        {
            var elegidas = new List<string>();
            foreach (UnityEngine.Object obj in Selection.objects)
            {
                string ruta = AssetDatabase.GetAssetPath(obj);
                if (AssetDatabase.IsValidFolder(ruta)) elegidas.Add(ruta);
                else if (!string.IsNullOrEmpty(ruta) && vistos.Add(ruta)) rutas.Add(ruta);
            }
            carpetas = elegidas.ToArray();
        }

        foreach (string guid in AssetDatabase.FindAssets("t:Texture2D", carpetas))
        {
            string ruta = AssetDatabase.GUIDToAssetPath(guid);
            if (vistos.Add(ruta)) rutas.Add(ruta);
        }

        var filtradas = new List<string>();
        excluidas = 0;
        foreach (string ruta in rutas)
        {
            if (!(AssetImporter.GetAtPath(ruta) is TextureImporter imp)) continue;
            if (imp.textureType != TextureImporterType.Sprite) continue;
            if (!incluirTexto && EsSensible(ruta)) { excluidas++; continue; }
            filtradas.Add(ruta);
        }
        return filtradas;
    }

    private static bool EsSensible(string ruta)
    {
        string texto = ruta.ToLowerInvariant();
        foreach (string palabra in PalabrasSensibles)
            if (texto.Contains(palabra)) return true;
        return false;
    }

    private void Analizar()
    {
        cantidad = Candidatos().Count;
        estado = "Analisis finalizado: " + cantidad + " sprites candidatos; " + excluidas + " excluidos por texto.";
        Debug.Log("OPTIMIZADOR DR: " + estado);
    }

    private static BaseRespaldos LeerRespaldos()
    {
        if (!File.Exists(RutaRespaldo)) return new BaseRespaldos();
        try
        {
            BaseRespaldos datos = JsonUtility.FromJson<BaseRespaldos>(File.ReadAllText(RutaRespaldo));
            return datos ?? new BaseRespaldos();
        }
        catch (Exception e)
        {
            Debug.LogError("No se puede leer respaldo: " + e.Message);
            return null;
        }
    }

    private static void GuardarRespaldos(BaseRespaldos datos)
    {
        Directory.CreateDirectory("ProjectSettings");
        File.WriteAllText(RutaRespaldo, JsonUtility.ToJson(datos, true));
    }

    private void Optimizar()
    {
        List<string> rutas = Candidatos();
        cantidad = rutas.Count;
        if (rutas.Count == 0) { estado = "No se encontraron sprites para optimizar."; return; }
        if (!EditorUtility.DisplayDialog("Optimizar Android",
            "Se reimportaran hasta " + rutas.Count + " sprites. Las imagenes originales no se modifican. ¿Continuar?",
            "Optimizar", "Cancelar")) return;

        BaseRespaldos respaldo = LeerRespaldos();
        if (respaldo == null) { estado = "Respaldo invalido; no se realizaron cambios."; return; }
        var guardados = new HashSet<string>();
        foreach (Respaldo r in respaldo.elementos) guardados.Add(r.ruta);
        int cambios = 0;
        try
        {
            for (int i = 0; i < rutas.Count; i++)
            {
                string ruta = rutas[i];
                if (EditorUtility.DisplayCancelableProgressBar("Optimizando texturas", ruta, (float)i / rutas.Count)) break;
                var importer = AssetImporter.GetAtPath(ruta) as TextureImporter;
                if (importer == null) continue;
                TextureImporterPlatformSettings antes = importer.GetPlatformTextureSettings("Android");
                if (!guardados.Contains(ruta))
                {
                    respaldo.elementos.Add(new Respaldo
                    {
                        ruta = ruta,
                        overridden = antes.overridden,
                        maxTextureSize = antes.maxTextureSize,
                        format = (int)antes.format,
                        compressionQuality = antes.compressionQuality,
                        crunchedCompression = antes.crunchedCompression,
                        textureCompression = (int)antes.textureCompression
                    });
                    guardados.Add(ruta);
                    // Persistir antes de cada cambio: permite restaurar incluso si se interrumpe.
                    GuardarRespaldos(respaldo);
                }

                var android = importer.GetPlatformTextureSettings("Android");
                android.name = "Android";
                android.overridden = true;
                android.maxTextureSize = maxSize;
                android.format = TextureImporterFormat.ASTC_6x6;
                android.textureCompression = TextureImporterCompression.CompressedHQ;
                android.compressionQuality = calidad;
                android.crunchedCompression = false;
                importer.SetPlatformTextureSettings(android);
                importer.SaveAndReimport();
                cambios++;
            }
            estado = "Terminada la optimizacion de " + cambios + " sprites. Respaldo en " + RutaRespaldo;
            Debug.Log("OPTIMIZADOR DR: " + estado);
        }
        catch (Exception e)
        {
            estado = "Interrumpido: " + e.Message + ". Puedes usar Restaurar ajustes previos.";
            Debug.LogError("OPTIMIZADOR DR: " + estado);
        }
        finally { EditorUtility.ClearProgressBar(); }
    }

    private void Restaurar()
    {
        BaseRespaldos respaldo = LeerRespaldos();
        if (respaldo == null || respaldo.elementos.Count == 0)
        {
            estado = "No se encontro un respaldo para restaurar.";
            return;
        }
        if (!EditorUtility.DisplayDialog("Restaurar Android",
            "Se restauraran los ajustes anteriores para " + respaldo.elementos.Count + " texturas. ¿Continuar?",
            "Restaurar", "Cancelar")) return;
        int restaurados = 0;
        try
        {
            for (int i = 0; i < respaldo.elementos.Count; i++)
            {
                Respaldo r = respaldo.elementos[i];
                if (EditorUtility.DisplayCancelableProgressBar("Restaurando", r.ruta, (float)i / respaldo.elementos.Count)) break;
                TextureImporter imp = AssetImporter.GetAtPath(r.ruta) as TextureImporter;
                if (imp == null) continue;
                TextureImporterPlatformSettings android = imp.GetPlatformTextureSettings("Android");
                android.name = "Android";
                android.overridden = r.overridden;
                android.maxTextureSize = r.maxTextureSize;
                android.format = (TextureImporterFormat)r.format;
                android.compressionQuality = r.compressionQuality;
                android.crunchedCompression = r.crunchedCompression;
                android.textureCompression = (TextureImporterCompression)r.textureCompression;
                imp.SetPlatformTextureSettings(android);
                imp.SaveAndReimport();
                restaurados++;
            }
            estado = "Restaurados " + restaurados + " ajustes. El respaldo se conserva por seguridad.";
            Debug.Log("OPTIMIZADOR DR: " + estado);
        }
        catch (Exception e)
        {
            estado = "Error restaurando: " + e.Message;
            Debug.LogError(estado);
        }
        finally { EditorUtility.ClearProgressBar(); }
    }
}
#endif
