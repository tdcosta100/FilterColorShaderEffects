sampler2D Input : register(S0);

// <summary>Color 1 to filter</summary>
float4 Color1ToFilter : register(C0);

// <summary>Color 2 to filter</summary>
float4 Color2ToFilter : register(C1);

// <summary>Color 3 to filter</summary>
float4 Color3ToFilter : register(C2);

// <summary>Color 4 to filter</summary>
float4 Color4ToFilter : register(C3);

// <summary>Color when matched</summary>
float4 ColorWhenMatched : register(C4);

// <summary>Color when not matched</summary>
float4 ColorWhenNotMatched : register(C5);

float4 main(float2 locationSource : TEXCOORD) : COLOR
{
    float4 currentColor;
    currentColor = tex2D(Input, locationSource.xy);

    if (
    	any(currentColor - Color1ToFilter)
    	&&
    	any(currentColor - Color2ToFilter)
    	&&
    	any(currentColor - Color3ToFilter)
    	&&
    	any(currentColor - Color4ToFilter)
    )
    {
        currentColor = ColorWhenNotMatched;
    }
    else
    {
        currentColor = ColorWhenMatched;
    }

    return currentColor;
}