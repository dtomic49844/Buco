using System.Collections.Generic;
using Buco.Models;
using Buco.ViewModels;

namespace Buco.Mappers
{
    public class WeightEntryMapper : IWeightEntryMapper
    {
        public IEnumerable<WeightEntryViewModel> MapWeightEntries(IEnumerable<WeightEntry> weightEntries)
        {
            var weightEntriesViewModel = new List<WeightEntryViewModel>();
            foreach (var weightEntry in weightEntries)
            {
                var weighEntryViewModel = MapWeightEntry(weightEntry);
                weightEntriesViewModel.Add(weighEntryViewModel);
            }
            return weightEntriesViewModel;
        }

        public WeightEntryViewModel MapWeightEntry(WeightEntry weightEntry)
        {
            var weighEntryViewModel = new WeightEntryViewModel
            {
                WeightEntryId = weightEntry.WeightEntryId,
                WeightTime = weightEntry.WeightTime,
                MesuredWeight = weightEntry.MesuredWeight,
                PetId = weightEntry.PetId
            };
            return weighEntryViewModel;
        }
    }
}
