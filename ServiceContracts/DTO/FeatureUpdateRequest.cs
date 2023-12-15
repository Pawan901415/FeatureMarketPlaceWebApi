using Entities;

public class FeatureUpdateRequest
{
    public string? FeatureName { get; set; }
    public string Value { get; set; }
    public string? FeatureDataType { get; set; }

    public FeatureClass ToFeature(FeatureClass existingFeature)
    {
        if (FeatureName != null)
        {
            existingFeature.FeatureName = FeatureName;
        }
        if (Value != null)
        {
            existingFeature.Value = Value;
        }
        if (FeatureDataType != null)
        {
            existingFeature.FeatureDataType = FeatureDataType;
        }

        return existingFeature;
    }
}
