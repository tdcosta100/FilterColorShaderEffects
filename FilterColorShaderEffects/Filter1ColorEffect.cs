using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace FilterColorShaderEffects
{
	/// <summary>
	/// Replaces a matched color with a color, and all other colors with other color
	/// </summary>
	public class Filter1ColorEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Filter1ColorEffect), 0);
		public static readonly DependencyProperty ColorToFilterProperty = DependencyProperty.Register("ColorToFilter", typeof(Color), typeof(Filter1ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty ColorWhenMatchedProperty = DependencyProperty.Register("ColorWhenMatched", typeof(Color), typeof(Filter1ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(1)));
		public static readonly DependencyProperty ColorWhenNotMatchedProperty = DependencyProperty.Register("ColorWhenNotMatched", typeof(Color), typeof(Filter1ColorEffect), new UIPropertyMetadata(Color.FromArgb(0, 0, 0, 0), PixelShaderConstantCallback(2)));

		public Filter1ColorEffect()
		{
			PixelShader pixelShader = new PixelShader
			{
				UriSource = new Uri("/FilterColorShaderEffects;component/Shaders/Filter1ColorEffect.cso", UriKind.Relative)
			};

			PixelShader = pixelShader;

			UpdateShaderValue(InputProperty);
			UpdateShaderValue(ColorToFilterProperty);
			UpdateShaderValue(ColorWhenMatchedProperty);
			UpdateShaderValue(ColorWhenNotMatchedProperty);
		}

		public Brush Input
		{
			get => (Brush)GetValue(InputProperty);
			set => SetValue(InputProperty, value);
		}

		/// <summary>
		/// Color to filter
		/// </summary>
		public Color ColorToFilter
		{
			get => (Color)GetValue(ColorToFilterProperty);
			set => SetValue(ColorToFilterProperty, value);
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
