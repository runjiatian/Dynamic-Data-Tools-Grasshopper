﻿using System;
using System.Collections.Generic;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using DataToolsGrasshopper.Utils;

namespace DataToolsGrasshopper.Data
{
    public class BooleanGate : GHGateComponent<GH_Boolean>
    {
        public BooleanGate()
          : base("Boolean Gate", 
              "Boolean Gate",
              "Will let Boolean data trough only if it changed since the previous solution. Works at the full Data Tree level.")
        { }

        public override GH_Exposure Exposure => GH_Exposure.primary;
        protected override System.Drawing.Bitmap Icon => Properties.Resources.icons_boolean_gate;
        public override Guid ComponentGuid => new Guid("605b35a5-39fe-49fb-a9dc-48a0824cb921");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Bool", "B", "Input Boolean data.", GH_ParamAccess.tree);
            pManager[0].Optional = true;  // avoid "failed to collect data" 
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Bool", "B", "Output will update only if input changed.", GH_ParamAccess.tree);
        }
    }
}
