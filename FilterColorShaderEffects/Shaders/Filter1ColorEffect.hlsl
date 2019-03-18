sampler2D Input : register(S0);

// <summary>Color to filter</summary>
float4 ColorToFilter : register(C0);

// <summary>Color when matched</summary>
float4 ColorWhenMatched : register(C1);

// <summary>Color when not matched</summary>
float4 ColorWhenNotMatched : register(C2);

float4 main(float2 locationSource : TEXCOORD) : COLOR
{
    float4 currentColor;
    currentColor = tex2D(Input, locationSource.xy);

    if (any(currentColor - ColorToFilter))
    {
        currentColor = ColorWhenNotMatched;
    }
    else
    {
        currentColor = ColorWhenMatched;
    }

    return currentColor;
}