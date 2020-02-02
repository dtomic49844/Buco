using Buco.Models;
using Buco.ViewModels;
using System.Collections.Generic;

namespace Buco.Mappers
{
    public interface IWeightEntryMapper
    {
        IEnumerable<WeightEntryViewModel> MapWeightEntries(IEnumerable<WeightEntry> weightEntries);
        WeightEntryViewModel MapWeightEntry(WeightEntry weightEntry);
    }
}
