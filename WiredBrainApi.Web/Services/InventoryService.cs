using Microsoft.ApplicationInsights;

namespace WiredBrainApi.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly TelemetryClient _telemetry;
        public InventoryService(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }

        private List<LocationInventory> _inventoryDb = new List<LocationInventory>()
        {
            new LocationInventory
            {
                Id = 1,
                LocationName = "Main Street",
                KgDarkRoast = 5.8m,
                KgLightRoast = 10.0m,
                KgMediumRoast = 7.5m,
                KgSeasonalRoast = 0.0m
            },

            new LocationInventory
            {
                Id = 2,
                LocationName = "Madison Avenue",
                KgDarkRoast = 0.8m,
                KgLightRoast = 8.4m,
                KgMediumRoast = 2.5m,
                KgSeasonalRoast = 10.0m
            },

            new LocationInventory
            {
                Id = 3,
                LocationName = "Ventura Boulevard",
                KgDarkRoast = 1.8m,
                KgLightRoast = 14.6m,
                KgMediumRoast = 0.0m,
                KgSeasonalRoast = 9.0m
            },

            new LocationInventory
            {
                Id = 4,
                LocationName = "Sesame Street",
                KgDarkRoast = 0.0m,
                KgLightRoast = 0.0m,
                KgMediumRoast = 0.0m,
                KgSeasonalRoast = 0.0m
            }

        };

        public LocationInventory? GetLocationInventory(int locationId)
        {
            _telemetry.TrackEvent($"GetLocationInventory - LocationId: {locationId}");

            LocationInventory? result = null;
            try
            {
                result = _inventoryDb.FirstOrDefault(i => i.Id == locationId);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Inventory Location {locationId} Not Found");
                }
            }
            catch (System.Exception ex)
            {
                _telemetry.TrackException(ex);
            }

            return result;

        }
    }
}
