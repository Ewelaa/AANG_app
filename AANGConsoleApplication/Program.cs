using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AANGConsoleApplication
{
    class Program
    {
        const int atributteAmount = 5;
        static void Main(string[] args)
        {
            String dana;
            String text;
            String name;
            float number;
            Receptor receptor;
            List<SensoryField> SensoryFields = new List<SensoryField>();
            List<Neuron> Neurons = new List<Neuron>();

            SensoryFields.Add(new SensoryField("sepalLength"));
            SensoryFields.Add(new SensoryField("sepalWidth"));
            SensoryFields.Add(new SensoryField("petalLength"));
            SensoryFields.Add(new SensoryField("petalWidth"));
            SensoryFields.Add(new SensoryField("species"));


            int counter = 0;
            String line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("E:\\Visual_zapisywanie\\AANGConsoleApplication\\AANGConsoleApplication\\bin\\iris.txt");
            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                String neuronName = "Neuron" + (counter + 1);
                for (int i = 0; i < atributteAmount; i++)
                        {
                            String [] data = line.Split(',');
                            if (i == 4)
                            {
                                text = data[i];
                                receptor = SensoryFields[i].AddReceptor(text);
                                receptor.ConnectNeuron(Neurons[counter]);
                                Neurons[counter].ConnectReceptor(receptor);
                            }
                            else
                            {
                                var costam = data[i];

                                if (costam.Contains("."))
                                    costam = costam.Replace(".", ",");
                                number = System.Convert.ToSingle(costam);
                            
                           // number = Convert.ToSingle(costam);
                                //number = float.Parse((data[i]).ToString()); //wrong input
                                receptor = SensoryFields[i].AddReceptor(number);
                                receptor.ConnectNeuron(Neurons[counter]);
                                Neurons[counter].ConnectReceptor(receptor);
                            }
           
                        }

                counter++;
                Neurons.Add(new Neuron(neuronName));
            }
            file.Close();
//widok działąnia programu

            Console.ReadLine();

        }
    }
}
