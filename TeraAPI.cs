using Nickel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeraTaxMod
{
    public interface ITeraApi
    {

        internal IDeckEntry TeraTaxDeck { get; }
        internal IStatusEntry TeraPersistenceStatus { get; }
        internal IStatusEntry TeraTaxationStatus { get; }
        internal IStatusEntry TeraStallNextStatus { get; }
        internal IStatusEntry TeraLockNextStatus { get; }
        internal IStatusEntry TeraBailoutStatus { get; }
        internal IStatusEntry TeraDividendsStatus { get; }
    }
}
