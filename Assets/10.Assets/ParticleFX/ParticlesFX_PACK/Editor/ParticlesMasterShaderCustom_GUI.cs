using UnityEngine;
using UnityEditor;

public class ParticlesMasterShaderCustom_GUI : ShaderGUI
{

    MaterialEditor editor;
    MaterialProperty[] properties;
    bool ShapesMode;
    bool GradientMode;

    //get preperties function
    MaterialProperty FindProperty(string name)
    {
        return FindProperty(name, properties);
    }
    //

    ////
    static GUIContent staticLabel = new GUIContent();
    static GUIContent MakeLabel(MaterialProperty property, string tooltip = null)
    {
        staticLabel.text = property.displayName;
        staticLabel.tooltip = tooltip;
        return staticLabel;
    }
    ////

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties)
    {
        this.editor = editor;
        this.properties = properties;
        DoMain();

    }


    // GUI FUNCTION	
    void DoMain()
    {
        //--- Logo
        Texture2D myGUITexture = (Texture2D)Resources.Load("ParticlesFX_PACK");
        GUILayout.Label(myGUITexture, EditorStyles.centeredGreyMiniLabel);

        //LABELS
        GUILayout.Label("/---------------/ PARTICLES FX SHADER /---------------/", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Label("DIFFUSE", EditorStyles.helpBox);

        // DIFFUSE
        // get properties
        MaterialProperty _ShapesMode = FindProperty("_ShapesMode");
        editor.ShaderProperty(_ShapesMode, MakeLabel(_ShapesMode));

        float value = _ShapesMode.floatValue;
        if (value == 0)
        {
            GUILayout.Label("X / Y  : Tiling  --  Z / W  :  Scrolling", EditorStyles.centeredGreyMiniLabel);
            MaterialProperty _MainTex = ShaderGUI.FindProperty("_MainTex", properties);

            //Add to GUI
            editor.TexturePropertySingleLine(MakeLabel(_MainTex, "DiffuseMap"), _MainTex, FindProperty("_ScaleOffset"));
        }
        else
        {


            MaterialProperty _AtlasPtc = ShaderGUI.FindProperty("_AtlasPtc", properties);
            editor.TexturePropertySingleLine(MakeLabel(_AtlasPtc, "Atlas Tex"), _AtlasPtc);

            MaterialProperty _Shape_Index = FindProperty("_Shape_Index");
            editor.ShaderProperty(_Shape_Index, MakeLabel(_Shape_Index));
            
            MaterialProperty _Columns = FindProperty("_Columns");
            editor.ShaderProperty(_Columns, MakeLabel(_Columns)); 

            MaterialProperty _Rows = FindProperty("_Rows");
            editor.ShaderProperty(_Rows, MakeLabel(_Rows));
            
            

       

            

        }
        



 
        GUILayout.Label("Colors Settings", EditorStyles.helpBox);

        MaterialProperty _EmissiveMult = FindProperty("_EmissiveMult");
        editor.ShaderProperty(_EmissiveMult, MakeLabel(_EmissiveMult));

        MaterialProperty _GradientColor = FindProperty("_GradientColor");
        editor.ShaderProperty(_GradientColor, MakeLabel(_GradientColor));

        float value3 = _GradientColor.floatValue;
        if (value3 == 1)
        {
            MaterialProperty _GradientColorA = FindProperty("_GradientColorA");
            editor.ShaderProperty(_GradientColorA, MakeLabel(_GradientColorA));

            MaterialProperty _GradientColorB = FindProperty("_GradientColorB");
            editor.ShaderProperty(_GradientColorB, MakeLabel(_GradientColorB));

            MaterialProperty _Grad_Min_Color = FindProperty("_Grad_Min_Color");
            editor.ShaderProperty(_Grad_Min_Color, MakeLabel(_Grad_Min_Color));

            MaterialProperty _GradientFaloff_Color = FindProperty("_GradientFaloff_Color");
            editor.ShaderProperty(_GradientFaloff_Color, MakeLabel(_GradientFaloff_Color));

            MaterialProperty _HorizVertGradientColor = FindProperty("_HorizVertGradientColor");
            editor.ShaderProperty(_HorizVertGradientColor, MakeLabel(_HorizVertGradientColor));

        }

        // Mask
        //Tex mask
        GUILayout.Label("Mask Settings", EditorStyles.helpBox);
        
        // Gradient mask
        MaterialProperty _GradientMode = FindProperty("_GradientMode");
        editor.ShaderProperty(_GradientMode, MakeLabel(_GradientMode));
        float value2 = _GradientMode.floatValue;
        if (value2 == 0)
        {
            GUILayout.Label("X / Y  : Tiling  --  Z / W  :  Scrolling", EditorStyles.centeredGreyMiniLabel);
            MaterialProperty MaskA_Text = ShaderGUI.FindProperty("_MaskA_Text", properties);

            //Add to GUI
            editor.TexturePropertySingleLine(MakeLabel(MaskA_Text, "MaskMap"), MaskA_Text, FindProperty("_MaskScaleOffset"));
        }
        else
        {
            MaterialProperty _Grad_Min = FindProperty("_Grad_Min");
            editor.ShaderProperty(_Grad_Min, MakeLabel(_Grad_Min));

            MaterialProperty _GradientFaloff = FindProperty("_GradientFaloff");
            editor.ShaderProperty(_GradientFaloff, MakeLabel(_GradientFaloff));

            MaterialProperty _HorizVertGradient = FindProperty("_HorizVertGradient");
            editor.ShaderProperty(_HorizVertGradient, MakeLabel(_HorizVertGradient));

           
        }

        // OUTLINE
        if (value == 1)
        {
            GUILayout.Label("Outline", EditorStyles.helpBox);

            MaterialProperty _Outline = FindProperty("_Outline");
            editor.ShaderProperty(_Outline, MakeLabel(_Outline));


            float value4 = _Outline.floatValue;

            if (value4 == 1)
            {
                MaterialProperty _OutlineOnly = FindProperty("_OutlineOnly");
                editor.ShaderProperty(_OutlineOnly, MakeLabel(_OutlineOnly));


                MaterialProperty _OutlineIntensity = FindProperty("_OutlineIntensity");
                editor.ShaderProperty(_OutlineIntensity, MakeLabel(_OutlineIntensity));
            }
            else
            {
                //nothing..
            }
        }

        // Dissolve
        
        GUILayout.Label("Dissolve Settings", EditorStyles.helpBox);
        

        MaterialProperty _Dissolve = FindProperty("_Dissolve");
        editor.ShaderProperty(_Dissolve, MakeLabel(_Dissolve));


        float value5 = _Dissolve.floatValue;
        if(value5 == 1)
        {
            GUILayout.Label("/---------------/ DISSOLVE BASED ON PTC ALPHA ANIMATION /---------------/", EditorStyles.centeredGreyMiniLabel);
            MaterialProperty _DissolveMask = ShaderGUI.FindProperty("_DissolveMask", properties);

            //Add to GUI
            editor.TexturePropertySingleLine(MakeLabel(_DissolveMask, "DissolveMask"), _DissolveMask);//, FindProperty("_ScaleOffset"));

            //MaterialProperty _DissolveFactor = FindProperty("_DissolveFactor");
            //editor.ShaderProperty(_DissolveFactor, MakeLabel(_DissolveFactor));
        }





    }
}