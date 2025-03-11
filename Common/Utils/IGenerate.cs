namespace Trackify.Common.Utils;
public interface IGenerate
{
    string Code(string prefix, int length, int sequenceValue);
    Task<string> BarcodeEAN13Async(string sequenceCode);
    Task UpdateSequenceAsync(string sequenceCode, int nextValue);
    Task<int> GetNextValueAsync(string sequenceCode);
}
