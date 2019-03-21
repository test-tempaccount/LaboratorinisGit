using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisGit
{

    class Program
    {

        static String s = "";

        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();

            bool testi = true;
            bool testi2 = true;
            bool jauRode = false;


            while (testi) {

            testi2 = true;

            Console.WriteLine("Iveskite varda");
            String vardas = Console.ReadLine();

            Console.WriteLine("Iveskite pavarde");
            String pavarde = Console.ReadLine();

            Student studentas = new Student(vardas, pavarde);

            while (testi2) {

            Console.WriteLine("Iveskite nd pazymius (b - baigti)");
            String input = Console.ReadLine();

            if (input.Equals("b")) {
                testi2 = false;
                break;
                }else{
                    studentas.addPazimys(int.Parse(input));
                }
            }

            Console.WriteLine("Iveskite egzamino rezultata");
            double egzaminas = double.Parse(Console.ReadLine());
            studentas.addEgzaminas(egzaminas);

            if (!jauRode) {

            Console.WriteLine("Naudosite mediana ar vidurki? 1.Mediana 2. Vidurkis");
            String ats = Console.ReadLine();

            if (ats.Equals("2") || ats.Equals("2."))
            {
                        s = "v"; 
            }
            else if (ats.Equals("1") || ats.Equals("1."))
            {
                        s = "m";
            }

            jauRode = true;

            }


            students.Add(studentas);

            studentas.setVidurkis(skaiciuotiVidurki(studentas));



                Console.WriteLine("Ar norite dar prideti studenta? (t/n)");
            String tesimas = Console.ReadLine();

            if (tesimas.Equals("n")){
                    testi=false;
            }

            }

            if (s.Equals("m")) {
                Console.WriteLine("{0,-10}{1,-20}{2,20}", "Vardas", "Pavarde", "Mediana (Vid.)");
            }
            else {
                Console.WriteLine("{0,-10}{1,-20}{2,20}", "Vardas", "Pavarde", "Galutinis (Vid.)");
            }
            
            Console.WriteLine("---------------------------------------------");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("{0,-10}{1,-20}{2,20}", students.ElementAt(i).getVardas(), students.ElementAt(i).getPavarde(), students.ElementAt(i).getVidurkis());
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

        public List<double> generatePazymiai() {

            List<double> temp = new List<double>();

            Random rnd = new Random();
            int rndKiekis = rnd.Next(0, 6);

            for (int i = 0; i < rndKiekis; i++ ) {
                int rndPazimys = rnd.Next(0, 11);
                temp.Add(rndPazimys);
            }

            return temp;

        }



        static double skaiciuotiMediana(Student student) {

            int[] tempArray = student.getPazymiai().ToArray();
            int count = tempArray.Length;

            Array.Sort(tempArray);

            double mediana = 0;

            if (count % 2 == 0){

                int kaire = tempArray[(count / 2) - 1];
                int desine = tempArray[(count / 2)];
                mediana = (kaire + desine) / 2;

            }else{
                mediana = tempArray[(count / 2)];
            }

            return 0.3 * mediana + 0.7 * student.getEgzaminas();
        }

        class Student {

            String name = "";
            String surname = "";
            double egzaminas;
            double vidurkis;
            int mediana;
            List<int> pazymiai = new List<int>();

            public Student(String name, String surname) {
                this.name = name;
                this.surname = surname;
            }


            public void addPazimys(int pazimys) {
                pazymiai.Add(pazimys);
            }

            public void addEgzaminas(double pazimys)
            {
                egzaminas = pazimys;
            }

            public double getEgzaminas()
            {
                return egzaminas;
            }


            public List<int> getPazymiai() {
                return pazymiai;
            }

            public String getVardas()
            {
                return name;
            }

            public String getPavarde()
            {
                return surname;
            }

            public double getVidurkis()
            {
                return vidurkis;
            }

            public void setVidurkis(double vidurkis)
            {
                this.vidurkis = vidurkis;
            }

            public double getMediana()
            {
                return mediana;
            }

            public void setMediana(int vidurkis)
            {
                this.mediana = mediana;
            }



        }

    }
}