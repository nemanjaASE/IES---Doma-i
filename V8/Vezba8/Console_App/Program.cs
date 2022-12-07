using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FTN.Common;
namespace Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Delta delta = new Delta();

            // Base voltage 1

            ResourceDescription baseVoltage1 =
                new ResourceDescription(ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, -1));

            baseVoltage1.AddProperty(new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, 110f));

            // Base voltage 2

            ResourceDescription baseVoltage2 =
                new ResourceDescription(ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, -2));

            baseVoltage2.AddProperty(new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, 20f));

            // Location 

            ResourceDescription location =
                new ResourceDescription(ModelCodeHelper.CreateGlobalId(0, (short)DMSType.LOCATION, -1));

            // Power Transformer

            ResourceDescription powerTransformer =
                new ResourceDescription(ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTR, -1));

            powerTransformer.AddProperty(new Property(ModelCode.PSR_LOCATION, location.Id));

            // Transformer Winding 1

            ResourceDescription transformerWinding1 =
                new ResourceDescription(ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTRWINDING, -1));

            transformerWinding1.AddProperty(new Property(ModelCode.CONDEQ_BASVOLTAGE, baseVoltage1.Id));;
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, powerTransformer.Id));

            // Transformer Winding 2

            ResourceDescription transformerWinding2 =
                new ResourceDescription(ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTRWINDING, -2));

            transformerWinding2.AddProperty(new Property(ModelCode.CONDEQ_BASVOLTAGE, baseVoltage2.Id));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, powerTransformer.Id));


            delta.AddDeltaOperation(DeltaOpType.Insert, baseVoltage1, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, baseVoltage2, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, location, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, powerTransformer, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, transformerWinding1, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, transformerWinding2, true);

            using (XmlTextWriter writer = new XmlTextWriter("delta.xml", Encoding.ASCII))
            {
                delta.ExportToXml(writer);
            }

            Console.ReadKey();
        }
    }
}
