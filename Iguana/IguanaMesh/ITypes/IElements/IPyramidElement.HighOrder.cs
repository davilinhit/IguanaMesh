﻿using Iguana.IguanaMesh.IUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iguana.IguanaMesh.ITypes.IElements
{
    public partial class IPyramidElement : IElement
    {
        public class HighOrder
        {
            public class IPyramid13 : IPyramidElement
            {
                /// <summary>
                /// 13-node second order pyramid(5 nodes associated with the vertices and 8 with the edges).
                /// Element Type Reference: 19
                /// NOTE: Vertices on an AHF-IElement needs to be sorted according to the CFD General Notation System.\nSee: https://cgns.github.io/CGNS_docs_current/sids/conv.html
                /// </summary>
                public IPyramid13(int[] vertices) : base(vertices) { }

                /// <summary>
                /// <para> Element´s description . </para>
                /// </summary>
                public override string ToString()
                {
                    string eType = "(13-Nodes) IPyramid 2nd-Order";
                    return IHelpers.HighOrder3DElementsToString(eType, Vertices, 5);
                }

                public override bool GetHalfFacet(int index, out int[] halfFacets)
                {
                    Boolean flag = true;
                    halfFacets = null;

                    switch (index)
                    {
                        case 1:
                            halfFacets = new int[] { Vertices[0], Vertices[5], Vertices[1], Vertices[8], Vertices[2], Vertices[10], Vertices[3], Vertices[6] };
                            break;
                        case 2:
                            halfFacets = new int[] { Vertices[0], Vertices[5], Vertices[1], Vertices[9], Vertices[4], Vertices[7] };
                            break;
                        case 3:
                            halfFacets = new int[] { Vertices[1], Vertices[8], Vertices[2], Vertices[11], Vertices[4], Vertices[9] };
                            break;
                        case 4:
                            halfFacets = new int[] { Vertices[2], Vertices[10], Vertices[3], Vertices[12], Vertices[4], Vertices[11] };
                            break;
                        case 5:
                            halfFacets = new int[] { Vertices[3], Vertices[6], Vertices[0], Vertices[7], Vertices[4], Vertices[12] };
                            break;
                        default:
                            flag = false;
                            break;
                    }

                    return flag;
                }

                public override bool AddVertex(int vertexKey)
                {
                    throw new NotImplementedException();
                }

                public override bool RemoveVertex(int vertexKey)
                {
                    throw new NotImplementedException();
                }

                public override int[] GetNodesForFastDrawing()
                {
                    return new int[] { Vertices[0], Vertices[1], Vertices[2], Vertices[3], Vertices[4] };
                }

                public override int[] GetNodesForDetailedDrawing()
                {
                    return Vertices;
                }
            }
        }
    }
}