// GAPH Special Skills Effects Pack - material inspector for
// Integrated Effect / Decal / Distortion Effect.
using UnityEditor;
using UnityEngine;

public class GAPH_SpecialSkillsEffectsShaderGUI : ShaderGUI
{
    MaterialEditor editor;
    MaterialProperty[] properties;

    static GUIStyle headerStyle;

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
    {
        editor = materialEditor;
        properties = props;

        if (headerStyle == null)
        {
            headerStyle = new GUIStyle(EditorStyles.boldLabel);
            headerStyle.fontSize = 12;
        }

        bool isDistortion = P("_DistortFactor") != null;
        bool isDecal      = P("_StencilRef") != null;

        if (isDistortion)      DrawDistortion();
        else if (isDecal)      DrawDecal();
        else                   DrawIntegrated();
    }

    // Integrated Effect
    void DrawIntegrated()
    {
        Section("Main");
        Draw("_TintColor", "Color");
        if (Feature("_SecondColor", "Use Second Color"))
        {
            Draw("_TintColor2", "Color 2");
            Unindent();
        }
        Tex("_MainTex", "Main Texture");
        Draw("_ColorFactor", "Color Intensity");

        Section("Texture Animation");
        if (Feature("_TextureAnimate", "Texture Animation"))
        {
            Draw("_TextureAnimateSpeed", "Speed");
            Draw("_TextureAnimateStyle", "Style (0 / 1 / 2)");
            if (Feature("_TextureAnimateAdvanced", "Advanced Multi-Layer Mix"))
            {
                Draw("_MaxIndex", "Layer Count");
                Unindent();
            }
            Unindent();
        }

        Section("UV Options");
        if (Feature("_TextureBlend", "Texture Blend (Flipbook Smoothing)"))
        {
            Info("Requires the particle system Custom Vertex Streams: UV;UV2;AnimBlend.");
            Unindent();
        }
        if (Feature("_MixedMove", "Straight Move (All Layers)"))
        {
            Draw("_TexPosMove", "Move Amount");
            Unindent();
        }
        if (Feature("_IsRotateAngle", "Rotate UV"))
        {
            Draw("_RotateAngle", "Angle");
            Unindent();
        }
        if (Feature("_TexcoordMove", "Texcoord Scroll"))
        {
            if (Feature("_TexcoordMoveUsingCustom", "From Custom Vertex Stream"))
            {
                Info("Reads the scroll offset from TEXCOORD1 (particle custom data).");
                Unindent();
            }
            else
            {
                Draw("_xTexcoordMove", "Scroll X");
                Draw("_yTexcoordMove", "Scroll Y");
            }
            Draw("_TexcoordMoveStrength", "Scroll Strength");
            Unindent();
        }

        Section("Distortion / Noise");
        if (Feature("_NormalDistortion", "Normal Distortion"))
        {
            Tex("_NormalTex", "Normal Texture");
            Draw("_NormalDistortionFactor", "Distortion Strength");
            if (Feature("_NormalAnimate", "Animate Normal"))
            {
                Draw("_NormalAnimateSpeed", "Animation Speed");
                Unindent();
            }
            Unindent();
        }
        if (Feature("_TextureNoise", "UV Noise"))
        {
            Tex("_NoiseNormal", "Noise Texture");
            Draw("_NoiseNormalFactor", "Noise Strength");
            Unindent();
        }

        Section("Mask");
        if (Feature("_MaskFade", "Mask Fade"))
        {
            Draw("_UseTexAnimation", "Use Animated UV For Masks");
            Tex("_FixedMaskTex", "Fixed Mask");
            Tex("_MaskTex", "Fade Mask");
            Draw("_MaskOffsetFactor", "Mask Offset Strength");
            Tex("_MaskDistortion", "Mask Distortion");
            Draw("_MaskAnimatedSpeed", "Mask Animation Speed");
            Unindent();
        }
        Draw("_MaskCutOut", "Alpha Cutout / Global Alpha");

        Section("Vertex Animation");
        if (Feature("_VertexAnimation", "Vertex Animation"))
        {
            Tex("_NoiseTex", "Noise Map");
            Draw("_NoiseValue", "Noise Value (XYZ = Motion, W = Base Scale)");
            Draw("_NoiseScale", "Noise Scale");
            Unindent();
        }

        Section("Rim Light");
        if (Feature("_RimLight", "Rim Light"))
        {
            Draw("_RimColor", "Rim Color");
            Draw("_RimScale", "Rim Power");
            Draw("_RimStrength", "Rim Strength");
            Unindent();
        }

        Section("Impact");
        if (Feature("_Impact", "Impact Ripple"))
        {
            Info("Hit positions are supplied at runtime by the pack scripts (ShieldActivate).");
            Draw("_ImpactSize", "Impact Size");
            Draw("_ImpactFactor", "Impact Strength");
            Unindent();
        }

        Section("Line Pass");
        if (Feature("_LinePass", "Line Pass"))
        {
            Tex("_LinePassTex", "Line Texture");
            Draw("_TexLength", "Texture Length");
            Unindent();
        }

        Section("Soft Particles");
        if (Feature("_SoftParticle", "Soft Particles"))
        {
            Draw("_InvFade", "Fade Factor");
            Info("Built-in: Quality Settings > Soft Particles\nURP: URP Asset > Depth Texture");
            Unindent();
        }

        Section("Rendering");
        BlendPreset();
        Draw("_BlendSrc", "Blend Source");
        Draw("_BlendDst", "Blend Destination");
        Draw("_Culling", "Culling");
        Draw("_ZWrite", "ZWrite");
        Draw("_ZTest2", "ZTest");
        Footer();
    }

    // Decal
    void DrawDecal()
    {
        Section("Main");
        Draw("_TintColor", "Color");
        if (Feature("_SecondColor", "Use Second Color"))
        {
            Draw("_TintColor2", "Color 2");
            Unindent();
        }
        Tex("_MainTex", "Decal Texture");
        Draw("_ColorFactor", "Color Intensity");

        Section("Animation");
        if (Feature("_TextureAnimate", "Texture Animation"))
        {
            Draw("_TextureAnimateSpeed", "Speed");
            Unindent();
        }
        if (Feature("_NormalDistortion", "Normal Distortion"))
        {
            Tex("_NormalTex", "Normal Texture");
            Draw("_NormalDistortionFactor", "Distortion Strength");
            Draw("_NormalAnimateSpeed", "Animation Speed");
            Unindent();
        }

        Section("Mask");
        if (Feature("_MaskFade", "Mask Fade"))
        {
            Tex("_MaskTex", "Fade Mask");
            Unindent();
        }
        Draw("_MaskCutOut", "Alpha Cutout / Global Alpha");

        Section("Rendering");
        BlendPreset();
        Draw("_BlendSrc", "Blend Source");
        Draw("_BlendDst", "Blend Destination");
        Draw("_ZTest1", "ZTest");
        Draw("_StencilRef", "Stencil Ref");
        Draw("_StencilComp", "Stencil Comp");
        Info("URP: URP Asset > Depth Texture\nHDRP: the decal object needs the GaphDecalProjector component");
        Footer();
    }

    // Distortion
    void DrawDistortion()
    {
        Section("Distortion");
        Draw("_TintColor", "Tint Color");
        Tex("_Mask", "Mask (Alpha = Strength)");
        Tex("_NormalMap", "Normal Map");
        Draw("_DistortFactor", "Distortion Strength");
        Draw("_SRPDistortScale", "URP/HDRP Strength Scale");
        Info("URP/HDRP only. 1 = same strength as Built-in.");

        Section("Soft Particles");
        if (Feature("_SoftParticle", "Soft Particles"))
        {
            Draw("_InvFade", "Fade Factor");
            Info("Built-in: Quality Settings > Soft Particles\nURP: URP Asset > Depth Texture");
            Unindent();
        }

        Section("Rendering");
        Info("URP: no setup needed (drawn by GaphURPDistortion after transparents)\nHDRP: Distortion enabled in the HDRP Asset and Frame Settings (default)");
        Footer();
    }

    // helpers
    MaterialProperty P(string name)
    {
        return FindProperty(name, properties, false);
    }

    void Section(string title)
    {
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField(title, headerStyle);
        Rect r = GUILayoutUtility.GetRect(0f, 2f);
        r.height = 1f;
        EditorGUI.DrawRect(r, new Color(0.5f, 0.5f, 0.5f, 0.35f));
        EditorGUILayout.Space(2);
    }

    void Draw(string name, string label)
    {
        MaterialProperty p = P(name);
        if (p != null)
            editor.ShaderProperty(p, label);
    }

    // Returns true and indents when enabled; call Unindent() after the sub-properties.
    bool Feature(string name, string label)
    {
        MaterialProperty p = P(name);
        if (p == null)
            return false;
        editor.ShaderProperty(p, label);
        bool on = !p.hasMixedValue && p.floatValue > 0.5f;
        if (on)
            EditorGUI.indentLevel++;
        return on;
    }

    void Unindent()
    {
        EditorGUI.indentLevel--;
    }

    void Tex(string name, string label)
    {
        MaterialProperty p = P(name);
        if (p == null)
            return;
        editor.TexturePropertySingleLine(new GUIContent(label), p);
        EditorGUI.indentLevel += 2;
        editor.TextureScaleOffsetProperty(p);
        EditorGUI.indentLevel -= 2;
    }

    void Info(string message)
    {
        EditorGUILayout.HelpBox(message, MessageType.Info);
    }

    static readonly string[] presetNames = { "Additive (SrcAlpha One)", "Alpha Blended", "Additive Strong (One One)", "Custom" };

    void BlendPreset()
    {
        MaterialProperty src = P("_BlendSrc");
        MaterialProperty dst = P("_BlendDst");
        if (src == null || dst == null)
            return;

        int current = 3;
        if (!src.hasMixedValue && !dst.hasMixedValue)
        {
            int s = (int)src.floatValue, d = (int)dst.floatValue;
            if (s == 5 && d == 1)       current = 0;
            else if (s == 5 && d == 10) current = 1;
            else if (s == 1 && d == 1)  current = 2;
        }

        EditorGUI.BeginChangeCheck();
        int chosen = EditorGUILayout.Popup("Blend Preset", current, presetNames);
        if (EditorGUI.EndChangeCheck() && chosen != current && chosen != 3)
        {
            editor.RegisterPropertyChangeUndo("Blend Preset");
            switch (chosen)
            {
                case 0: src.floatValue = 5; dst.floatValue = 1;  break;
                case 1: src.floatValue = 5; dst.floatValue = 10; break;
                case 2: src.floatValue = 1; dst.floatValue = 1;  break;
            }
        }
    }

    void Footer()
    {
        EditorGUILayout.Space(6);
        editor.RenderQueueField();
        editor.EnableInstancingField();
    }
}
