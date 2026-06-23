using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeraTaxMod
{
    public sealed class TeraAPI_Implementation : ITeraApi
    {
        public IDeckEntry TeraTaxDeck
       => ModEntry.Instance.TeraTaxDeck;

        public IStatusEntry TeraPersistenceStatus
            => ModEntry.Instance.TeraPersistenceStatus;

        public IStatusEntry TeraTaxationStatus
            => ModEntry.Instance.TeraTaxationStatus;

        public IStatusEntry TeraStallNextStatus
            => ModEntry.Instance.TeraStallNextStatus;

        public IStatusEntry TeraLockNextStatus
            => ModEntry.Instance.TeraLockNextStatus;
        public IStatusEntry TeraBailoutStatus
            => ModEntry.Instance.TeraBailoutStatus;
        public IStatusEntry TeraDividendsStatus
            => ModEntry.Instance.TeraDividendsStatus;
    }
}
