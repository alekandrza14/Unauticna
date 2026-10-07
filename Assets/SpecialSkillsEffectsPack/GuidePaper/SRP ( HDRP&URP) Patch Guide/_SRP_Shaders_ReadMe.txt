============================================================================
 GAPH - 100 Special Skills Effects Pack
 Shaders for Built-in / URP / HDRP - Read Me
============================================================================

1. Overview
   Integrated Effect, Distortion Effect and Decal each support the Built-in
   Render Pipeline, URP and HDRP in a single shader file.
   Supported versions: Unity 2022.3 LTS ~ latest Unity version.
   The separate URP/HDRP patch packages are no longer needed.

2. Pipeline settings
   * Built-in : Soft particles require Quality Settings > Soft Particles.
   * URP      : Enable Depth Texture on the URP Asset (soft particles,
                decals). Distortion needs no setup.
   * HDRP     : Works with default settings. Distortion must be enabled in
                the HDRP Asset and in the camera Frame Settings (on by
                default).
   * Demo scene: the floor and target objects use the Standard shader.
                On URP/HDRP convert them with Render Pipeline Converter
                (URP) or HDRP Wizard (HDRP). The effects do not need this.

3. Distortion
   * "SRP Distortion Scale" adjusts the strength on URP/HDRP only.
     1 = same strength as Built-in.
   * On URP, distortion is drawn by GaphURPDistortion.cs
     (Scripts/ForEffects/URP). It registers itself; no Renderer Feature
     is needed. It is drawn after all transparent objects and refracts
     them, like GrabPass on Built-in and distortion on HDRP. The copy of
     the screen is made only while a distortion effect is visible.
   * The URP folder has its own assembly definition that compiles only
     when URP is installed. Keep the .asmdef file next to the script.

4. Decal
   * On HDRP the decal object needs the GaphDecalProjector component. All
     decal prefabs in this pack already have it. Add it only to decal
     objects you create yourself (on the object with the MeshRenderer).
   * The stencil test defaults to Always. To get the old behaviour
     (Ref 1 / NotEqual), set Stencil Comp to Not Equal on the material.

5. Changes
   * Shader menu path: "GAPH/Special Skills Effects Pack/..."
     Existing materials keep working.
   * Fixed distortion effects looking punched through on URP and HDRP.
   * Fixed dark lines on URP where distortion particles overlap. URP no
     longer needs Opaque Texture for distortion.
   * Fixed the "Is Soft Particles" toggle of Integrated Effect. It is off on
     all included materials to keep their original look.
   * Removed the unused shader-side particle instancing toggle.
   * Feature keywords are now local (shader_feature_local).
   * Distortion strength is the same on all graphics APIs.
   * XR single-pass instanced / multiview support.
   * Fixed UV scrolling jitter on mobile after long play time.
   * New material inspector for all three shaders.
   * Fixed the ring of Effect_22_HoloAirInvade not showing.
   * Materials and prefabs in the Patch packages include the same updates.

6. Known limitations
   * On URP and HDRP, transparent objects in front of a distortion effect
     are refracted as well.
   * Decals do not support orthographic cameras.
   * Decals are not supported in HDRP + XR (single-pass instanced).
   * These shaders are not SRP Batcher compatible.
