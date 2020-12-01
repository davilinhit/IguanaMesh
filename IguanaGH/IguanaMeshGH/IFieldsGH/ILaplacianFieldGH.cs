﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Iguana.IguanaMesh.IWrappers.IExtensions;
using Rhino.Geometry;

namespace IguanaGH.IguanaMeshGH.IFieldsGH
{
    public class ILaplacianFieldGH : GH_Component
    {
        double delta = 0.1;

        /// <summary>
        /// Initializes a new instance of the ILaplacianFieldGH class.
        /// </summary>
        public ILaplacianFieldGH()
          : base("iLaplacianField", "iLaplacF",
              "Compute finite difference the Laplacian of Field:\nF = G(x+d, y, z) + G(x-d, y, z) + G(x, y+d, z) + G(x, y-d, z) + G(x, y, z+d) + G(x, y, z-d) - 6 * G(x, y, z),\nwhere G = Field and d = StepSize",
              "Iguana", "Fields")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Field", "iF", "Field to evaluate.", GH_ParamAccess.item);
            pManager.AddNumberParameter("StepSize", "S", "Step size of finite differences. Default is "+delta, GH_ParamAccess.item, delta);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("iMeshField", "iF", "Field for mesh generation.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IguanaGmshField auxfield = null;
            DA.GetData(0, ref auxfield);
            DA.GetData(1, ref delta);

            IguanaGmshField.Laplacian field = new IguanaGmshField.Laplacian();
            field.IField = auxfield;
            field.Delta = delta;

            DA.SetData(0, field);
        }

        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.iLaplacianField;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("db70baec-04df-41c4-88b4-234beb42d562"); }
        }
    }
}