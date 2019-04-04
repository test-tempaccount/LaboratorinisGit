using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace LaboratorinisGit {

    class Program
    {

        static String s = "";
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            
            while (true) {

                students.Clear();
                Console.WriteLine("Ivesti duomenis: is failo (1), su klaviatura (2). Generuoti ir isrusiuoti (3)");

                try
                {
                    String pasirinkimas = Console.ReadLine();
                    //bool a = pasirinkimas.All(char.IsDigit);
                    int a = int.Parse(pasirinkimas);


                    if (a == 1)
                    {
                        pridetiSuFailu();
                    }
                    else if (a == 2)
                    {
                        pridetiSuKlaviatura();
                    }
                    else if (a == 3)
                    {
                        generuotIrRusiuot();
                    } else { 
                        Console.WriteLine("Neteisinga ivestis. Galima ivesti tik 1, 2 arba 3");
                    }

                } catch (FormatException e) {
                    Console.WriteLine("Neteisinga ivestis. Galima ivesti tik 1, 2 arba 3");
                }

            }


        }

        static void generuotIrRusiuot()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            irasytiIFaila();
            rusiavimasIFailus();
            stopwatch.Stop();
            Console.WriteLine("Failu kurimas ir rusiavimas uztruko " + (double)stopwatch.ElapsedMilliseconds/1000 + " sekundes");
        }

        static void pridetiSuFailu()
        {

            
            students = nuskaitytiFaila("kursiokai.txt");

            if (students == null)
                return;

            Console.WriteLine("{0,-10}{1,-15}{2,15}{3,20}", "Vardas", "Pavarde", "Galutinis (Vid.)", "Galutinis (Med.)");
            Console.WriteLine("--------------------------------------------------------------");

            IEnumerable<Student> orderByVardas = students.OrderBy(p => p.getVardas());

            foreach (Student std in orderByVardas)
            {

                bool neigEgz = false;
                bool neigNd = false;

                if (std.getEgzaminas() == -1)
                {
                    neigEgz = true;
                }

                foreach(int vi in std.getPazymiai()){
                    if (vi == -1)
                    {
                        neigNd = true;
                    }
                }

                if (neigEgz == true || neigNd == true)
                {
                    Console.WriteLine("{0,-10}{1,-15}{2,15}", std.getVardas(), std.getPavarde(),
                    "Netinkamas simbolis egzamine arba ND");
                }
                else
                {
                    Console.WriteLine("{0,-10}{1,-15}{2,15}{3,20}", std.getVardas(), std.getPavarde(),
                    tikVidurkis(std), tikMediana(std));
                }
                
            }

        }


        static void rusiavimasIFailus()
        {


            int[] failai = {10, 100, 1000, 10000, 100000 };
            
            List<Student> vargsiukai = new List<Student>();
            List<Student> kietiakai = new List<Student>();

            foreach (int f in failai)
            {
                List<Student> failoStudentai = nuskaitytiFaila(f+".txt");

                foreach (Student student in failoStudentai)
                {

                    double studentoVidurkis = tikVidurkis(student);

                    if (studentoVidurkis < 5)
                    {
                        vargsiukai.Add(student);
                        
                    }
                    else
                    {
                        kietiakai.Add(student);
                        
                    }
                }

            }

            StringBuilder eilute = new StringBuilder();

            foreach(Student student in vargsiukai)
            {
                string fg = string.Join(" ", student.getPazymiai());
                eilute.Append(student.getVardas() + " " + student.getPavarde() + " " + fg +  " " + student.getEgzaminas() + "\n");
            }

            File.WriteAllText("vargsiukai.txt", eilute.ToString());

            eilute.Clear();

            foreach (Student student in kietiakai)
            {
                string fg = string.Join(" ", student.getPazymiai());
                eilute.Append(student.getVardas() + " " + student.getPavarde() + " " + fg + " " + student.getEgzaminas() + "\n");
            }

            File.WriteAllText("kietiakai.txt", eilute.ToString());

        }

        

        static void pridetiSuKlaviatura()
        {

            bool testi = true;
            bool testi2 = true;
            bool jauRode = false;


            while (testi)
            {

                testi2 = true;

                Console.WriteLine("Iveskite varda");
                String vardas = Console.ReadLine();

                Console.WriteLine("Iveskite pavarde");
                String pavarde = Console.ReadLine();

                Student studentas = new Student(vardas, pavarde);

                while (testi2)
                {

                    Console.WriteLine("Iveskite nd pazymius (b - baigti)");
                    String input = Console.ReadLine();

                    if (input.Equals("b"))
                    {
                        testi2 = false;
                        break;
                    }
                    else
                    {
                        studentas.addPazimys(int.Parse(input));
                    }
                }

                Console.WriteLine("Iveskite egzamino rezultata");
                double egzaminas = double.Parse(Console.ReadLine());
                studentas.addEgzaminas(egzaminas);

                if (!jauRode)
                {

                    Console.WriteLine("Naudosite mediana ar vidurki? (1) Mediana (2) Vidurkis");
                    String ats = Console.ReadLine();

                    if (ats.Equals("2"))
                    {
                        s = "v";
                    }
                    else if (ats.Equals("1"))
                    {
                        s = "m";
                    }

                    jauRode = true;

                }


                students.Add(studentas);

                studentas.setVidurkis(skaiciuotiVidurki(studentas));



                Console.WriteLine("Ar norite dar prideti studenta? (t/n)");
                String tesimas = Console.ReadLine();

                if (tesimas.Equals("n"))
                {
                    testi = false;
                }

            }

            if (s.Equals("m"))
            {
                Console.WriteLine("{0,-10}{1,-15}{2,15}", "Vardas", "Pavarde", "Mediana (Vid.)");
            }
            else
            {
                Console.WriteLine("{0,-10}{1,-15}{2,15}", "Vardas", "Pavarde", "Galutinis (Vid.)");
            }

            Console.WriteLine("---------------------------------------------");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("{0,-10}{1,-15}{2,15}", students.ElementAt(i).getVardas(), students.ElementAt(i).getPavarde(), students.ElementAt(i).getVidurkis());
            }

        }

        static double skaiciuotiVidurki(Student student)
        {
            double suma = 0;
            List<int> ls = student.getPazymiai();
            for (int i = 0; i < ls.Count; i++) {
                suma += ls.ElementAt(i);
            }
            

            if (s.Equals("v")) {
                return 0.3 * (suma / ls.Count) + 0.7 * student.getEgzaminas();
            }

            return 0.3 * skaiciuotiMediana(student) + 0.7 * student.getEgzaminas();

        }

        static double tikVidurkis(Student student)
        {
            double suma = 0;
            List<int> ls = student.getPazymiai();
            for (int i = 0; i < ls.Count; i++)
            {
                suma += ls.ElementAt(i);
            }

            

            return 0.3 * (suma / ls.Count) + 0.7 * student.getEgzaminas();
        }

        static double tikMediana(Student student)
        {
            return 0.3 * skaiciuotiMediana(student) + 0.7 * student.getEgzaminas();
        }

        static List<int> generatePazymiai(int kiekis, Random rnd) {

            List<int> temp = new List<int>();

            for (int i = 0; i < kiekis; i++ ) {
                int rndPazimys = rnd.Next(1, 11);
                temp.Add(rndPazimys);
            }
           
            return temp;

        }

        static int generateEgzaminas(Random rnd)
        {
            return rnd.Next(1, 11);
        }


        static List<Student> nuskaitytiFaila(String path) {
            string[] lines = new string[0];
            bool f = true;
            while (f) {
                try
                {
                    lines = File.ReadAllLines(path, Encoding.GetEncoding(1257));
                    f = false;
                } catch (Exception e) {
                    Console.WriteLine("Nerastas failas "+path+". Ikelkite faila ir paspauskite betkoki klavisa, kad testi");
                    Console.ReadKey();
                }
            }
        

            int ndKiekis = failoNdKiekis(lines[0]);

            if (ndKiekis == 0) {
                Console.WriteLine("Faile "+path+" nera nurodyto nei vieno pazymio.");
                return null;
            }
       
            List<Student> tempSt = new List<Student>();

            foreach (string line in lines.Skip(1)){

                    string[] l = line.Split(' ');
                    List<int> ndPazymiai = new List<int>();
                    int egzaminas;

                    for (int i = 2; i < ndKiekis + 2; i++)
                    {
                        
                        if ( l[i].All(Char.IsDigit) ) {
                        ndPazymiai.Add(int.Parse(l[i]));
                    }else {
                        ndPazymiai.Add(-1);
                    }

                        
                    }

                if (l[ndKiekis + 2].All(char.IsDigit))
                {
                    egzaminas = int.Parse(l[ndKiekis + 2]);
                    
                }
                else
                {
                    egzaminas = -1;
                }

                    Student student = new Student(l[0], l[1]);
                    student.addEgzaminas(egzaminas);
                    student.setPazymiai(ndPazymiai);

                    tempSt.Add(student);
            }

            return tempSt;
        }

        static void irasytiIFaila()
        {

            int[] failai = { 10, 100, 1000, 10000, 100000 };

            foreach (int f in failai){

                String header = "Vardas Pavarde ND1 ND2 ND3 ND4 ND5 Egzaminas";
                StringBuilder visasTekstas = new StringBuilder();
                Random rnd = new Random();

                visasTekstas.Append(header + "\n");

                for (int i = 0; i < f; i++)
                {
                    String vardas = "Vardas" + (i + 1);
                    String pavarde = "Pavarde" + (i + 1);
                    String arrPazymiai = string.Join(" ", generatePazymiai(5, rnd));
                    visasTekstas.Append(vardas + " " + pavarde + " " + arrPazymiai + " " + generateEgzaminas(rnd));
                    visasTekstas.Append("\n");
                }

                File.WriteAllText(f+".txt", visasTekstas.ToString());

            }
        }

        public static int failoNdKiekis(String s){

            string[] l = s.Split(' ');
            int ndIndex = 0;

            for (int i = 2; i < l.Length; i++){

                if (l[i].StartsWith("ND"))
                {
                    ndIndex++;
                }

            }

                return ndIndex;
        }



        static double skaiciuotiMediana(Student student) {

            int[] tempArray = student.getPazymiai().ToArray();
            int count = tempArray.Length;

            Array.Sort(tempArray);

            double mediana = 0;

            if (count % 2 == 0){

                int kaire = tempArray[(count / 2) - 1];
                int desine = tempArray[(count / 2)];
                mediana = ((double)kaire + (double)desine) / 2;

            }else{
                mediana = tempArray[(count / 2)];
            }

            return mediana;
        }



    }
}