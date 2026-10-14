# 🎮 DOS REALIDADES

Videojuego cooperativo 2D desarrollado por **Media Create**.

> **Dos jugadores · Dos perspectivas · Una sola solución**

---

# 👥 EQUIPO

- **Laura Carolina Beltrán Moreno** — Lead Programmer
- **Sebastián Guzmán Castiblanco** — Game Designer
- **Diana Ximena Ángel Guachetá** — Lead Artist

---

# 🔗 REPOSITORIO

```text
https://github.com/Carobm10/DosRealidades.git
```

Antes de trabajar, cada integrante debe aceptar la invitación como colaborador del repositorio.

---

# ⚙️ VERSIÓN DEL PROYECTO

Todos debemos utilizar exactamente:

```text
Unity 6000.6.4f1
```

No abrir el proyecto con otra versión de Unity.

---

# 📥 PRIMERA VEZ — CLONAR EL PROYECTO

## 1. Abrir Visual Studio Code

Abrir **Visual Studio Code**.

En la pantalla principal seleccionar:

```text
Clone Git Repository
```

También se puede hacer desde:

```text
Source Control
→ Clone Repository
```

---

## 2. Pegar el enlace del repositorio

Cuando VS Code pida:

```text
Provide repository URL
```

pegar:

```text
https://github.com/Carobm10/DosRealidades.git
```

Presionar **Enter**.

---

## 3. Elegir dónde guardar el proyecto

Seleccionar una carpeta general donde guardar proyectos.

Ejemplo:

```text
Documents\PROYECTOS
```

VS Code creará automáticamente:

```text
PROYECTOS
└── DosRealidades
```

No es necesario crear previamente la carpeta `DosRealidades`.

---

# 🎮 ABRIR EL PROYECTO EN UNITY

Abrir:

```text
Unity Hub
→ Projects
→ Add project from disk
```

Seleccionar la carpeta:

```text
DosRealidades
```

La carpeta correcta contiene:

```text
Assets
Packages
ProjectSettings
README.md
```

Abrir utilizando:

```text
Unity 6000.6.4f1
```

La primera apertura puede tardar mientras Unity genera los archivos locales del proyecto.

---

# 📁 ORGANIZACIÓN DEL PROYECTO

Todo el contenido propio del videojuego está dentro de:

```text
Assets/_Project
```

La estructura principal es:

```text
_Project
├── Animations
├── Art
├── Audio
├── Materials
├── Prefabs
├── Scenes
├── Scripts
├── ScriptableObjects
└── UI
```

---

# 👩‍💻 LAURA — LEAD PROGRAMMER

Responsable principalmente de:

- programación;
- gameplay;
- multiplayer;
- movimiento;
- interacción;
- NetworkManager;
- Relay;
- sincronización;
- inventario;
- vida;
- timer;
- integración de sistemas.

Trabaja principalmente en:

```text
Assets/_Project/Scripts
```

Especialmente:

```text
Scripts
├── Core
├── Player
├── Network
├── Interaction
├── Gameplay
└── UI
```

También trabaja principalmente en:

```text
Assets/_Project/Prefabs/Network
Assets/_Project/Prefabs/Characters
Assets/_Project/Scenes/Test
Assets/_Project/Scenes/Core
```

Escenas técnicas principales:

```text
00_Bootstrap
Test_Network
```

---

# 🎨 DIANA — LEAD ARTIST

Responsable principalmente de:

- personajes;
- escenarios;
- props;
- sprites;
- animaciones;
- VFX;
- recursos visuales;
- HUD;
- botones;
- inventario visual;
- identidad visual de las dos realidades.

Trabaja principalmente en:

```text
Assets/_Project/Art
```

Organizado en:

```text
Art
├── Characters
├── Environment
├── Props
├── Tiles
└── VFX
```

También puede trabajar en:

```text
Assets/_Project/Animations
Assets/_Project/Materials
Assets/_Project/UI
Assets/_Project/Prefabs/Environment
Assets/_Project/Prefabs/UI
```

Cuando necesite integrar arte dentro de una escena principal, debe avisar primero al equipo.

---

# 🎮 SEBASTIÁN — GAME DESIGNER

Responsable principalmente de:

- diseño de niveles;
- puzzles;
- objetivos;
- misiones;
- narrativa;
- diálogos;
- NPC;
- pistas;
- progresión;
- balance;
- diseño de interacción;
- definición de lo que ve cada realidad;
- retos cooperativos.

Trabaja principalmente sobre el diseño de:

```text
Assets/_Project/Scenes/Levels
```

Escenas:

```text
Level_01_Lobby
Level_02_Hotel
Level_03_Room13
```

Puede utilizar placeholders para construir la lógica del nivel, por ejemplo:

```text
Cuadrados
Puertas temporales
Botones
NPC temporales
Objetos simples
Zonas de interacción
```

Después:

```text
Sebastián
→ diseña la experiencia y el nivel

Diana
→ reemplaza placeholders por arte

Laura
→ conecta programación y sistemas
```

Antes de modificar una escena principal debe avisar al equipo.

---

# 🎬 ESCENAS

## Core

```text
00_Bootstrap
01_MainMenu
```

## Levels

```text
Level_01_Lobby
Level_02_Hotel
Level_03_Room13
```

## Test

```text
Test_Network
```

`Test_Network` se utiliza para probar sistemas antes de integrarlos en las escenas finales.

---

# ⚠️ REGLA IMPORTANTE DE ESCENAS

No trabajar dos personas al mismo tiempo sobre la misma escena.

Antes de modificar una escena, avisar al grupo.

Ejemplo:

```text
Sebas → trabajando Level_01_Lobby
```

Mientras Sebastián trabaja allí:

```text
Diana → puede trabajar en Art, Animations, UI o Prefabs

Laura → puede trabajar en Scripts, Network o Test_Network
```

Cuando Sebastián termine:

```text
Commit
→ Sync Changes
```

Luego los demás hacen:

```text
Pull
```

y continúan desde la versión actualizada.

---

# 🔄 ANTES DE EMPEZAR A TRABAJAR

Siempre traer primero los cambios del equipo.

Abrir:

```text
Visual Studio Code
→ Source Control
```

Luego:

```text
...
→ Pull
```

## REGLA

> 🔴 Siempre hacer **Pull antes de empezar a trabajar**.

Después del Pull se puede abrir Unity.

---

# 💾 CUANDO TERMINES DE TRABAJAR

Guardar primero el trabajo en Unity:

```text
Ctrl + S
```

Luego volver a:

```text
Visual Studio Code
→ Source Control
```

Los archivos modificados aparecerán en:

```text
Changes
```

---

# ➕ PREPARAR LOS CAMBIOS

Revisar qué archivos aparecen en:

```text
Changes
```

Al lado de cada archivo que se quiera subir, pulsar:

```text
+
```

El archivo pasará a:

```text
Staged Changes
```

También se puede utilizar el `+` junto a `Changes` para preparar todos los archivos.

---

# 📝 HACER COMMIT

En la caja de mensaje escribir brevemente qué se hizo.

Ejemplos:

```text
feat: agregar arte de Elian
```

```text
feat: crear diseño del lobby
```

```text
feat: agregar interacción con NPC
```

```text
feat: crear interfaz del inventario
```

```text
fix: corregir animación
```

Después seleccionar:

```text
Commit
```

---

# ☁️ SUBIR LOS CAMBIOS

Después del Commit seleccionar:

```text
Sync Changes
```

También se puede hacer desde:

```text
Source Control
→ ...
→ Push
```

Cuando termine, los cambios estarán disponibles para todo el equipo.

---

# 🔁 FLUJO DE TRABAJO

Siempre seguir este orden:

```text
1. Abrir VS Code
        ↓
2. Source Control
        ↓
3. Pull
        ↓
4. Abrir Unity
        ↓
5. Trabajar
        ↓
6. Guardar
        ↓
7. Volver a VS Code
        ↓
8. Revisar Changes
        ↓
9. Stage (+)
        ↓
10. Commit
        ↓
11. Sync Changes
```

---

# 🚨 SI APARECE UN CONFLICTO

Si VS Code muestra:

```text
Merge Conflict
```

NO seleccionar opciones al azar.

Especial cuidado con:

```text
.unity
.prefab
ProjectSettings
Packages
```

No hacer inmediatamente:

```text
Accept Current
```

ni:

```text
Accept Incoming
```

Avisar primero al equipo y revisar qué versión debe conservarse.

---

# 🚫 NO SUBIR ARCHIVOS GENERADOS POR UNITY

El proyecto ya tiene configurado:

```text
.gitignore
```

No modificarlo sin avisar.

Carpetas como estas no deben subirse:

```text
Library
Temp
Logs
UserSettings
Builds
.vscode
```

---

# 📌 REGLAS RÁPIDAS

## Antes de trabajar

```text
PULL
```

## Antes de modificar una escena

```text
AVISAR AL EQUIPO
```

## Después de trabajar

```text
STAGE
→ COMMIT
→ SYNC CHANGES
```

## Si aparece un conflicto

```text
NO RESOLVERLO AL AZAR
→ AVISAR AL EQUIPO
```

---
