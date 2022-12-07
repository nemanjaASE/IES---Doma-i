using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTN;

namespace Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                BaseVoltage bv1 = new BaseVoltage()
                {
                    Name = "Base Voltage 1",
                    MRID = Guid.NewGuid().ToString(),
                    NominalVoltage = 1100
                };

                BaseVoltage bv2 = new BaseVoltage()
                {
                    Name = "Base Voltage 2",
                    MRID = Guid.NewGuid().ToString(),
                    NominalVoltage = 400
                };

                Location loc = new Location()
                {
                    Name = "Location 1",
                    MRID = Guid.NewGuid().ToString(),
                    CorporateCode = Guid.NewGuid().ToString()
                };


                sw.WriteLine("-> BV1" +
                    $"\n \t Name: {bv1.Name}" +
                    $"\n \t MRID: {bv1.MRID}" +
                    $"\n \t Nominal Voltage: {bv1.NominalVoltage}");

                sw.WriteLine("-> BV2" +
                    $"\n \t Name: {bv2.Name}" +
                    $"\n \t MRID: {bv2.MRID}" +
                    $"\n \t Nominal Voltage: {bv2.NominalVoltage}");

                sw.WriteLine("-> LOC" +
                    $"\n \t Name: {loc.Name}" +
                    $"\n \t MRID: {loc.MRID}" + 
                    $"\n \t Corporate Code: {loc.CorporateCode}"
                    );

                for (int i = 0; i < 20; i++)
                {
                    PowerTransformer pw = new PowerTransformer() {
                        Name = "Power Transformer " + (i + 1),
                        MRID = Guid.NewGuid().ToString(),
                        Autotransformer = false,
                        Location = loc
                    };

                    TransformerWinding tw1 = new TransformerWinding()
                    {
                        Name = "Transformer Winding " + (i + 1) * 10,
                        MRID = Guid.NewGuid().ToString(),
                        Grounded = true,
                        PowerTransformer = pw,
                        BaseVoltage = bv1,
                        Location  = loc
                    };

                    TransformerWinding tw2 = new TransformerWinding()
                    {
                        Name = "Transformer Winding " + (i + 1) * 11,
                        MRID = Guid.NewGuid().ToString(),
                        Grounded = false,
                        PowerTransformer = pw,
                        BaseVoltage = bv2,
                        Location = loc
                    };

                    WindingTest wt1 = new WindingTest()
                    {
                        Name = "Winding Test " + (i + 1) * 10,
                        MRID = Guid.NewGuid().ToString(),
                        From_TransformerWinding = tw1,
                        PhaseShift = 120
                    };

                    WindingTest wt2 = new WindingTest()
                    {
                        Name = "Winding Test " + (i + 1) * 11,
                        MRID = Guid.NewGuid().ToString(),
                        From_TransformerWinding = tw2,
                        PhaseShift = 90
                    };

                    sw.WriteLine("-> PW" + (i + 1) +
                        $"\n \t Name: {pw.Name}" +
                        $"\n \t MRID: {pw.MRID}" +
                        $"\n \t Autotransformer: {pw.Autotransformer.ToString()}"
                    );

                    sw.WriteLine("\n \t -> TW" + ((i + 1) * 10) +
                       $"\n \t \t Name: {tw1.Name}" +
                       $"\n \t \t MRID: {tw1.MRID}" +
                       $"\n \t \t Grounded: {tw1.Grounded.ToString()}"
                    );

                    sw.WriteLine("\n \t \t -> WT" + ((i + 1) * 10) +
                       $"\n \t \t \t Name: {wt1.Name}" +
                       $"\n \t \t \t MRID: {wt1.MRID}" +
                       $"\n \t \t \t Phase shift: {wt1.PhaseShift}"
                    );

                    sw.WriteLine("\n \t -> TW" + ((i + 1) * 11) +
                       $"\n \t \t Name: {tw2.Name}" +
                       $"\n \t \t MRID: {tw2.MRID}" +
                       $"\n \t \t Grounded: {tw2.Grounded.ToString()}"
                    );

                    sw.WriteLine("\n \t \t -> WT" + ((i + 1) * 11) +
                       $"\n \t \t \t Name: {wt2.Name}" +
                       $"\n \t \t \t MRID: {wt2.MRID}" +
                       $"\n \t \t \t Phase shift: {wt2.PhaseShift}"
                    );
                }   
            }
            Console.WriteLine("Succeed!");
            Console.ReadKey();
        }
    }
}
