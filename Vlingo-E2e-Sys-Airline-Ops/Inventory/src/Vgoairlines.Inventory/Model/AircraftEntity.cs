// Copyright © 2012-2023 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using Vlingo.Xoom.Common;
using Vlingo.Xoom.Lattice.Model.Stateful;

namespace Vgoairlines.Inventory.Model
{
    public class AircraftEntity : StatefulEntity<AircraftState>, IAircraft
    {
        private AircraftState _state;
        
        public AircraftEntity(string id) : base(id) => _state = AircraftState.IdentifiedBy(id);

        protected override void State(AircraftState state) => _state = state;

        public ICompletes<AircraftState> Consign(Registration registration, ManufacturerSpecification manufacturerSpecification, Carrier carrier)
        {
            var stateArg = _state.Consign(registration, manufacturerSpecification, carrier);
            return Apply(stateArg, new AircraftConsigned(stateArg), () => _state);
        }
    }
}