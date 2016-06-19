using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AANGConsoleApplication
{
    class Program
    {
        const int atributteAmount = 4;
        static void Main(string[] args)
        {
            String dana;
            String text;
            String name;
            double number;
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
            String neuronName;
            Receptor w_receptor;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("E:\\Visual_zapisywanie\\AANGConsoleApplication\\AANGConsoleApplication\\bin\\iris.txt");
            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                neuronName = "Neuron" + (counter + 1);
                name = neuronName;
                Neurons.Add(new Neuron(name));

                for (int j = 0; j < atributteAmount; j++)
                        {
                            String [] data = line.Split(',');
                            if (j == 3)
                            {
                                text = data[j];
                                w_receptor = SensoryFields[j].AddReceptor(text);
                                w_receptor.ConnectNeuron(Neurons[counter]);
                                Neurons[counter].ConnectReceptor(w_receptor);
                            }
                            else
                            {



                        //number = int.Parse(data[j]);
                        //w_receptor = SensoryFields[j].AddReceptor(number);
                        //w_receptor.ConnectNeuron(Neurons[counter]);
                        //Neurons[counter].ConnectReceptor(w_receptor);
                        double bb = 5.1;
                        var costam = data[j];
                        double dd = Convert.ToDouble(costam.Replace('.', ','));
                        //var vv = Convert.ToSingle(costam);
                        //if (costam.Contains("."))
                        //    costam = costam.Replace(".", ",");
                        //number = System.Convert.ToSingle(costam);
                        // number = Convert.ToSingle(costam);
                        //var gg = double.Parse((data[j]).ToString()); //wrong input
                            }
                        }
                        counter++;
            }
            file.Close();

            //Console.ReadLine();
            //widok działąnia programu
            int choice;
            String [] a = new String [4];
            String cl;
            int neuron_nr;
            Console.WriteLine("Opcje");
            Console.WriteLine("(1) By pobudzić receptory wciśnij 1");
            Console.WriteLine("(2) By pobudzić receptory wciśnij 2");
            Console.WriteLine("Czekam na dokonanie wyboru...");

            choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    for (int j = 0; j < atributteAmount; j++)
                    {
                        Console.WriteLine("Wpisz atrybut nr" + (j+1) + ": ");
                        a[j] = Console.ReadLine(); //ideks wykracza poza granice tablicy
                    }
                    Console.WriteLine("Wpisz nazwe klasy: ");
                    cl = Console.ReadLine();
                    for (int j = 0; j < atributteAmount; j++)
                    {
                        if (a[j] != "x")
                        {
                            SensoryFields[j].StimulateReceptor(a[j]);
                        }
                    }
                    if(cl != "x")
                    {
                        SensoryFields[atributteAmount].StimulateReceptor(cl);
                    }
               break;
               case 2:
                    Console.WriteLine("Wpisz nr neuronu: ");
                    neuron_nr = int.Parse(Console.ReadLine());
                    if ((neuron_nr < 1) || neuron_nr > Neurons.Count)
                    {
                        Console.WriteLine("Ups...Nie ma takiego neuronu");
                    }
                    else
                    {
                        Neurons[neuron_nr - 1].StimulateReceptors();
                    }

               break;
               default:
                    Console.WriteLine("Oho.. nie ma takiej opcji");
               break;
            }

            int i = 1;
            Console.WriteLine("Pobudzenia neuronów: ");
            foreach(Neuron neuron in Neurons)
            {
                if((i -1) % 50 == 0) { }//można podzieli po 10 zeby ładniej było widac :)
                Console.WriteLine((i++) + ": " + neuron.NeuronExcitatedValue);
            }
            Console.ReadLine();
        }
        
    }
}
