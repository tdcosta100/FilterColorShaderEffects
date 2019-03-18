using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace FilterColorShaderEffects
{
	/// <summary>
	/// Replaces four matched color with a color, and all other colors with other color
	/// </summary>
	public class Filter4ColorEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Filter4ColorEffect), 0);
		public static readonly DependencyProperty Color1ToFilterProperty = DependencyProperty.Register("Color1ToFilter", typeof(Color), typeof(Filter4ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty Color2ToFilterProperty = DependencyProperty.Register("Color2ToFilter", typeof(Color), typeof(Filter4ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(1)));
		public static readonly DependencyProperty Color3ToFilterProperty = DependencyProperty.Register("Color3ToFilter", typeof(Color), typeof(Filter4ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(2)));
		public static readonly DependencyProperty Color4ToFilterProperty = DependencyProperty.Register("Color4ToFilter", typeof(Color), typeof(Filter4ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(3)));
		public static readonly DependencyProperty ColorWhenMatchedProperty = DependencyProperty.Register("ColorWhenMatched", typeof(Color), typeof(Filter4ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(4)));
		public static readonly DependencyProperty ColorWhenNotMatchedProperty = DependencyProperty.Register("ColorWhenNotMatched", typeof(Color), typeof(Filter4ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(5)));

		public Filter4ColorEffect()
		{
			PixelShader pixelShader = new PixelShader
			{
				UriSource = new Uri("/FilterColorShaderEffects;component/Shaders/Filter4ColorEffect.cso", UriKind.Relative)
			};

			PixelShader = pixelShader;

			UpdateShaderValue(InputProperty);
			UpdateShaderValue(Color1ToFilterProperty);
			UpdateShaderValue(Color2ToFilterProperty);
			UpdateShaderValue(Color3ToFilterProperty);
			UpdateShaderValue(Color4ToFilterProperty);
			UpdateShaderValue(ColorWhenMatchedProperty);
			UpdateShaderValue(ColorWhenNotMatchedProperty);
		}

		public Brush Input
		{
			get => (Brush)GetValue(InputProperty);
			set => SetValue(InputProperty, value);
		}

		/// <summary>
		/// Color 1 to filter
		/// </summary>
		public Color Color1ToFilter
		{
			get => (Color)GetValue(Color1ToFilterProperty);
			set => SetValue(Color1ToFilterProperty, value);
		}

		/// <summary>
		/// Color 2 to filter
		/// </summary>
		public Color Color2ToFilter
		{
			get => (Color)GetValue(Color2ToFilterProperty);
			set => SetValue(Color2ToFilterProperty, value);
		}

		/// <summary>
		/// Color 3 to filter
		/// </summary>
		public Color Color3ToFilter
		{
			get => (Color)GetValue(Color3ToFilterProperty);
			set => SetValue(Color3ToFilterProperty, value);
		}

		/// <summary>
		/// Color 4 to filter
		/// </summary>
		public Color Color4ToFilter
		{
			get => (Color)GetValue(Color4ToFilterProperty);
			set => SetValue(Color4ToFilterProperty, value);
		}

		/// <summary>
		/// Color when matched
		/// </summary>
		public Color ColorWhenMatched
		{
			get => (Color)GetValue(ColorWhenMatchedProperty);
			set => SetValue(ColorWhenMatchedProperty, value);
		}

		/// <summary>
		/// Color when not matched
		/// </summary>
		public Color ColorWhenNotMatched
		{
			get => (Color)GetValue(ColorWhenNotMatchedProperty);
			set => SetValue(ColorWhenNotMatchedProperty, value);
		}
	}
}