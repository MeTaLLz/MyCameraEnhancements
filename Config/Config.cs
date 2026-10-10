using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MyCameraMods;

[BackgroundColor(150, 150, 150, 216)]
[SliderColor(121, 121, 121, 255)]
public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

    private float _smoothnessValue;
    private float _shakeValue;
    private float _hFactorValue;
    private float _vFactorValue;
    private float _dynSmoothnessValue;

    [Header("General")]
    [DefaultValue(true)]
    [BackgroundColor(130, 130, 130, 216)]
    public bool EnableOffset { get; set; } = true;

    [DefaultValue(1f)]
    [BackgroundColor(130, 130, 130, 216)]
    public float Smoothness
    {
        get => _smoothnessValue;
        set => _smoothnessValue = (float)Math.Round(value, 2);
    }

    [Header("Shake")]
    [DefaultValue(false)]
    [BackgroundColor(130, 130, 130, 216)]
    public bool EnableShake { get; set; } = false;

    [DefaultValue(1.0f)]
    [Range(0f, 5f)]
    [BackgroundColor(130, 130, 130, 216)]
    [Slider]
    public float ShakeStrength
    {
        get => _shakeValue;
        set => _shakeValue = (float)Math.Round(value * 10f) / 10f;
    }

    [Header("MouseOffset")]
    [DefaultValue(true)]
    [BackgroundColor(130, 130, 130, 216)]
    public bool EnableMouse { get; set; } = true;

    [DefaultValue(4)]
    [Range(0, 10)]
    [BackgroundColor(130, 130, 130, 216)]
    [Slider]
    public int MouseStrength { get; set; } = 4;

    [Header("DynamicOffset")]
    [DefaultValue(true)]
    [BackgroundColor(130, 130, 130, 216)]
    public bool EnableDynamic { get; set; } = true;

    [DefaultValue(2f)]
    [Range(0f, 5f)]
    [BackgroundColor(130, 130, 130, 216)]
    [Slider]
    public float HorizontalFactor
    {
        get => _hFactorValue;
        set => _hFactorValue = (float)Math.Round(value, 1);
    }

    [DefaultValue(2f)]
    [Range(0f, 5f)]
    [BackgroundColor(130, 130, 130, 216)]
    [Slider]
    public float VerticalFactor
    {
        get => _vFactorValue;
        set => _vFactorValue = (float)Math.Round(value, 1);
    }

    [DefaultValue(0)]
    [Range(0, 20)]
    [BackgroundColor(130, 130, 130, 216)]
    [Slider]
    public int RequiredXSpeed { get; set; } = 0;

    [DefaultValue(0)]
    [Range(0, 20)]
    [BackgroundColor(130, 130, 130, 216)]
    [Slider]
    public int RequiredYSpeed { get; set; } = 0;

    [DefaultValue(0f)]
    [Range(0f, 1f)]
    [BackgroundColor(130, 130, 130, 216)]
    [Slider]
    public float DynamicSmoothness
    {
        get => _dynSmoothnessValue;
        set => _dynSmoothnessValue = (float)Math.Round(value, 2);
    }

    public override void OnChanged()
    {
        ConfigCache.Update(this);
    }
}