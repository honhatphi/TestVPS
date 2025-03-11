using Microsoft.EntityFrameworkCore;
using Trackify.Data;
using Trackify.Data.Type;

namespace Trackify.Common.Utils;
public class Generate(AppDbContext Database) : IGenerate
{
    public string Code(string prefix, int length, int sequenceValue)
    {
        string currentYear = DateTime.Now.ToString("yyyy");

        int maxSequenceValue = (int)Math.Pow(10, length) - 1;

        int currentSequenceValue = sequenceValue;
        int currentLength = length;

        while (currentSequenceValue > maxSequenceValue)
        {
            currentLength++;
            maxSequenceValue = (int)Math.Pow(10, currentLength) - 1;
        }

        int sequenceLength = currentLength - currentYear.Length - prefix.Length - 1;

        string sequence = currentSequenceValue.ToString().PadLeft(sequenceLength, '0');

        string result = $"{prefix}.{currentYear}{sequence}";

        return result;
    }

    public async Task<string> BarcodeEAN13Async(string sequenceCode)
    {
        SequenceNumber? sequence = await Database.SequenceNumbers.FirstOrDefaultAsync(x => x.Code == sequenceCode);

        if (sequence is null)
        {
            var newSequence = new SequenceNumber
            {
                Code = sequenceCode,
                NextValue = 2
            };

            Database.SequenceNumbers.Add(newSequence);

            return CreateEAN13(1);
        }
        else
        {
            string barcode = CreateEAN13(sequence.NextValue);

            sequence.NextValue++;

            Database.SequenceNumbers.Update(sequence);

            return barcode;
        }
    }

    private static string CreateEAN13(int sequenceValue)
    {
        string currentYear = DateTime.Now.ToString("yyyy");

        string sequence = sequenceValue.ToString().PadLeft(8, '0');

        char digit = GetDigit($"{currentYear}{sequence}");

        return $"{currentYear}{sequence}{digit}";
    }

    public async Task<int> GetNextValueAsync(string sequenceCode)
        => (await Database.SequenceNumbers.LastOrDefaultAsync(x => x.Code == sequenceCode))?.NextValue ?? 1;

    public async Task UpdateSequenceAsync(string sequenceCode, int nextValue)
    {
        SequenceNumber? sequence = await Database.SequenceNumbers.LastOrDefaultAsync(x => x.Code == sequenceCode);

        if (sequence is null)
        {
            var newSequence = new SequenceNumber
            {
                Code = sequenceCode,
                NextValue = nextValue
            };

            Database.SequenceNumbers.Add(newSequence);
        }
        else
        {
            sequence.NextValue++;

            Database.SequenceNumbers.Update(sequence);
        }
    }

    private static char GetDigit(string barcode)
    {
        if (barcode.Length != 12)
        {
            throw new ArgumentException("Barcode must be 12 characters long to generate EAN-13 check digit.");
        }

        int sum = 0;
        for (int i = 0; i < barcode.Length; i++)
        {
            _ = int.TryParse(barcode[i].ToString(), out int digit);
            sum += i % 2 == 0 ? digit : digit * 3;
        }

        int remainder = sum % 10;
        int checkDigit = remainder == 0 ? 0 : 10 - remainder;

        return checkDigit.ToString()[0];
    }
}
